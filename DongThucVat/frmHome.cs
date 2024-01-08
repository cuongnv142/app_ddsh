using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace DongThucVat
{

    public partial class frmHome : Form
    {
        SqlConnection conn;
        string sql;
        static frmHome _obj;
        public bool isClose = true;
        string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];

        public event Action LogoChanged;

        private string id;
        private string name;
        private string is_admin;
        public string idHome//Đọc, ghi biến nhận từ form trước
        {
            get { return id; }
            set { id = value; }
        }
        public string nameHome
        {
            get { return name; }
            set { name = value; }
        }
        public string is_adminHome
        {
            get { return is_admin; }
            set { is_admin = value; }
        }

        public static frmHome Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmHome();
                }
                return _obj;
            }
        }

        public Panel pnlControl
        {
            get { return panelControl; }
            set { panelControl = value; }
        }

        public Button buttonBack
        {
            get { return btBack; }
            set { btBack = value; }
        }
        
        public Label tieuDe
        {
            get { return lbTieuDe; }
            set { lbTieuDe = value; }
        }

        public frmHome()
        {
            InitializeComponent();
            timerTime.Start();
            ucGioiThieu uc = new ucGioiThieu();
            AddControlsToPanel(uc);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            saveLastSigninedTime();
            if (isClose == true)
                Application.Exit();
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(c);
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lbTime.Text = dt.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btHome);
            ucHome uc = new ucHome();
            AddControlsToPanel(uc);
            btBack.Visible = false;
            lbTieuDe.Visible = true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUsers);
            if (Boolean.Parse(is_admin) == true)
            {
                ucUser uc = new ucUser();
                AddControlsToPanel(uc);
            }
            if (Boolean.Parse(is_admin) == false)
            {
                ucUserInfo uc = new ucUserInfo();
                uc.Id = Int32.Parse(id);
                AddControlsToPanel(uc);
            }
            btBack.Visible = false;
            lbTieuDe.Visible = true;
        }

        private void btDongVat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btDongVat);
            ucChon uc = new ucChon();
            uc.idChon = id;
            uc.loaiChon = 0;// Truyền vào thuộc tính của form tiếp theo
            AddControlsToPanel(uc);
            btBack.Visible = false;
            lbTieuDe.Visible = true;
        }

        public void loadTieuDe()
        {
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

        private void frmHome_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            lbFirstName.Text = name + ".";
            if (Boolean.Parse(is_admin) == true)
                lbRole.Text = "Admin.";
            if (Boolean.Parse(is_admin) == false)
            {
                lbRole.Text = "Nhân viên.";
            }
            loadLogo();
            loadTieuDe();

            moveSidePanel(btHome);
            ucGioiThieu uc = new ucGioiThieu();
            AddControlsToPanel(uc);

            btBack.Visible = false;
            lbTieuDe.Visible = true;
            _obj = this;
        }

        public void loadLogo()
        {
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
            pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];
            string logo = dt.Rows[0]["logo"].ToString();
            try
            {
                if (logo != null && File.Exists(pictureFolder + "\\" + logo))
                {
                    pbLogo.Image = null;
                    pbLogo.Image = Image.FromFile(pictureFolder + "\\" + logo);
                    pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            panelControl.Controls["ucChon"].BringToFront();
            btBack.Visible = false;
            lbTieuDe.Visible = true;
        }

        private void btThucVat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btThucVat);
            ucChon uc = new ucChon();
            uc.idChon = id;
            uc.loaiChon = 1;// Truyền vào thuộc tính của form tiếp theo
            AddControlsToPanel(uc);
            btBack.Visible = false;
            lbTieuDe.Visible = true;
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            moveSidePanel(btSettings);
            ucSetting uc = new ucSetting();
            uc.LogoChanged += loadLogo;
            AddControlsToPanel(uc);
            btBack.Visible = false;
            lbTieuDe.Visible = true;
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            isClose = false;
            this.Dispose();
            saveLastSigninedTime();
            using (Login frm = new Login())
            {
                frm.ShowDialog();
            }
        }

        public void saveLastSigninedTime()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DateTime lastSigninedTime = DateTime.Now;
            sql = "UPDATE [user] SET last_signined_time = @LastSigninedTime WHERE id = " + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@LastSigninedTime", SqlDbType.DateTime).Value = lastSigninedTime;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClose == true)
                Application.Exit();
        }

        private void btMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbTime_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            moveSidePanel(btThongKe);
            ucThongKe uc = new ucThongKe();
            AddControlsToPanel(uc);
            btBack.Visible = false;
            lbTieuDe.Visible = true;
        }
    }
}
