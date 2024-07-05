﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class ucSearch : UserControl
    {
        private readonly string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];
        private readonly List<int> listID = new List<int>();
        private readonly List<KetQua> kqList = new List<KetQua>();
        private SqlConnection conn;
        private string sql = "";
        private int loai;
        private int currentPage = 1;
        private const int rowsPerPage = 20;

        public int Loai { get => loai; set => loai = value; }

        public class KetQua
        {
            public string ID { get; set; }
            public string TenLoai { get; set; }
            public string Ho { get; set; }
            public string Bo { get; set; }
            public string Lop { get; set; }
            public string Nganh { get; set; }
        }

        public ucSearch()
        {
            InitializeComponent();
        }

        private async Task LoadComboBoxAsync(ComboBox comboBox, string tenbang, string query)
        {
            using (SqlConnection connection = Connect.ConnectDB())
            {
                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        DataRow row = dataTable.NewRow();
                        row["name"] = "--" + tenbang + "--";
                        row["id"] = 0;
                        dataTable.Rows.InsertAt(row, 0);

                        comboBox.DataSource = dataTable;
                        comboBox.DisplayMember = "name";
                        comboBox.ValueMember = "id";
                    }
                }
            }
        }

        public async Task listItemLoadAsync()
        {
            fpnlKetQua.Controls.Clear();

            int startIndex = (currentPage - 1) * rowsPerPage;
            int endIndex = Math.Min(startIndex + rowsPerPage, kqList.Count);

            if (kqList != null && kqList.Count > 0)
            {
                int arrayLength = endIndex - startIndex;
                if (arrayLength < 0)
                    arrayLength = 0;

                ucListItem[] listItem = new ucListItem[arrayLength];
                for (int i = startIndex; i < endIndex; i++)
                {
                    listItem[i - startIndex] = new ucListItem();
                    listItem[i - startIndex].Stt = i + 1;

                    if (i < kqList.Count)
                    {
                        KetQua kq = kqList[i];
                        string hinhanhloai = await LoadLatestImageAsync(kq.ID);

                        if (!string.IsNullOrWhiteSpace(hinhanhloai))
                            listItem[i - startIndex].Anh = hinhanhloai;

                        // Gán giá trị từ kq vào listItem[i]
                        listItem[i - startIndex].Id = kq.ID;
                        listItem[i - startIndex].Tenloai = kq.TenLoai;
                        listItem[i - startIndex].Ho = kq.Ho;
                        listItem[i - startIndex].Bo = kq.Bo;
                        listItem[i - startIndex].Lop = kq.Lop;
                        listItem[i - startIndex].Nganh = kq.Nganh;

                        // Gán sự kiện Click cho mỗi ucListItem
                        listItem[i - startIndex].DoubleClick += ucListItem_DoubleClick;

                        // Thêm listItem[i] vào fpnlKetQua.Controls
                        fpnlKetQua.Controls.Add(listItem[i - startIndex]);
                    }
                }
            }
        }

        private void ucListItem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                using (frmHienThi frm = new frmHienThi())
                {
                    // Xác định ucListItem được click
                    ucListItem clickedItem = sender as ucListItem;
                    if (clickedItem != null)
                    {
                        // Lấy số thứ tự của ucListItem
                        string itemID = clickedItem.Id;
                        frm.IdHienThi = itemID;
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ev)
            {
                MessageBox.Show("Lỗi: " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ucListItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (frmHienThi frm = new frmHienThi())
        //        {
        //            // Xác định ucListItem được click
        //            ucListItem clickedItem = sender as ucListItem;
        //            if (clickedItem != null)
        //            {
        //                // Lấy số thứ tự của ucListItem
        //                string itemID = clickedItem.Id;
        //                frm.IdHienThi = itemID;
        //                frm.ShowDialog();
        //            }
        //        }
        //    }
        //    catch (Exception ev)
        //    {
        //        MessageBox.Show("Lỗi: " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private async Task<string> LoadLatestImageAsync(string idloai)
        {
            string hinhanh = "";
            string loaiFolderPath = pictureFolder + "\\" + idloai.ToString();
            try
            {
                if (Directory.Exists(loaiFolderPath))
                {
                    string[] allFiles = await Task.Run(() =>
                        Directory.GetFiles(loaiFolderPath)
                            .OrderByDescending(f => new FileInfo(f).LastWriteTime)
                            .ToArray());

                    string[] imageExtensions = { ".jpg", ".jpeg", ".png" };

                    foreach (string filePath in allFiles)
                    {
                        string extension = Path.GetExtension(filePath).ToLower();

                        if (Array.Exists(imageExtensions, e => e == extension))
                        {
                            hinhanh = filePath;
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(hinhanh) || hinhanh == null)
                        hinhanh = AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png";
                }
            }
            catch
            {
                hinhanh = AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png";
            }

            return hinhanh;
        }
        //public async Task<string> anhListItemLoadAsync(string idloai)
        //{
        //    hinhanh = "";
        //    string loaiFolderPath = pictureFolder + "\\" + idloai.ToString();
        //    try
        //    {
        //        if (Directory.Exists(loaiFolderPath))
        //        {
        //            // Lấy tất cả các đường dẫn file trong thư mục và sắp xếp theo thời gian sửa đổi giảm dần
        //            string[] allFiles = Directory.GetFiles(loaiFolderPath)
        //                .OrderByDescending(f => new FileInfo(f).LastWriteTime)
        //                .ToArray();

        //            // Lọc ra các file ảnh (có thể thêm các định dạng file ảnh khác vào đây)
        //            string[] imageExtensions = { ".jpg", ".jpeg", ".png" };

        //            foreach (string filePath in allFiles)
        //            {
        //                string extension = Path.GetExtension(filePath).ToLower();

        //                if (Array.Exists(imageExtensions, e => e == extension))
        //                {
        //                    // Lấy hình ảnh mới nhất và thoát khỏi vòng lặp
        //                    hinhanh = filePath;
        //                    break;
        //                }
        //            }

        //            // Khi kết thúc vòng lặp, kiểm tra nếu đã tìm thấy hình ảnh mới nhất
        //            if (hinhanh == null)
        //            {
        //                string anhmacdinh = AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png";
        //                return anhmacdinh;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        string anhmacdinh = AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png";
        //        return anhmacdinh;
        //    }
        //    return hinhanh;
        //}

        private async void ucSearch_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            fpnlKetQua.Controls.Clear();
            await LoadComboBoxAsync(cbNganh,"Ngành", "SELECT id, name FROM Nganh WHERE loai = " + loai);
            await LoadComboBoxAsync(cbLop, "Lớp", cbNganh.SelectedIndex > 0 ?
                "SELECT id, name FROM Lop WHERE loai = " + loai + " AND id_dtv_nganh = " + Int32.Parse(cbNganh.SelectedValue.ToString()) :
                "SELECT id, name FROM Lop WHERE loai = " + loai);
            await LoadComboBoxAsync(cbBo, "Bộ", cbLop.SelectedIndex > 0 ?
                "SELECT id, name FROM Bo WHERE loai = " + loai + " AND id_dtv_lop = " + Int32.Parse(cbLop.SelectedValue.ToString()) :
                "SELECT id, name FROM Bo WHERE loai = " + loai);
            await LoadComboBoxAsync(cbHo, "Họ", cbBo.SelectedIndex > 0 ?
                "SELECT id, name FROM Ho WHERE loai = " + loai + " AND id_dtv_bo = " + Int32.Parse(cbBo.SelectedValue.ToString()) :
                "SELECT id, name FROM Ho WHERE loai = " + loai);
            if (loai == 0)
            {
                // Thay đổi items cho combobox cbNDCP khi loai = 0
                cbND84.Items.Clear();
                cbND84.Items.AddRange(new object[] { "Nghị định 84/NĐ-CP", "Nhóm IB", "Nhóm IIB" });
                cbND84.SelectedIndex = 0; // Chọn mặc định item đầu tiên
                cbND84.Items.Clear();
                cbND84.Items.AddRange(new object[] { "Nghị định 64/NĐ-CP", "Nhóm IB", "Nhóm IIB" });
                cbND84.SelectedIndex = 0; // Chọn mặc định item đầu tiên

            }
            if (loai == 1)
            {
                // Thay đổi items cho combobox cbNDCP khi loai = 1
                cbND64.Items.Clear();
                cbND64.Items.AddRange(new object[] { "Nghị định 84/NĐ-CP", "Nhóm IA", "Nhóm IIA" });
                cbND64.SelectedIndex = 0; // Chọn mặc định item đầu tiên
                cbND64.Items.Clear();
                cbND64.Items.AddRange(new object[] { "Nghị định 64/NĐ-CP", "Nhóm IA", "Nhóm IIA" });
                cbND64.SelectedIndex = 0; // Chọn mặc định item đầu tiên
            }
            cbIUCN.SelectedIndex = 0; cbSDVN.SelectedIndex = 0; cbND84.SelectedIndex = 0; cbND64.SelectedIndex = 0;
            await LoadDataGridAsync();
        }

        private async void cbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadComboBoxAsync(cbLop, "Lớp", cbNganh.SelectedIndex > 0 ?
                "SELECT id, name FROM Lop WHERE loai = " + loai + " AND id_dtv_nganh = " + Int32.Parse(cbNganh.SelectedValue.ToString()) :
                "SELECT id, name FROM Lop WHERE loai = " + loai);
            await LoadComboBoxAsync(cbBo, "Bộ", cbLop.SelectedIndex > 0 ?
                "SELECT id, name FROM Bo WHERE loai = " + loai + " AND id_dtv_lop = " + Int32.Parse(cbLop.SelectedValue.ToString()) :
                "SELECT id, name FROM Bo WHERE loai = " + loai);
            await LoadComboBoxAsync(cbHo, "Họ", cbBo.SelectedIndex > 0 ?
                "SELECT id, name FROM Ho WHERE loai = " + loai + " AND id_dtv_bo = " + Int32.Parse(cbBo.SelectedValue.ToString()) :
                "SELECT id, name FROM Ho WHERE loai = " + loai);
        }

        private async void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadComboBoxAsync(cbBo, "Bộ", cbLop.SelectedIndex > 0 ?
                "SELECT id, name FROM Bo WHERE loai = " + loai + " AND id_dtv_lop = " + Int32.Parse(cbLop.SelectedValue.ToString()) :
                "SELECT id, name FROM Bo WHERE loai = " + loai);
            await LoadComboBoxAsync(cbHo, "Họ", cbBo.SelectedIndex > 0 ?
                "SELECT id, name FROM Ho WHERE loai = " + loai + " AND id_dtv_bo = " + Int32.Parse(cbBo.SelectedValue.ToString()) :
                "SELECT id, name FROM Ho WHERE loai = " + loai);
        }

        private async void cbBo_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadComboBoxAsync(cbHo, "Họ", cbBo.SelectedIndex > 0 ?
                "SELECT id, name FROM Ho WHERE loai = " + loai + " AND id_dtv_bo = " + Int32.Parse(cbBo.SelectedValue.ToString()) :
                "SELECT id, name FROM Ho WHERE loai = " + loai);
        }

        private async Task LoadDataGridAsync()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (SqlCommand cmd = new SqlCommand("Search", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@loai", SqlDbType.Int).Value = loai;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                cmd.Parameters.Add("@id_dtv_nganh", SqlDbType.Int).Value = cbNganh.SelectedIndex <= 0 ? DBNull.Value : cbNganh.SelectedValue;
                cmd.Parameters.Add("@id_dtv_lop", SqlDbType.Int).Value = cbLop.SelectedIndex <= 0 ? DBNull.Value : cbLop.SelectedValue;
                cmd.Parameters.Add("@id_dtv_bo", SqlDbType.Int).Value = cbBo.SelectedIndex <= 0 ? DBNull.Value : cbBo.SelectedValue;
                cmd.Parameters.Add("@id_dtv_ho", SqlDbType.Int).Value = cbHo.SelectedIndex <= 0 ? DBNull.Value : cbHo.SelectedValue;
                cmd.Parameters.Add("@muc_do_bao_ton_iucn", SqlDbType.NVarChar).Value = cbIUCN.SelectedIndex == 0 ? "" : cbIUCN.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_sdvn", SqlDbType.NVarChar).Value = cbSDVN.SelectedIndex == 0 ? "" : cbSDVN.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_ndcp", SqlDbType.NVarChar).Value = cbND84.SelectedIndex == 0 ? "" : cbND84.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_nd64cp", SqlDbType.NVarChar).Value = cbND64.SelectedIndex <= 0 ? "" : cbND64.SelectedItem?.ToString();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    await Task.Run(() => adapter.Fill(dataTable));

                    dgv.DataSource = dataTable;
                    dgv.Refresh();

                    listID.Clear();
                    kqList.Clear();

                    lbThongBao.Text = "Danh sách có " + dgv.Rows.Count + " loài.";

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (int.TryParse(row.Cells[0].Value.ToString(), out int id))
                            listID.Add(id);

                        if (!row.IsNewRow && row.Index != -1)
                        {
                            KetQua kq = new KetQua();

                            kq.ID = row.Cells[1].Value.ToString();
                            kq.TenLoai = row.Cells[2].Value.ToString();
                            kq.Ho = row.Cells[5].Value.ToString();
                            kq.Bo = row.Cells[6].Value.ToString();
                            kq.Lop = row.Cells[7].Value.ToString();
                            kq.Nganh = row.Cells[8].Value.ToString();

                            kqList.Add(kq);
                        }
                    }

                    await listItemLoadAsync();
                }
            }

            conn.Close();
        }
        //public async Task dgvLoadAsync()
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    SqlCommand cmd = new SqlCommand("Search", conn);
        //    cmd.Parameters.Add("@loai", SqlDbType.Int).Value = loai;
        //    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
        //    cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
        //    cmd.Parameters.Add("@id_dtv_nganh", SqlDbType.Int).Value = cbNganh.SelectedIndex <= 0 ? DBNull.Value : cbNganh.SelectedValue;
        //    cmd.Parameters.Add("@id_dtv_lop", SqlDbType.Int).Value = cbLop.SelectedIndex <= 0 ? DBNull.Value : cbLop.SelectedValue;
        //    cmd.Parameters.Add("@id_dtv_bo", SqlDbType.Int).Value = cbBo.SelectedIndex <= 0 ? DBNull.Value : cbBo.SelectedValue;
        //    cmd.Parameters.Add("@id_dtv_ho", SqlDbType.Int).Value = cbHo.SelectedIndex <= 0 ? DBNull.Value : cbHo.SelectedValue;
        //    cmd.Parameters.Add("@muc_do_bao_ton_iucn", SqlDbType.NVarChar).Value = cbIUCN.SelectedIndex == 0 ? "" : cbIUCN.SelectedItem?.ToString();
        //    cmd.Parameters.Add("@muc_do_bao_ton_sdvn", SqlDbType.NVarChar).Value = cbSDVN.SelectedIndex == 0 ? "" : cbSDVN.SelectedItem?.ToString();
        //    cmd.Parameters.Add("@muc_do_bao_ton_ndcp", SqlDbType.NVarChar).Value = cbND84.SelectedIndex == 0 ? "" : cbND84.SelectedItem?.ToString();
        //    cmd.Parameters.Add("@muc_do_bao_ton_nd64cp", SqlDbType.NVarChar).Value = cbND64.SelectedIndex <= 0 ? "" : cbND64.SelectedItem?.ToString();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    await cmd.ExecuteNonQueryAsync();

        //    SqlDataAdapter daGRV = new SqlDataAdapter();
        //    daGRV.SelectCommand = cmd;

        //    DataTable dtGRV = new DataTable();
        //    daGRV.Fill(dtGRV);

        //    dgv.DataSource = dtGRV;
        //    dgv.Refresh();

        //    cmd.Dispose();
        //    conn.Close();
        //    listID.Clear();
        //    kqList.Clear();

        //    lbThongBao.Text = "Danh sách có " + dgv.Rows.Count + " loài.";

        //    foreach (DataGridViewRow row in dgv.Rows)
        //    {
        //        if (int.TryParse(row.Cells[0].Value.ToString(), out id))
        //        {
        //            listID.Add(id);
        //        }
        //        if (!row.IsNewRow && row.Index != -1)
        //        {
        //            KetQua kq = new KetQua();

        //            kq.ID = row.Cells[1].Value.ToString();
        //            kq.TenLoai = row.Cells[2].Value.ToString();
        //            kq.Ho = row.Cells[5].Value.ToString();
        //            kq.Bo = row.Cells[6].Value.ToString();
        //            kq.Lop = row.Cells[7].Value.ToString();
        //            kq.Nganh = row.Cells[8].Value.ToString();

        //            kqList.Add(kq);
        //        }
        //    }

        //    await listItemLoadAsync();
        //}

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dgv);
        }

        private async void btPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await listItemLoadAsync();
            }
        }

        private async void btNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < Math.Ceiling((double)kqList.Count / rowsPerPage))
            {
                currentPage++;
                await listItemLoadAsync();
            }
        }

        private void SetRowNumber(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["STT"].Value = row.Index + 1;
            }
        }

        private void btTim_Click_1(object sender, EventArgs e)
        {
            fpnlKetQua.Controls.Clear();
            currentPage = 1;
            LoadDataGridAsync();
        }

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        using (frmHienThi frm = new frmHienThi())
                        {
                            DataGridViewRow row = dgv.Rows[e.RowIndex];
                            frm.IdHienThi = row.Cells[1].Value.ToString();
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ev)
            {
                MessageBox.Show("Lỗi: " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
