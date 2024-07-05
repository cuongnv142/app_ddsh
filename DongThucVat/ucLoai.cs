using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class ucLoai : UserControl
    {
        SqlConnection conn;
        string sql = "";
        string tenTiengViet;
        int id, idFK;
        DataGridViewCellMouseEventArgs vitri;

        private int totalRows = 0;
        private int totalPages = 0;
        private int currentPage = 1;
        private int pageSize = 300; // Số bản ghi trên mỗi trang
        private int loai;
        private string idUser, search;
        public int loaiLoai { get => loai; set => loai = value; }
        public string idUserLoai { get => idUser; set => idUser = value; }

        public ucLoai()
        {
            InitializeComponent();
        }

        private void ucLoai_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            if (loai == 0)
                lbTieuDe.Text = "LOÀI ĐỘNG VẬT";
            else
                lbTieuDe.Text = "LOÀI THỰC VẬT";
            cbLoad();
            dgvLoad();
            vitri = null;
        }

        public async void dgvLoad()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    dgvLoad(); // Call the method again from the main UI thread
                });
                return;
            }

            using (SqlConnection conn = Connect.ConnectDB())
            {
                conn.Open();

                // Calculate total number of rows
                string countSql = $"SELECT COUNT(*) FROM Loai WHERE loai = {loai}";
                SqlCommand countCmd = new SqlCommand(countSql, conn);
                int totalRows = (int)countCmd.ExecuteScalar();
                countCmd.Dispose();

                // Calculate totalPages
                int totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

                int offset = (currentPage - 1) * pageSize;

                // Construct SQL query based on conditions
                if (idFK == 0 && string.IsNullOrEmpty(search))
                {
                    sql = $@"SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY l.id DESC) AS STT, l.*, h.name AS namefk
                        FROM Loai l JOIN Ho h ON l.id_dtv_ho = h.id
                        WHERE l.loai = {loai}
                    ) AS NumberedRows
                    WHERE STT > {offset} AND STT <= {offset + pageSize}";
                }
                else if (idFK == 0 && !string.IsNullOrEmpty(search))
                {
                    sql = $@"SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY l.id DESC) AS STT, l.*, h.name AS namefk
                        FROM Loai l JOIN Ho h ON l.id_dtv_ho = h.id
                        WHERE l.loai = {loai} AND (l.name LIKE N'%{search}%' OR l.name_latinh LIKE N'%{search}%')
                    ) AS NumberedRows
                    WHERE STT > {offset} AND STT <= {offset + pageSize}";
                }
                else if (idFK != 0 && string.IsNullOrEmpty(search))
                {
                    sql = $@"SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY l.id DESC) AS STT, l.*, h.name AS namefk
                        FROM Loai l JOIN Ho h ON l.id_dtv_ho = h.id
                        WHERE l.loai = {loai} AND l.id_dtv_ho = {cb.SelectedValue}
                    ) AS NumberedRows
                    WHERE STT > {offset} AND STT <= {offset + pageSize}";
                }
                else if (idFK != 0 && !string.IsNullOrEmpty(search))
                {
                    sql = $@"SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY l.id DESC) AS STT, l.*, h.name AS namefk
                        FROM Loai l JOIN Ho h ON l.id_dtv_ho = h.id
                        WHERE l.loai = {loai} AND l.id_dtv_ho = {cb.SelectedValue} AND (l.name LIKE N'%{search}%' OR l.name_latinh LIKE N'%{search}%')
                    ) AS NumberedRows
                    WHERE STT > {offset} AND STT <= {offset + pageSize}";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter daGRV = new SqlDataAdapter(cmd))
                    {
                        DataTable dtGRV = new DataTable();
                        daGRV.Fill(dtGRV);

                        await Task.Delay(500);
                        dgv.DataSource = dtGRV;
                        dgv.Refresh();
                        this.totalPages = totalPages;
                        UpdateNavigationButtons();
                    }
                }
            }
        }

        public void cbLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT id, name FROM Ho WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daCB = new SqlDataAdapter();
            daCB.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtCB = new DataTable();
            daCB.Fill(dtCB);

            DataRow r = dtCB.NewRow();
            r["name"] = "--Lọc theo họ--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cb.DataSource = dtCB;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
        }

        private async void btRefresh_Click(object sender, EventArgs e)
        {
            cbLoad();
            // Load dữ liệu từ cơ sở dữ liệu không làm lag ứng dụng
            await Task.Run(() => dgvLoad());
            vitri = null;
            UpdateNavigationButtons(); // Cập nhật trạng thái của nút sau khi làm mới
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn loài!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmLoaiUpdate frm = new frmLoaiUpdate())
            {
                frm.KtThemLoaiUpdate = false;
                frm.IdUserLoaiUpdate = idUser;
                frm.LoaiLoaiUpdate = loai;
                frm.IdLoaiUpdate = id;
                frm.loadDGV += dgvLoad;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            using (frmLoaiUpdate frm = new frmLoaiUpdate())
            {
                frm.KtThemLoaiUpdate = true;
                frm.IdUserLoaiUpdate = idUser;
                frm.LoaiLoaiUpdate = loai;
                frm.loadDGV += dgvLoad;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn loài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa loài " + tenTiengViet + " không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteLoai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                vitri = null;
                cbLoad();
                dgvLoad();
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        vitri = e;
                        DataGridViewRow row = dgv.Rows[e.RowIndex];
                        id = Int32.Parse(row.Cells[1].Value.ToString());
                        tenTiengViet = row.Cells[2].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    SetRowNumber(dgv);
        //}

        //private void SetRowNumber(DataGridView dataGridView)
        //{
        //    foreach (DataGridViewRow row in dataGridView.Rows)
        //    {
        //        row.Cells["STT"].Value = row.Index + 1;
        //    }
        //}

        private void UpdateNavigationButtons()
        {
            // Kiểm tra nếu đang ở trang đầu thì tắt nút Previous
            if (currentPage > 1)
                btPrev.Enabled = true;
            // Kiểm tra nếu đang ở trang cuối thì tắt nút Next
            if (currentPage < totalPages)
                btNext.Enabled = true;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                dgvLoad();
                UpdateNavigationButtons(); // Cập nhật trạng thái của nút sau khi chuyển trang
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search = txtSearch.Text.Trim();
            pageSize = 300;
            dgvLoad();
            vitri = null;
            UpdateNavigationButtons();
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                dgvLoad();
                UpdateNavigationButtons(); // Cập nhật trạng thái của nút sau khi chuyển trang
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedItem is DataRowView selectedItem)
            {
                if (int.TryParse(selectedItem["id"].ToString(), out int intValue))
                {
                    idFK = intValue;
                    vitri = null;
                }
                else
                {
                    idFK = 0;
                }
            }
            else
                idFK = 0;
            // Cập nhật kích thước trang khi chọn họ mới
            pageSize = 300;
            dgvLoad();
            vitri = null;
            UpdateNavigationButtons(); // Cập nhật trạng thái của nút sau khi chuyển họ
        }
    }
}
