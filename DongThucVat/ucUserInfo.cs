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
    public partial class ucUserInfo : UserControl
    {
        SqlConnection conn;
        string sql = "";

        private int id;
        public int Id { get => id; set => id = value; }

        public ucUserInfo()
        {
            InitializeComponent();
        }

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau frm = new frmDoiMatKhau())
            {
                frm.Id = id;
                frm.ShowDialog();
            }
        }

        private void ucSettings_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            khoaMo(true);
            loadThongTin();
        }

        public void khoaMo(bool b)
        {
            btDoiMatKhau.Visible = b;
            btSuaThongTin.Visible = b;

            btLuu.Visible = !b;
            btHuy.Visible = !b;

            txtHoTen.ReadOnly = b;
            txtEmail.ReadOnly = b;
            txtSDT.ReadOnly = b;
            txtDiaChi.ReadOnly = b;
            dtpNgaySinh.Enabled = !b;
            cbGioiTinh.Enabled = !b;
        }

        public void loadThongTin()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM [user] WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Lấy giá trị từ dòng đầu tiên của DataTable
                txtHoTen.Text = dt.Rows[0]["name"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                txtSDT.Text = dt.Rows[0]["phone"].ToString();
                txtDiaChi.Text = dt.Rows[0]["address"].ToString();
                cbGioiTinh.SelectedItem = dt.Rows[0]["gender"].ToString();
                dtpNgaySinh.Value = DateTime.Parse(dt.Rows[0]["dob"].ToString());
            }
            cmd.Dispose();
            conn.Close();
        }

        private void btDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            using (frmDoiMatKhau frm = new frmDoiMatKhau())
            {
                frm.Id = id;
                frm.ShowDialog();
            }
        }

        private void btSuaThongTin_Click(object sender, EventArgs e)
        {
            khoaMo(false);
        }

        private void btHuy_Click_1(object sender, EventArgs e)
        {
            khoaMo(true);
            loadThongTin();
        }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Không được bỏ trống email!", "Thông báo", MessageBoxButtons.OK);
                txtEmail.Focus();
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "UPDATE [user] SET name = @Name, email = @Email, phone = @Phone, gender = @Gender, dob = @DOB, address = @Address WHERE id = @ID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtHoTen.Text.Trim();
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = txtSDT.Text.Trim();
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = cbGioiTinh.SelectedIndex == 0 ? "" : cbGioiTinh.SelectedItem.ToString();
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DateTime.Parse(dtpNgaySinh.Value.ToString("yyyy/MM/dd"));
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtDiaChi.Text.Trim();
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = id;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            khoaMo(true);
            loadThongTin();
        }
    }
}
