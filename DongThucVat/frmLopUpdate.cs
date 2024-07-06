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
    public partial class frmLopUpdate : Form
    {
        SqlConnection conn;
        string sql = "";
        public event Action loadDGV;

        private string idUser, tenTiengViet, tenLatinh, status;
        private int id, idFK, loai;
        private bool ktThem;
        public bool ktThemLopUpdate
        {
            get { return ktThem; }
            set { ktThem = value; }
        }
        public string idUserLopUpdate
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public int idLopUpdate
        {
            get { return id; }
            set { id = value; }
        }
        public int idFKLopUpdate
        {
            get { return idFK; }
            set { idFK = value; }
        }
        public int loaiLopUpdate
        {
            get { return loai; }
            set { loai = value; }
        }
        public string tenTiengVietLopUpdate
        {
            get { return tenTiengViet; }
            set { tenTiengViet = value; }
        }
        public string tenLatinhLopUpdate
        {
            get { return tenLatinh; }
            set { tenLatinh = value; }
        }
        public string statusLopUpdate
        {
            get { return status; }
            set { status = value; }
        }
        public frmLopUpdate()
        {
            InitializeComponent();
        }

        private void frmLopUpdate_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            xoaTrang(ktThem);
            if (loai == 0)
                lbNganh.Text = "LỚP ĐỘNG VẬT";
            if (loai == 1)
                lbNganh.Text = "LỚP THỰC VẬT";
            txtTenTiengViet.Text = tenTiengViet;
            txtTenLatinh.Text = tenLatinh;
            cb.SelectedValue = idFK;
            //if (status != null)
            //{
            //    if (Boolean.Parse(status) == true)
            //        rbtOn.Checked = true;
            //    if (Boolean.Parse(status) == false)
            //        rbtOff.Checked = true;
            //}
        }

        public void cbLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT id, name FROM Nganh WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daCB = new SqlDataAdapter();
            daCB.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtCB = new DataTable();
            daCB.Fill(dtCB);

            DataRow r = dtCB.NewRow();
            r["name"] = "--Chọn ngành--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cb.DataSource = dtCB;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
        }

        public void xoaTrang(bool b)
        {
            txtTenTiengViet.Text = "";
            txtTenLatinh.Text = "";
            //rbtOn.Checked = false;
            //rbtOff.Checked = true;
            cbLoad();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public bool kiemTraTenTrung(bool ktThem, string tenmoi)
        {
            if (ktThem == true)
            {
                sql = "SELECT * FROM lop WHERE name_latinh = N'" + tenmoi + "'";
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
                sql = "SELECT * FROM lop WHERE name_latinh = N'" + tenmoi + "' AND name_latinh <> N'" + tenLatinh + "'";
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
                MessageBox.Show("Bạn chưa nhập tên lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTenTiengViet.Focus();
                return;
            }
            if (cb.SelectedIndex <= 0)
            {
                MessageBox.Show("Bạn chưa chọn ngành!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb.Focus();
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
                if (MessageBox.Show("Bạn có muốn thêm lớp " + txtTenTiengViet.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime createdAt = DateTime.Now;
                SqlCommand cmd = new SqlCommand("InsertLop", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;
                cmd.Parameters.Add("@id_dtv_nganh", SqlDbType.Int).Value = cb.SelectedValue;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@created_at", SqlDbType.DateTime).Value = createdAt;
                cmd.Parameters.Add("@created_by", SqlDbType.Int).Value = Int32.Parse(idUser);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa lớp " + tenTiengViet + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime updatedAt = DateTime.Now;
                SqlCommand cmd = new SqlCommand("UpdateLop", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                cmd.Parameters.Add("@id_dtv_nganh", SqlDbType.Int).Value = Int32.Parse(cb.SelectedValue.ToString());
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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
