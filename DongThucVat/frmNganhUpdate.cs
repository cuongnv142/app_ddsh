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
    public partial class frmNganhUpdate : Form
    {
        SqlConnection conn;
        string sql = "";
        public event Action loadDGV;

        private string idUser, tenTiengViet, tenLatinh, status;
        private int id, loai;
        private bool ktThem;
        public bool ktThemNganhUpdate
        {
            get { return ktThem; }
            set { ktThem = value; }
        }
        public string idUserNganhUpdate
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public int idNganhUpdate
        {
            get { return id; }
            set { id = value; }
        }
        public int loaiNganhUpdate
        {
            get { return loai; }
            set { loai = value; }
        }
        public string tenTiengVietNganhUpdate
        {
            get { return tenTiengViet; }
            set { tenTiengViet = value; }
        }
        public string tenLatinhNganhUpdate
        {
            get { return tenLatinh; }
            set { tenLatinh = value; }
        }
        public string statusNganhUpdate
        {
            get { return status; }
            set { status = value; }
        }

        public void xoaTrang(bool b)
        {
            txtTenTiengViet.Text = "";
            txtTenLatinh.Text = "";
            //rbtOn.Checked = false;
            //rbtOff.Checked = true;
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public bool kiemTraTenTrung(bool ktThem, string tenmoi)
        {
            if (ktThem == true)
            {
                sql = "SELECT * FROM nganh WHERE name_latinh = N'" + tenmoi + "'";
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
                sql = "SELECT * FROM nganh WHERE name_latinh = N'" + tenmoi + "' AND name_latinh <> N'" + tenLatinh + "'";
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
            if (txtTenTiengViet.Text == "" && txtTenLatinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ngành!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTenTiengViet.Focus();
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
            if (ktThem == true)
            {
                if (MessageBox.Show("Bạn có muốn thêm ngành " + txtTenTiengViet.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime createdAt = DateTime.Now;
                SqlCommand cmd = new SqlCommand("InsertNganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@created_at", SqlDbType.DateTime).Value = createdAt;
                cmd.Parameters.Add("@created_by", SqlDbType.Int).Value = Int32.Parse(idUser);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa ngành " + tenTiengViet + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime updatedAt = DateTime.Now;
                SqlCommand cmd = new SqlCommand("UpdateNganh", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@updated_at", SqlDbType.DateTime).Value = updatedAt;
                cmd.Parameters.Add("@updated_by", SqlDbType.Int).Value = Int32.Parse(idUser);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            conn.Close();
            loadDGV?.Invoke();

            xoaTrang(true);
            this.Dispose();
        }

        private void frmNganhUpdate_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            xoaTrang(ktThem);
            if (loai == 0)
                lbNganh.Text = "NGÀNH ĐỘNG VẬT";
            if (loai == 1)
                lbNganh.Text = "NGÀNH THỰC VẬT";
            txtTenTiengViet.Text = tenTiengViet;
            txtTenLatinh.Text = tenLatinh;
            //if (status != null)
            //{
            //    if (Boolean.Parse(status) == true)
            //        rbtOn.Checked = true;
            //    if (Boolean.Parse(status) == false)
            //        rbtOff.Checked = true;
            //}
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public frmNganhUpdate()
        {
            InitializeComponent();
        }
    }
}
