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
    public partial class frmDoiMatKhau : Form
    {
        SqlConnection conn;
        string sql = "";

        private string id;
        public string Id { get => id; set => id = value; }

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLaiMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                txtMatKhauCu.Focus();
            }
            if (txtMatKhauMoi.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa chính xác!", "Thông báo", MessageBoxButtons.OK);
                txtNhapLaiMatKhau.Focus();
            }
            if (passwordCheck() == false)
            {
                MessageBox.Show("Mật khẩu cũ chưa chính xác!", "Thông báo", MessageBoxButtons.OK);
                txtMatKhauCu.Focus();
            }
            if (passwordCheck() == true && txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sql = "UPDATE [user] SET password = @Password WHERE id = @id AND password = @PasswordCu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtMatKhauMoi.Text.Trim();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(id);
                cmd.Parameters.Add("@PasswordCu", SqlDbType.NVarChar).Value = txtMatKhauCu.Text.Trim();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);
                this.Dispose();
            }
        }

        public bool passwordCheck()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM [user] WHERE id = @id AND password = @Password";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(id);
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtMatKhauCu.Text.Trim();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.UseSystemPasswordChar == true)
            {
                txtMatKhauMoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauMoi.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMatKhau.UseSystemPasswordChar == true)
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.UseSystemPasswordChar == true)
            {
                txtMatKhauCu.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauCu.UseSystemPasswordChar = true;
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
        }
    }
}
