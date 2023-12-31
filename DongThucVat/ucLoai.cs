﻿using System;
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

        private int loai;
        private string idUser;
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
                    dgvLoad(); // Gọi lại phương thức từ luồng UI chính
                });
                return;
            }
            using (SqlConnection conn = Connect.ConnectDB())
            {
                conn.Open();
                if (idFK == 0)
                    sql = "SELECT l.*, h.name AS namefk FROM Loai l JOIN Ho h ON l.id_dtv_ho = h.id WHERE l.loai = " + loai;
                else
                    sql = "SELECT l.*, h.name AS namefk FROM Loai l JOIN Ho h ON l.id_dtv_ho = h.id WHERE l.loai = " + loai + " AND l.id_dtv_ho = " + cb.SelectedValue;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter daGRV = new SqlDataAdapter(cmd))
                    {
                        DataTable dtGRV = new DataTable();
                        daGRV.Fill(dtGRV);
                        await Task.Delay(500);
                        dgv.DataSource = dtGRV;
                        dgv.Refresh();
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

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dgv);
        }

        private void SetRowNumber(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["STT"].Value = row.Index + 1;
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
            dgvLoad();
            vitri = null;
        }
    }
}
