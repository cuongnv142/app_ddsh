
namespace DongThucVat
{
    partial class frmHome
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbRole = new System.Windows.Forms.Label();
            this.btMini = new System.Windows.Forms.Button();
            this.btLogOut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btBack = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.btSettings = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btThucVat = new System.Windows.Forms.Button();
            this.btDongVat = new System.Windows.Forms.Button();
            this.btHome = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btThongKe = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.panelControl = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.panel2.Controls.Add(this.lbTieuDe);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(163, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1117, 92);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lbTieuDe.Location = new System.Drawing.Point(3, 15);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(623, 60);
            this.lbTieuDe.TabIndex = 11;
            this.lbTieuDe.Text = "BAN QUẢN LÝ KHU BẢO TỒN THIÊN NHIÊN\r\nBẮC HƯỚNG HOÁ";
            this.lbTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.lbRole);
            this.panel1.Controls.Add(this.btMini);
            this.panel1.Controls.Add(this.btLogOut);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbFirstName);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(634, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 90);
            this.panel1.TabIndex = 9;
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lbTime.Location = new System.Drawing.Point(135, 73);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(345, 17);
            this.lbTime.TabIndex = 13;
            this.lbTime.Text = "dd/MM/yyyy HH:mm:ss";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbRole
            // 
            this.lbRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lbRole.Location = new System.Drawing.Point(92, 43);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(14, 21);
            this.lbRole.TabIndex = 12;
            this.lbRole.Text = ".";
            // 
            // btMini
            // 
            this.btMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMini.FlatAppearance.BorderSize = 0;
            this.btMini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMini.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMini.ForeColor = System.Drawing.Color.White;
            this.btMini.Image = ((System.Drawing.Image)(resources.GetObject("btMini.Image")));
            this.btMini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMini.Location = new System.Drawing.Point(348, 3);
            this.btMini.Name = "btMini";
            this.btMini.Size = new System.Drawing.Size(39, 36);
            this.btMini.TabIndex = 1;
            this.btMini.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMini.UseVisualStyleBackColor = true;
            this.btMini.Click += new System.EventHandler(this.btMini_Click);
            // 
            // btLogOut
            // 
            this.btLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLogOut.FlatAppearance.BorderSize = 0;
            this.btLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogOut.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogOut.ForeColor = System.Drawing.Color.White;
            this.btLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btLogOut.Image")));
            this.btLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLogOut.Location = new System.Drawing.Point(393, 3);
            this.btLogOut.Name = "btLogOut";
            this.btLogOut.Size = new System.Drawing.Size(39, 36);
            this.btLogOut.TabIndex = 2;
            this.btLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLogOut.UseVisualStyleBackColor = true;
            this.btLogOut.Click += new System.EventHandler(this.btLogOut_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quyền:";
            // 
            // lbFirstName
            // 
            this.lbFirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lbFirstName.Location = new System.Drawing.Point(92, 11);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(14, 21);
            this.lbFirstName.TabIndex = 10;
            this.lbFirstName.Text = ".";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(438, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(39, 36);
            this.btClose.TabIndex = 3;
            this.btClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Welcome:";
            // 
            // btBack
            // 
            this.btBack.FlatAppearance.BorderSize = 0;
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBack.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBack.ForeColor = System.Drawing.Color.White;
            this.btBack.Image = ((System.Drawing.Image)(resources.GetObject("btBack.Image")));
            this.btBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBack.Location = new System.Drawing.Point(0, 0);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(107, 92);
            this.btBack.TabIndex = 0;
            this.btBack.Text = "Trở lại";
            this.btBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.White;
            this.panelSide.Location = new System.Drawing.Point(2, 94);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(7, 80);
            this.panelSide.TabIndex = 6;
            // 
            // btSettings
            // 
            this.btSettings.FlatAppearance.BorderSize = 0;
            this.btSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSettings.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSettings.ForeColor = System.Drawing.Color.White;
            this.btSettings.Image = ((System.Drawing.Image)(resources.GetObject("btSettings.Image")));
            this.btSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSettings.Location = new System.Drawing.Point(13, 522);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(151, 80);
            this.btSettings.TabIndex = 4;
            this.btSettings.Text = " Cài đặt";
            this.btSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(12, 350);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(151, 80);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = " Tài khoản";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btThucVat
            // 
            this.btThucVat.FlatAppearance.BorderSize = 0;
            this.btThucVat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThucVat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThucVat.ForeColor = System.Drawing.Color.White;
            this.btThucVat.Image = ((System.Drawing.Image)(resources.GetObject("btThucVat.Image")));
            this.btThucVat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThucVat.Location = new System.Drawing.Point(13, 264);
            this.btThucVat.Name = "btThucVat";
            this.btThucVat.Size = new System.Drawing.Size(151, 80);
            this.btThucVat.TabIndex = 2;
            this.btThucVat.Text = " Thực vật\r\n";
            this.btThucVat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThucVat.UseVisualStyleBackColor = true;
            this.btThucVat.Click += new System.EventHandler(this.btThucVat_Click);
            // 
            // btDongVat
            // 
            this.btDongVat.FlatAppearance.BorderSize = 0;
            this.btDongVat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDongVat.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDongVat.ForeColor = System.Drawing.Color.White;
            this.btDongVat.Image = ((System.Drawing.Image)(resources.GetObject("btDongVat.Image")));
            this.btDongVat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDongVat.Location = new System.Drawing.Point(13, 178);
            this.btDongVat.Name = "btDongVat";
            this.btDongVat.Size = new System.Drawing.Size(151, 80);
            this.btDongVat.TabIndex = 1;
            this.btDongVat.Text = " Động vật";
            this.btDongVat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDongVat.UseVisualStyleBackColor = true;
            this.btDongVat.Click += new System.EventHandler(this.btDongVat_Click);
            // 
            // btHome
            // 
            this.btHome.FlatAppearance.BorderSize = 0;
            this.btHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHome.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHome.ForeColor = System.Drawing.Color.White;
            this.btHome.Image = ((System.Drawing.Image)(resources.GetObject("btHome.Image")));
            this.btHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHome.Location = new System.Drawing.Point(12, 92);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(151, 80);
            this.btHome.TabIndex = 0;
            this.btHome.Text = " Trang chủ";
            this.btHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btHome.UseVisualStyleBackColor = true;
            this.btHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.panelLeft.Controls.Add(this.btThongKe);
            this.panelLeft.Controls.Add(this.panelSide);
            this.panelLeft.Controls.Add(this.btSettings);
            this.panelLeft.Controls.Add(this.btnUsers);
            this.panelLeft.Controls.Add(this.btThucVat);
            this.panelLeft.Controls.Add(this.btDongVat);
            this.panelLeft.Controls.Add(this.btHome);
            this.panelLeft.Controls.Add(this.panel3);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(163, 720);
            this.panelLeft.TabIndex = 4;
            // 
            // btThongKe
            // 
            this.btThongKe.FlatAppearance.BorderSize = 0;
            this.btThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThongKe.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThongKe.ForeColor = System.Drawing.Color.White;
            this.btThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btThongKe.Image")));
            this.btThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThongKe.Location = new System.Drawing.Point(13, 436);
            this.btThongKe.Name = "btThongKe";
            this.btThongKe.Size = new System.Drawing.Size(151, 80);
            this.btThongKe.TabIndex = 7;
            this.btThongKe.Text = " Thống kê";
            this.btThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThongKe.UseVisualStyleBackColor = true;
            this.btThongKe.Click += new System.EventHandler(this.btThongKe_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbLogo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 92);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(163, 92);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // timerTime
            // 
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(163, 92);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1117, 628);
            this.panelControl.TabIndex = 0;
            // 
            // frmHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHome_FormClosed);
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btThucVat;
        private System.Windows.Forms.Button btDongVat;
        private System.Windows.Forms.Button btHome;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btLogOut;
        private System.Windows.Forms.Button btMini;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btThongKe;
    }
}