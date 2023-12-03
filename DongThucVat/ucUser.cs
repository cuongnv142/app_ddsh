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
    public partial class ucUser : UserControl
    {
        SqlConnection conn;
        string sql = "";
        DataGridViewCellMouseEventArgs vitri;
        bool ktThem;
        string macu;

        public ucUser()
        {
            InitializeComponent();
            groupBox1.ForeColor = Color.FromArgb(255, 0, 127, 24);
            groupBox2.ForeColor = Color.FromArgb(255, 0, 127, 24);

            /*
            // Tạo datasource
            DataTable dt = new DataTable();
            dt.Columns.Add("DisplayMember", typeof(string));
            dt.Columns.Add("TValueMember", typeof(string));

            // Thêm dữ liệu vào datasource
            dt.Rows.Add("--Chọn giới tính--", "");
            dt.Rows.Add("Nam", "Nam");
            dt.Rows.Add("Nữ", "Nữ");
            dt.Rows.Add("Khác", "Khác");

            // Thiết lập DisplayMember và ValueMember
            cbGioiTinh.DisplayMember = "DisplayMember";
            cbGioiTinh.ValueMember = "ValueMember";

            // Gán datasource cho combobox
            cbGioiTinh.DataSource = dt;
            */

        }

        private void ucUser_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            xoaTrang();
            khoaMo(true);
            dgvLoad();
        }

        public void khoaMo(bool b)
        {
            dgv.Enabled = b;

            cbGioiTinh.Enabled = !b;
            txtHoTen.ReadOnly = b;
            txtEmail.ReadOnly = b;
            txtSDT.ReadOnly = b;
            txtPassword.ReadOnly = b;
            txtDiaChi.ReadOnly = b;
            rbtAdmin.Enabled = !b;
            rbtNV.Enabled = !b;
            rbtOn.Enabled = !b;
            rbtOff.Enabled = !b;
            dtpNgaySinh.Enabled = !b;

            btThem.Enabled = b;
            btSua.Enabled = b;
            btXoa.Enabled = b;

            btHuy.Enabled = !b;
            btLuu.Enabled = !b;
        }

        public void xoaTrang()
        {
            cbGioiTinh.SelectedIndex = 0;
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtPassword.Text = "";
            txtDiaChi.Text = "";
            rbtAdmin.Checked = false;
            rbtNV.Checked = true;
            rbtOn.Checked = false;
            rbtOff.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            macu = "";
        }

        public void dgvLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM [user]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daDGV = new SqlDataAdapter();
            daDGV.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtDGV = new DataTable();
            daDGV.Fill(dtDGV);

            dgv.DataSource = dtDGV;
            dgv.Refresh();
        }

        private void btHuy_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Chọn lại ví trí sửa
                if (vitri != null)
                {
                    dgv_CellMouseClick_1(sender, vitri);
                }
                else xoaTrang();
                khoaMo(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
                return;
            }
            if (ktThem == true)
            {
                DateTime createdAt = DateTime.Now;
                sql = "INSERT INTO [user] (address, name, password, email, phone, gender, dob, created_at, is_admin, status) VALUES (N'" + txtDiaChi.Text.Trim() + "', N'" + txtHoTen.Text.Trim() + "', N'" + txtPassword.Text.Trim() + "', N'" + txtEmail.Text.Trim() + "', N'" + txtSDT.Text.Trim() + "', " + cbGioiTinh.SelectedItem.ToString() + ", N'" + DateTime.Parse(dtpNgaySinh.Value.ToString("yyyy/MM/dd")) + "', N'" + createdAt + "', " + (rbtAdmin.Checked == true ? 1 : 0) + ", " + (rbtOn.Checked == true ? 1 : 0) + ")";

            }
            else
            {
                DateTime updatedAt = DateTime.Now;
                sql = "UPDATE [user] SET name = N'" + txtHoTen.Text.Trim() + "', password = N'" + txtPassword.Text.Trim() + "', email = N'" + txtEmail.Text.Trim() + "', phone = N'" + txtSDT.Text.Trim() + "', gender = N'" + cbGioiTinh.SelectedItem.ToString() + "', dob = '" + DateTime.Parse(dtpNgaySinh.Value.ToString("yyyy/MM/dd")) + "', updated_at = '" + updatedAt + "', is_admin = " + (rbtAdmin.Checked == true ? 1 : 0) + ", status = " + (rbtOn.Checked == true ? 1 : 0) + " WHERE id = " + Int32.Parse(macu);
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            xoaTrang();
            khoaMo(true);
            dgvLoad();
            vitri = null;
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            ktThem = true;
            xoaTrang();
            khoaMo(false);
            txtHoTen.Focus();
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            if ((txtEmail.Text == "" && txtPassword.Text == "") || macu == "")
            {
                MessageBox.Show("Bạn chưa chọn người dùng!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ktThem = false;
            khoaMo(false);
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            if ((txtEmail.Text == "" && txtPassword.Text == "") || macu == "")
            {
                MessageBox.Show("Bạn chưa chọn người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (macu != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa người dùng " + txtHoTen.Text + " không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    sql = "DELETE FROM [user] WHERE id = " + Int32.Parse(macu.Trim());
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();

                    xoaTrang();
                    dgvLoad();
                    vitri = null;
                }
            }
        }

        private void dgv_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        vitri = e;
                        DataGridViewRow row = dgv.Rows[e.RowIndex];
                        macu = row.Cells[0].Value.ToString();
                        txtDiaChi.Text = row.Cells[1].Value.ToString();
                        txtHoTen.Text = row.Cells[2].Value.ToString();
                        txtPassword.Text = row.Cells[3].Value.ToString();
                        txtEmail.Text = row.Cells[4].Value.ToString();
                        txtSDT.Text = row.Cells[5].Value.ToString();
                        cbGioiTinh.SelectedItem = row.Cells[7].Value.ToString();
                        dtpNgaySinh.Value = DateTime.Parse(row.Cells[8].Value.ToString());
                        if (Boolean.Parse(row.Cells[12].Value.ToString()) == true)
                            rbtAdmin.Checked = true;
                        if (Boolean.Parse(row.Cells[12].Value.ToString()) == false)
                            rbtNV.Checked = true;
                        if (Boolean.Parse(row.Cells[13].Value.ToString()) == true)
                            rbtOn.Checked = true;
                        if (Boolean.Parse(row.Cells[13].Value.ToString()) == false)
                            rbtOff.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
