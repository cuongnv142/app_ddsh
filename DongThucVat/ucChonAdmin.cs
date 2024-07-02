using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class ucChonAdmin : UserControl
    {
        private string id;

        public string idChonAdmin// Đọc, ghi biến nhận từ form trước
        {
            get { return id; }
            set { id = value; }
        }

        public ucChonAdmin()
        {
            InitializeComponent();
        }

        private void btQL_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucUser"))
            {
                ucUser uc = new ucUser();
                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucUser"].BringToFront();
        }

        private void btDMK_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucUserInfo"))
            {
                ucUserInfo uc = new ucUserInfo();
                uc.Id = id;

                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucUserInfo"].BringToFront();
        }
    }
}
