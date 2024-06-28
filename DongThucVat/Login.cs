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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class Login : Form
    {
        SqlConnection conn;
        string sql = "";
        string id, name, is_admin;
        string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            // Thực hiện kiểm tra kết nối
            if (CheckDatabaseConnection() == false)
            {
                if (MessageBox.Show("Lỗi kết nối tới CSDL. Vui lòng kiểm tra cài đặt kết nối.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    Application.Exit();
                return;
            }
            loadLogo();
            loadTieuDe();
            txtEmail.Focus();
        }

        private bool CheckDatabaseConnection()
        {
            try
            {
                if (conn == null)
                    return false;
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                return true; // Kết nối thành công
            }
            catch
            {
                return false; // Kết nối không thành công
            }
        }

        public void loadLogo()
        {
            // Kiểm tra kết nối
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT logo FROM ThongTin WHERE id = " + 1;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);
            // Lấy giá trị từ dòng đầu tiên của DataTable
            string logo = dt.Rows[0]["logo"].ToString();
            try
            {
                if (logo != null && File.Exists(pictureFolder + "\\" + logo))
                {
                    pbLogo.Image = null;
                    pbLogo.Image = Image.FromFile(pictureFolder + "\\" + logo);
                    pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    pbLogo1.Image = null;
                    pbLogo1.Image = Image.FromFile(pictureFolder + "\\" + logo);
                    pbLogo1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void loadTieuDe()
        {
            // Kiểm tra kết nối
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT tieude FROM ThongTin WHERE id = " + 1;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);
            // Lấy giá trị từ dòng đầu tiên của DataTable
            lbTieuDe.Text = dt.Rows[0]["tieude"].ToString();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbQuenMatKhau_Click(object sender, EventArgs e)
        {
            {
                using (frmQuenMatKhau frm = new frmQuenMatKhau())
                {
                    frm.ShowDialog();
                }
            }
        }

        private void btMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                performLogin();
            }
        }

        private void performLogin()
        {
            // Kiem tra du lieu nhap
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng điền email và password để đăng nhập.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
                return;
            }

            if (loginCheck() == false)
            {
                MessageBox.Show("Email hoặc password không chính xác.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
                return;
            }
            else
            {
                this.Hide();
                using (frmHome frm = new frmHome())
                {
                    frm.idHome = id;// Truyền vào thuộc tính idHome của form Home
                    frm.nameHome = name;// Truyền vào thuộc tính first_name_Home
                    frm.is_adminHome = is_admin;// Truyền vào thuộc tính is_admin_Home

                    frm.ShowDialog();
                }
                this.Dispose();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                performLogin();
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            performLogin();
        }

        public bool loginCheck()
        {
            // Kiểm tra kết nối
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM [user] WHERE email = @Email AND password = @Password AND status = 1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text.Trim();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Lấy giá trị từ dòng đầu tiên của DataTable
                id = dt.Rows[0]["id"].ToString();
                name = dt.Rows[0]["name"].ToString();
                is_admin = dt.Rows[0]["is_admin"].ToString();
                return true;
            }
            else
                return false;
        }
    }
}
