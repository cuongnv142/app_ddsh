
namespace DongThucVat
{
    partial class ucThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.btExportChiTiet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.btExportTongQuan = new System.Windows.Forms.Button();
            this.btExportTongQuanDongVat = new System.Windows.Forms.Button();
            this.btExportTongQuanThucVat = new System.Windows.Forms.Button();
            this.btExportChiTietThucVat = new System.Windows.Forms.Button();
            this.btExportChiTietDongVat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(439, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 32);
            this.label2.TabIndex = 57;
            this.label2.Text = "THỐNG KÊ DỮ LIỆU";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btExportChiTietThucVat);
            this.groupBox1.Controls.Add(this.lbThongBao);
            this.groupBox1.Controls.Add(this.btExportChiTietDongVat);
            this.groupBox1.Controls.Add(this.btExportChiTiet);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(207, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 146);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê chi tiết";
            // 
            // lbThongBao
            // 
            this.lbThongBao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbThongBao.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.Location = new System.Drawing.Point(119, 43);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(373, 25);
            this.lbThongBao.TabIndex = 62;
            this.lbThongBao.Text = ".";
            // 
            // btExportChiTiet
            // 
            this.btExportChiTiet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExportChiTiet.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportChiTiet.Location = new System.Drawing.Point(120, 85);
            this.btExportChiTiet.Name = "btExportChiTiet";
            this.btExportChiTiet.Size = new System.Drawing.Size(123, 41);
            this.btExportChiTiet.TabIndex = 61;
            this.btExportChiTiet.Text = "Xuất file";
            this.btExportChiTiet.UseVisualStyleBackColor = true;
            this.btExportChiTiet.Click += new System.EventHandler(this.btExportChiTiet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btExportTongQuanThucVat);
            this.groupBox2.Controls.Add(this.btExportTongQuanDongVat);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTimePickerFrom);
            this.groupBox2.Controls.Add(this.dateTimePickerTo);
            this.groupBox2.Controls.Add(this.btExportTongQuan);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(207, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 155);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê tổng quan";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(393, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 64;
            this.label3.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 63;
            this.label1.Text = "Từ ngày:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(120, 44);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(220, 33);
            this.dateTimePickerFrom.TabIndex = 62;
            this.dateTimePickerFrom.Value = new System.DateTime(2023, 12, 3, 19, 16, 41, 0);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerTo.CalendarFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(498, 44);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(220, 33);
            this.dateTimePickerTo.TabIndex = 61;
            this.dateTimePickerTo.Value = new System.DateTime(2023, 12, 3, 19, 16, 41, 0);
            // 
            // btExportTongQuan
            // 
            this.btExportTongQuan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExportTongQuan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportTongQuan.Location = new System.Drawing.Point(120, 94);
            this.btExportTongQuan.Name = "btExportTongQuan";
            this.btExportTongQuan.Size = new System.Drawing.Size(123, 41);
            this.btExportTongQuan.TabIndex = 60;
            this.btExportTongQuan.Text = "Xuất file";
            this.btExportTongQuan.UseVisualStyleBackColor = true;
            this.btExportTongQuan.Click += new System.EventHandler(this.btExportTongQuan_Click_1);
            // 
            // btExportTongQuanDongVat
            // 
            this.btExportTongQuanDongVat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExportTongQuanDongVat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportTongQuanDongVat.Location = new System.Drawing.Point(279, 94);
            this.btExportTongQuanDongVat.Name = "btExportTongQuanDongVat";
            this.btExportTongQuanDongVat.Size = new System.Drawing.Size(200, 41);
            this.btExportTongQuanDongVat.TabIndex = 65;
            this.btExportTongQuanDongVat.Text = "Xuất file động vật";
            this.btExportTongQuanDongVat.UseVisualStyleBackColor = true;
            this.btExportTongQuanDongVat.Click += new System.EventHandler(this.btExportTongQuanDongVat_Click);
            // 
            // btExportTongQuanThucVat
            // 
            this.btExportTongQuanThucVat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExportTongQuanThucVat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportTongQuanThucVat.Location = new System.Drawing.Point(515, 94);
            this.btExportTongQuanThucVat.Name = "btExportTongQuanThucVat";
            this.btExportTongQuanThucVat.Size = new System.Drawing.Size(200, 41);
            this.btExportTongQuanThucVat.TabIndex = 66;
            this.btExportTongQuanThucVat.Text = "Xuất file thực vật";
            this.btExportTongQuanThucVat.UseVisualStyleBackColor = true;
            this.btExportTongQuanThucVat.Click += new System.EventHandler(this.btExportTongQuanThucVat_Click);
            // 
            // btExportChiTietThucVat
            // 
            this.btExportChiTietThucVat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExportChiTietThucVat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportChiTietThucVat.Location = new System.Drawing.Point(515, 85);
            this.btExportChiTietThucVat.Name = "btExportChiTietThucVat";
            this.btExportChiTietThucVat.Size = new System.Drawing.Size(200, 41);
            this.btExportChiTietThucVat.TabIndex = 68;
            this.btExportChiTietThucVat.Text = "Xuất file thực vật";
            this.btExportChiTietThucVat.UseVisualStyleBackColor = true;
            this.btExportChiTietThucVat.Click += new System.EventHandler(this.btExportChiTietThucVat_Click);
            // 
            // btExportChiTietDongVat
            // 
            this.btExportChiTietDongVat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExportChiTietDongVat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportChiTietDongVat.Location = new System.Drawing.Point(279, 85);
            this.btExportChiTietDongVat.Name = "btExportChiTietDongVat";
            this.btExportChiTietDongVat.Size = new System.Drawing.Size(200, 41);
            this.btExportChiTietDongVat.TabIndex = 67;
            this.btExportChiTietDongVat.Text = "Xuất file động vật";
            this.btExportChiTietDongVat.UseVisualStyleBackColor = true;
            this.btExportChiTietDongVat.Click += new System.EventHandler(this.btExportChiTietDongVat_Click);
            // 
            // ucThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.Name = "ucThongKe";
            this.Size = new System.Drawing.Size(1117, 628);
            this.Load += new System.EventHandler(this.ucThongKe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.Button btExportChiTiet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button btExportTongQuan;
        private System.Windows.Forms.Button btExportTongQuanThucVat;
        private System.Windows.Forms.Button btExportTongQuanDongVat;
        private System.Windows.Forms.Button btExportChiTietThucVat;
        private System.Windows.Forms.Button btExportChiTietDongVat;
    }
}
