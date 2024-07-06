using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class frmLoaiUpdate : Form
    {
        SqlConnection conn;
        string sql = "", tencu;
        public event Action loadDGV;
        bool imageDel;

        // Tạo một đối tượng của lớp ConfigurationManager để đọc thông tin cấu hình từ file app.config
        string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];
        private List<string> selectedImages = new List<string>();
        private string idUser, tenTiengViet;
        private int id, loai;
        private bool ktThem;
        public string IdUserLoaiUpdate { get => idUser; set => idUser = value; }
        public int IdLoaiUpdate { get => id; set => id = value; }
        public int LoaiLoaiUpdate { get => loai; set => loai = value; }
        public bool KtThemLoaiUpdate { get => ktThem; set => ktThem = value; }

        public frmLoaiUpdate()
        {
            InitializeComponent();
            //pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];
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
            r["name"] = "--Chọn họ--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cbFK.DataSource = dtCB;
            cbFK.DisplayMember = "name";
            cbFK.ValueMember = "id";
        }

        public void layNguonControls()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM Loai WHERE id = " + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);
            // Lấy giá trị từ dòng đầu tiên của DataTable
            tenTiengViet = dt.Rows[0]["name"].ToString();
            txtTenTiengViet.Text = dt.Rows[0]["name"].ToString();
            txtTenLatinh.Text = dt.Rows[0]["name_latinh"].ToString();
            txtTenKhac.Text = dt.Rows[0]["ten_khac"].ToString();
            txtPhanBo.Text = dt.Rows[0]["phan_bo"].ToString();
            txtNguonTaiLieu.Text = dt.Rows[0]["nguon_tai_lieu"].ToString();
            cbFK.SelectedValue = dt.Rows[0]["id_dtv_ho"].ToString();
            cbIUCN.SelectedItem = dt.Rows[0]["muc_do_bao_ton_iucn"].ToString();
            cbSDVN.SelectedItem = dt.Rows[0]["muc_do_bao_ton_sdvn"].ToString();
            cbNDCP.SelectedItem = dt.Rows[0]["muc_do_bao_ton_ndcp"].ToString();
            cbND64CP.SelectedItem = dt.Rows[0]["muc_do_bao_ton_nd64cp"].ToString();
            rtxtCongDung.Text = dt.Rows[0]["gia_tri_su_dung"].ToString();
            rtxtDacDiem.Text = dt.Rows[0]["dac_diem"].ToString();
            tencu = txtTenLatinh.Text;
            //if (Boolean.Parse(dt.Rows[0]["status"].ToString()) == true)
            //    rbtOn.Checked = true;
            //if (Boolean.Parse(dt.Rows[0]["status"].ToString()) == false)
            //    rbtOff.Checked = true;
        }

        public void xoaTrang(bool b)
        {
            txtTenTiengViet.Text = "";
            txtTenLatinh.Text = "";
            txtTenKhac.Text = "";
            txtPhanBo.Text = "";
            txtNguonTaiLieu.Text = "";
            cbIUCN.SelectedIndex = 0;
            cbSDVN.SelectedIndex = 0;
            cbNDCP.SelectedIndex = 0;
            cbND64CP.SelectedIndex = 0;
            rtxtCongDung.Text = "";
            rtxtDacDiem.Text = "";
            //rbtOn.Checked = false;
            //rbtOff.Checked = true;
            cbLoad();
            selectedImages.Clear();
        }

        public void LoadImages()
        {
            string loaiFolderPath = pictureFolder + "\\" + id.ToString();
            try
            {
                if (Directory.Exists(loaiFolderPath))
                {
                    // Lấy tất cả các đường dẫn file trong thư mục
                    string[] allFiles = Directory.GetFiles(loaiFolderPath);
                    // Lọc ra các file ảnh (có thể thêm các định dạng file ảnh khác vào đây)
                    string[] imageExtensions = { ".jpg", ".jpeg", ".png" };
                    //string[] imageFiles = Directory.GetFiles(loaiFolderPath, "*.jpg;*.jpeg;*.png");
                    foreach (string filePath in allFiles)
                    {
                        string extension = Path.GetExtension(filePath).ToLower();

                        if (Array.Exists(imageExtensions, e => e == extension))
                        {
                            selectedImages.Add(filePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //public void LoadImages()
        //{
        //    try
        //    {
        //        if (conn.State != ConnectionState.Open)
        //            conn.Open();

        //        string sql = "SELECT hinhanh FROM HinhAnhLoai WHERE id_dtv_loai = @loaiId";
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@loaiId", id);

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            string imageName = pictureFolder + "\\" + id.ToString() + "\\" + reader["hinhanh"].ToString();
        //            if (!string.IsNullOrEmpty(imageName))
        //            {
        //                selectedImages.Add(imageName);
        //            }
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //}

        private void DisplayImages()
        {
            fpnlHinhAnh.Controls.Clear();

            foreach (string imageName in selectedImages)
            {
                try
                {
                    //string imagePath = pictureFolder + "\\" + imageName;
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(imageName);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 50;
                    pictureBox.Height = 50;

                    fpnlHinhAnh.Controls.Add(pictureBox);
                }
                catch
                {
                    // Nếu không tìm thấy tệp hình ảnh hiển thị hình ảnh mặc định
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png");
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 50;
                    pictureBox.Height = 50;

                    fpnlHinhAnh.Controls.Add(pictureBox);
                }
            }
        }

        //private void DisplayImages()
        //{
        //    fpnlHinhAnh.Controls.Clear();

        //    foreach (string imageName in selectedImages)
        //    {
        //        string imagePath = Path.Combine(imageFolder, imageName);

        //        PictureBox pictureBox = new PictureBox();
        //        pictureBox.Image = Image.FromFile(imagePath);
        //        pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        //        pictureBox.Width = 50;
        //        pictureBox.Height = 50;

        //        fpnlHinhAnh.Controls.Add(pictureBox);
        //    }
        //}

        //private void DisplayImages()
        //{
        //    foreach (string imagePath in selectedImages)
        //    {
        //        if (File.Exists(imagePath))
        //        {
        //            PictureBox pictureBox = new PictureBox();
        //            pictureBox.Image = Image.FromFile(imagePath);
        //            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        //            pictureBox.Width = 50;
        //            pictureBox.Height = 50;
        //            fpnlHinhAnh.Controls.Add(pictureBox);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không tìm thấy ảnh: " + imagePath);
        //        }
        //    }
        //}

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmLoaiUpdate_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            xoaTrang(ktThem);
            cbLoad();
            if (loai == 0)
            {
                lbNganh.Text = "LOÀI ĐỘNG VẬT";
                // Thay đổi items cho combobox cbNDCP khi loai = 0
                cbNDCP.Items.Clear();
                cbNDCP.Items.AddRange(new object[] { "Nghị định 84/NĐ-CP", "Nhóm IB", "Nhóm IIB" });
                cbNDCP.SelectedIndex = 0; // Chọn mặc định item đầu tiên
                cbND64CP.Items.Clear();
                cbND64CP.Items.AddRange(new object[] { "Nghị định 64/NĐ-CP", "Nhóm IB", "Nhóm IIB" });
                cbND64CP.SelectedIndex = 0; // Chọn mặc định item đầu tiên

            }
            if (loai == 1)
            {
                lbNganh.Text = "LOÀI THỰC VẬT";
                // Thay đổi items cho combobox cbNDCP khi loai = 1
                cbNDCP.Items.Clear();
                cbNDCP.Items.AddRange(new object[] { "Nghị định 84/NĐ-CP", "Nhóm IA", "Nhóm IIA" });
                cbNDCP.SelectedIndex = 0; // Chọn mặc định item đầu tiên
                cbND64CP.Items.Clear();
                cbND64CP.Items.AddRange(new object[] { "Nghị định 64/NĐ-CP", "Nhóm IA", "Nhóm IIA" });
                cbND64CP.SelectedIndex = 0; // Chọn mặc định item đầu tiên
            }
            imageDel = false;
            if (ktThem == false)
            {
                layNguonControls();
                LoadImages();
                DisplayImages();
            }
            /*
            txtTenTiengViet.Text = tenTiengViet;
            txtTenLatinh.Text = tenLatinh;
            txtTenKhac.Text = tenkhac;
            txtPhanBo.Text = phanbo;
            txtNguonTaiLieu.Text = nguontailieu;
            cbFK.SelectedValue = idFK;
            cbIUCN.SelectedItem = iucn;
            cbSDVN.SelectedValue = sdvn;
            cbNDCP.SelectedValue = ndcp;
            cbND64CP.SelectedValue = nd64cp;
            rtxtCongDung.Text = congdung;
            rtxtDacDiem.Text = dacdiem;
            if (status != null)
            {
                if (Boolean.Parse(status) == true)
                    rbtOn.Checked = true;
                if (Boolean.Parse(status) == false)
                    rbtOff.Checked = true;
            }
            */
        }

        //public string GenerateImagePath(string uploadedFileName)
        //{
        //    // Kết hợp đường dẫn cố định với tên của hình ảnh được tải lên
        //    string fullPath = Path.Combine(pictureFolder, uploadedFileName);

        //    return fullPath;
        //}

        public bool kiemTraTenTrung(bool ktThem, string tenmoi)
        {
            if (ktThem == true)
            {
                sql = "SELECT * FROM loai WHERE name_latinh = N'" + tenmoi + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                sql = "SELECT * FROM loai WHERE name_latinh = N'" + tenmoi + "' AND name_latinh <> N'" + tencu + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenTiengViet.Text == "" && txtTenLatinh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên loài!", "Thông báo",
                        MessageBoxButtons.OK);
                    txtTenTiengViet.Focus();
                    return;
                }
                if (cbFK.SelectedIndex <= 0 || cbFK.SelectedValue == null)
                {
                    MessageBox.Show("Bạn chưa chọn họ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbFK.Focus();
                    return;
                }
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                if (kiemTraTenTrung(ktThem, txtTenLatinh.Text) == true)
                {
                    MessageBox.Show("Tên Latinh bạn nhập đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTenLatinh.Focus();
                    return;
                }
                SqlTransaction transaction = conn.BeginTransaction();               
                try
                {
                    if (ktThem == true)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm loài " + txtTenTiengViet.Text + " không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                        DateTime createdAt = DateTime.Now;
                        SqlCommand cmd = new SqlCommand("InsertLoai", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                        cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                        cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;
                        cmd.Parameters.Add("@id_dtv_ho", SqlDbType.Int).Value = cbFK.SelectedValue;
                        cmd.Parameters.Add("@ten_khac", SqlDbType.NVarChar).Value = txtTenKhac.Text.Trim();
                        cmd.Parameters.Add("@dac_diem", SqlDbType.NVarChar).Value = rtxtDacDiem.Text;
                        cmd.Parameters.Add("@gia_tri_su_dung", SqlDbType.NVarChar).Value = rtxtCongDung.Text;
                        cmd.Parameters.Add("@phan_bo", SqlDbType.NVarChar).Value = txtPhanBo.Text.Trim();
                        cmd.Parameters.Add("@nguon_tai_lieu", SqlDbType.NVarChar).Value = txtNguonTaiLieu.Text.Trim();
                        cmd.Parameters.Add("@muc_do_bao_ton_iucn", SqlDbType.NVarChar).Value = cbIUCN.SelectedIndex == 0 ? "" : cbIUCN.SelectedItem?.ToString();
                        cmd.Parameters.Add("@muc_do_bao_ton_sdvn", SqlDbType.NVarChar).Value = cbSDVN.SelectedIndex == 0 ? "" : cbSDVN.SelectedItem?.ToString();
                        cmd.Parameters.Add("@muc_do_bao_ton_ndcp", SqlDbType.NVarChar).Value = cbNDCP.SelectedIndex == 0 ? "" : cbNDCP.SelectedItem?.ToString();
                        cmd.Parameters.Add("@muc_do_bao_ton_nd64cp  ", SqlDbType.NVarChar).Value = cbND64CP.SelectedIndex == 0 ? "" : cbND64CP.SelectedItem?.ToString();
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = 1;
                        //cmd.Parameters.Add("@status", SqlDbType.Bit).Value = rbtOn.Checked ? 1 : 0;
                        cmd.Parameters.Add("@created_at", SqlDbType.DateTime).Value = createdAt;
                        cmd.Parameters.Add("@created_by", SqlDbType.Int).Value = Int32.Parse(idUser);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        // Lấy id của loài vừa thêm
                        int insertedLoaiId = GetInsertedLoaiId(transaction);
                        // Kiểm tra và tạo thư mục cho loài
                        CreateFolderIfNotExists(insertedLoaiId);
                        // Lưu ảnh vào thư mục của loài
                        SaveImagesToFolder(insertedLoaiId);
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có muốn sửa loài " + tenTiengViet + " không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                        DateTime updatedAt = DateTime.Now;
                        SqlCommand cmd = new SqlCommand("UpdateLoai", conn, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                        cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                        cmd.Parameters.Add("@id_dtv_ho", SqlDbType.Int).Value = cbFK.SelectedValue;
                        cmd.Parameters.Add("@ten_khac", SqlDbType.NVarChar).Value = txtTenKhac.Text.Trim();
                        cmd.Parameters.Add("@dac_diem", SqlDbType.NVarChar).Value = rtxtDacDiem.Text;
                        cmd.Parameters.Add("@gia_tri_su_dung", SqlDbType.NVarChar).Value = rtxtCongDung.Text;
                        cmd.Parameters.Add("@phan_bo", SqlDbType.NVarChar).Value = txtPhanBo.Text.Trim();
                        cmd.Parameters.Add("@nguon_tai_lieu", SqlDbType.NVarChar).Value = txtNguonTaiLieu.Text.Trim();
                        cmd.Parameters.Add("@muc_do_bao_ton_iucn", SqlDbType.NVarChar).Value = cbIUCN.SelectedIndex == 0 ? "" : cbIUCN.SelectedItem?.ToString();
                        cmd.Parameters.Add("@muc_do_bao_ton_sdvn", SqlDbType.NVarChar).Value = cbSDVN.SelectedIndex == 0 ? "" : cbSDVN.SelectedItem?.ToString();
                        cmd.Parameters.Add("@muc_do_bao_ton_ndcp", SqlDbType.NVarChar).Value = cbNDCP.SelectedIndex == 0 ? "" : cbNDCP.SelectedItem?.ToString();
                        cmd.Parameters.Add("@muc_do_bao_ton_nd64cp  ", SqlDbType.NVarChar).Value = cbND64CP.SelectedIndex == 0 ? "" : cbND64CP.SelectedItem?.ToString();
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = 1;
                        cmd.Parameters.Add("@updated_at", SqlDbType.DateTime).Value = updatedAt;
                        cmd.Parameters.Add("@updated_by", SqlDbType.Int).Value = Int32.Parse(idUser);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        // Lấy id của loài
                        int updatedLoaiId = id;
                        // Kiểm tra và tạo thư mục cho loài
                        CreateFolderIfNotExists(updatedLoaiId);
                        // Lưu ảnh vào thư mục của loài
                        SaveImagesToFolder(updatedLoaiId);
                    }
                    //if (ktThem == true && selectedImages.Count > 0)
                    //{
                    //    foreach (string imageName in selectedImages)
                    //    {
                    //        string sql = "INSERT INTO HinhAnhLoai (id_dtv_loai, hinhanh) VALUES((SELECT MAX(id) FROM Loai), @hinhanh)";
                    //        SqlCommand cmd = new SqlCommand(sql, conn);
                    //        cmd.Parameters.Add("@hinhanh", SqlDbType.NVarChar).Value = imageName;

                    //        cmd.ExecuteNonQuery();
                    //        cmd.Dispose();
                    //    }
                    //}
                    //else
                    //{
                    //    sql = "DELETE FROM HinhAnhLoai WHERE id_dtv_loai = @id_dtv_loai";
                    //    SqlCommand deleteCmd = new SqlCommand(sql, conn);
                    //    deleteCmd.Parameters.AddWithValue("@id_dtv_loai", id);
                    //    deleteCmd.ExecuteNonQuery();
                    //    deleteCmd.Dispose();

                    //    foreach (string imageName in selectedImages)
                    //    {
                    //        // Thực hiện việc lưu imageData vào cơ sở dữ liệu cho loài tương ứng
                    //        sql = "INSERT INTO HinhAnhLoai (id_dtv_loai, hinhanh) VALUES (@id_dtv_loai, @hinhanh)";
                    //        SqlCommand cmd = new SqlCommand(sql, conn);
                    //        cmd.Parameters.AddWithValue("@id_dtv_loai", id);
                    //        cmd.Parameters.AddWithValue("@hinhanh", imageName);

                    //        cmd.ExecuteNonQuery();
                    //        cmd.Dispose();
                    //    }
                    //}
                    transaction.Commit();

                    selectedImages.Clear();
                    xoaTrang(true);
                    loadDGV?.Invoke();
                    this.Dispose();
                    if (imageDel == true)
                        xoaAnh();
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi
                    transaction.Rollback();
                    throw new Exception("Lỗi trong quá trình thực hiện truy vấn: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private int GetInsertedLoaiId(SqlTransaction transaction)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string sql = "SELECT MAX(id) FROM Loai";
            SqlCommand cmd = new SqlCommand(sql, conn, transaction);
            int insertedLoaiId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            return insertedLoaiId;
        }

        private void CreateFolderIfNotExists(int loaiId)
        {
            string loaiFolderPath = pictureFolder + "\\" + loaiId.ToString();

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(loaiFolderPath))
            {
                Directory.CreateDirectory(loaiFolderPath);
            }
        }

        private void SaveImagesToFolder(int loaiId)
        {
            foreach (string sourceImagePath in selectedImages)
            {
                // Lấy tên của ảnh từ đường dẫn
                string imageName = Path.GetFileName(sourceImagePath);
                //string sourceImagePath = pictureFolder + "\\" + imageName;
                string destinationImagePath = pictureFolder + "\\" + loaiId.ToString() + "\\" + imageName;

                // Kiểm tra và chuyển ảnh vào thư mục của loài
                if (!File.Exists(destinationImagePath))
                {
                    File.Copy(sourceImagePath, destinationImagePath);
                }
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //// Kiểm tra và tạo thư mục nếu chưa tồn tại
                //if (!Directory.Exists(pictureFolder))
                //{
                //    Directory.CreateDirectory(pictureFolder);
                //}

                foreach (string fileName in openFileDialog.FileNames)
                {
                    //// Lấy tên của ảnh từ đường dẫn
                    //string imageName = Path.GetFileName(fileName);
                    //// Kiểm tra xem ảnh đã tồn tại trong thư mục cấu hình chưa
                    //string imagePath = pictureFolder + "\\" + imageName;
                    //if (!File.Exists(imagePath))
                    //{
                    //    // Nếu chưa tồn tại thì copy ảnh vào thư mục cấu hình
                    //    File.Copy(fileName, imagePath);
                    //}
                    // Thêm đường dẫn của ảnh đã chọn vào danh sách
                    selectedImages.Add(fileName);
                }

                DisplayImages();
                MessageBox.Show("Đã chọn " + openFileDialog.FileNames.Length + " ảnh.");
            }
        }

        //private void btChonAnh_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Multiselect = true;
        //    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
        //    openFileDialog.InitialDirectory = imageFolder;

        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        foreach (string fileName in openFileDialog.FileNames)
        //        {
        //            string imagePath = GenerateImagePath(Path.GetFileName(fileName));
        //            selectedImages.Add(imagePath);
        //        }
        //        DisplayImages();
        //        MessageBox.Show("Đã chọn " + openFileDialog.FileNames.Length + " ảnh.");
        //    }
        //}

        private void btXoaAnh_Click(object sender, EventArgs e)
        {
            fpnlHinhAnh.Controls.Clear();
            selectedImages.Clear();
            DisplayImages();
            imageDel = true;
        }

        private async void xoaAnh()
        {
            await Task.Delay(5000); // Chờ 3 giây trước khi thực hiện xóa

            try
            {
                if (ktThem == false)
                {
                    // Lấy tất cả các đường dẫn file trong thư mục
                    string[] allFiles = Directory.GetFiles(pictureFolder + "\\" + id.ToString());
                    // Lọc ra các file ảnh
                    string[] imageExtensions = { ".jpg", ".jpeg", ".png" };

                    foreach (string filePath in allFiles)
                    {
                        string extension = Path.GetExtension(filePath).ToLower();

                        if (Array.Exists(imageExtensions, ie => ie == extension))
                        {
                            // Thử lại việc xóa nếu gặp lỗi
                            int retryCount = 0;
                            const int maxRetries = 3;
                            const int delayMilliseconds = 1000;

                            while (retryCount < maxRetries)
                            {
                                try
                                {
                                    File.Delete(filePath); // Xóa file ảnh
                                    break; // Thoát khỏi vòng lặp nếu xóa thành công
                                }
                                catch (IOException ex)
                                {
                                    // Nếu xảy ra lỗi, hiển thị thông báo và chờ một khoảng thời gian trước khi thử lại
                                    //MessageBox.Show($"Lỗi khi xóa file (lần thử {retryCount + 1}/{maxRetries}): {ex.Message}");
                                    retryCount++;
                                    Thread.Sleep(delayMilliseconds);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa file: " + ex.Message);
            }
        }
    }
}
