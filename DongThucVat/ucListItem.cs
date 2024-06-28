using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class ucListItem : UserControl
    {
        public event EventHandler ItemClick;

        public ucListItem()
        {
            InitializeComponent();
        }

        private void OnItemClick(EventArgs e)
        {
            ItemClick?.Invoke(this, e);
        }

        private void ucListItem_DoubleClick(object sender, EventArgs e)
        {
            OnItemClick(EventArgs.Empty);
        }

        private void ucListItem_Click(object sender, EventArgs e)
        {
            //OnItemClick(EventArgs.Empty);
        }

        #region Properties
        private string _tenloai, _ho, _bo, _lop, _nganh, _anh, _id;
        private int _stt;
        [Category("Custom Props")]
        public string Tenloai
        {
            get { return _tenloai; }
            set { _tenloai = value; lbTenLoai.Text = value; }
        }
        [Category("Custom Props")]
        public string Ho
        {
            get { return _ho; }
            set { _ho = value; lbHo.Text = value; }
        }

        [Category("Custom Props")]
        public string Bo
        {
            get { return _bo; }
            set { _bo = value; lbBo.Text = value; }
        }
        [Category("Custom Props")]
        public string Lop
        {
            get { return _lop; }
            set { _lop = value; lbLop.Text = value; }
        }

        [Category("Custom Props")]
        public string Nganh
        {
            get { return _nganh; }
            set { _nganh = value; lbNganh.Text = value; }
        }
        [Category("Custom Props")]
        public string Anh
        {
            get { return _anh; }
            set
            {
                _anh = value;
                if (value != null && File.Exists(value))
                {
                    pbLoai.Image = Image.FromFile(value);
                }
            }
        }
        [Category("Custom Props")]
        public int Stt
        {
            get { return _stt; }
            set { _stt = value; lbSTT.Text = lbSTT.Text = $"{value}."; }
        }
        [Category("Custom Props")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion


        private void ucListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void ucListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        //private void SetImage(string imagePath)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
        //        {
        //            pbLoai.Image = Image.FromFile(imagePath);
        //        }
        //        else
        //        {
        //            // Xử lý khi không tìm thấy hình ảnh
        //            string defaultImage = @"picture\Image File.png";
        //            string defaultImagePath = Path.Combine(Application.StartupPath, defaultImage);
        //            pbLoai.Image = Image.FromFile(defaultImagePath);
        //            MessageBox.Show("Không tìm thấy hình ảnh!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //}
    }
}
