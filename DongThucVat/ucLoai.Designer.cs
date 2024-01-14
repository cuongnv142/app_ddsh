
namespace DongThucVat
{
    partial class ucLoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoai));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cb = new System.Windows.Forms.ComboBox();
            this.btThem = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_khac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dac_diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gia_tri_su_dung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phan_bo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguon_tai_lieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muc_do_bao_ton_iucn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muc_do_bao_ton_sdvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muc_do_bao_ton_ndcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muc_do_bao_ton_nd64cp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btPrev = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb
            // 
            this.cb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb.FormattingEnabled = true;
            this.cb.Location = new System.Drawing.Point(691, 72);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(400, 33);
            this.cb.TabIndex = 4;
            this.cb.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btThem.FlatAppearance.BorderSize = 0;
            this.btThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Image = ((System.Drawing.Image)(resources.GetObject("btThem.Image")));
            this.btThem.Location = new System.Drawing.Point(0, 54);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(150, 67);
            this.btThem.TabIndex = 0;
            this.btThem.Text = "   Thêm";
            this.btThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cb);
            this.panel5.Controls.Add(this.btRefresh);
            this.panel5.Controls.Add(this.btXoa);
            this.panel5.Controls.Add(this.btSua);
            this.panel5.Controls.Add(this.btThem);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1107, 121);
            this.panel5.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbTieuDe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 45);
            this.panel2.TabIndex = 22;
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.ForeColor = System.Drawing.Color.White;
            this.lbTieuDe.Location = new System.Drawing.Point(452, 4);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(202, 32);
            this.lbTieuDe.TabIndex = 15;
            this.lbTieuDe.Text = "LOÀI ĐỘNG VẬT";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(648, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "     ";
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRefresh.FlatAppearance.BorderSize = 0;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefresh.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.White;
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.Location = new System.Drawing.Point(450, 54);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(167, 67);
            this.btRefresh.TabIndex = 3;
            this.btRefresh.Text = "   Làm mới";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btXoa
            // 
            this.btXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btXoa.FlatAppearance.BorderSize = 0;
            this.btXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoa.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.White;
            this.btXoa.Image = ((System.Drawing.Image)(resources.GetObject("btXoa.Image")));
            this.btXoa.Location = new System.Drawing.Point(300, 54);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(150, 67);
            this.btXoa.TabIndex = 2;
            this.btXoa.Text = "   Xóa";
            this.btXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSua.FlatAppearance.BorderSize = 0;
            this.btSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSua.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ForeColor = System.Drawing.Color.White;
            this.btSua.Image = ((System.Drawing.Image)(resources.GetObject("btSua.Image")));
            this.btSua.Location = new System.Drawing.Point(150, 54);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(150, 67);
            this.btSua.TabIndex = 1;
            this.btSua.Text = "   Sửa";
            this.btSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.ten_khac,
            this.dac_diem,
            this.gia_tri_su_dung,
            this.phan_bo,
            this.nguon_tai_lieu,
            this.muc_do_bao_ton_iucn,
            this.muc_do_bao_ton_sdvn,
            this.muc_do_bao_ton_ndcp,
            this.muc_do_bao_ton_nd64cp,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1107, 466);
            this.dgv.TabIndex = 0;
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 40;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "name";
            this.Column1.HeaderText = "Tên tiếng Việt";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name_latinh";
            this.Column2.HeaderText = "Tên Latinh";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "status";
            this.Column3.HeaderText = "Trạng thái";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "created_at";
            this.Column4.HeaderText = "Khởi tạo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 250;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "updated_at";
            this.Column5.HeaderText = "Cập nhật";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 250;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "id";
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "loai";
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "id_dtv_ho";
            this.Column8.HeaderText = "";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // ten_khac
            // 
            this.ten_khac.DataPropertyName = "ten_khac";
            this.ten_khac.HeaderText = "";
            this.ten_khac.Name = "ten_khac";
            this.ten_khac.ReadOnly = true;
            this.ten_khac.Visible = false;
            // 
            // dac_diem
            // 
            this.dac_diem.DataPropertyName = "dac_diem";
            this.dac_diem.HeaderText = "";
            this.dac_diem.Name = "dac_diem";
            this.dac_diem.ReadOnly = true;
            this.dac_diem.Visible = false;
            // 
            // gia_tri_su_dung
            // 
            this.gia_tri_su_dung.DataPropertyName = "gia_tri_su_dung";
            this.gia_tri_su_dung.HeaderText = "";
            this.gia_tri_su_dung.Name = "gia_tri_su_dung";
            this.gia_tri_su_dung.ReadOnly = true;
            this.gia_tri_su_dung.Visible = false;
            // 
            // phan_bo
            // 
            this.phan_bo.DataPropertyName = "phan_bo";
            this.phan_bo.HeaderText = "";
            this.phan_bo.Name = "phan_bo";
            this.phan_bo.ReadOnly = true;
            this.phan_bo.Visible = false;
            // 
            // nguon_tai_lieu
            // 
            this.nguon_tai_lieu.DataPropertyName = "nguon_tai_lieu";
            this.nguon_tai_lieu.HeaderText = "";
            this.nguon_tai_lieu.Name = "nguon_tai_lieu";
            this.nguon_tai_lieu.ReadOnly = true;
            this.nguon_tai_lieu.Visible = false;
            // 
            // muc_do_bao_ton_iucn
            // 
            this.muc_do_bao_ton_iucn.DataPropertyName = "muc_do_bao_ton_iucn";
            this.muc_do_bao_ton_iucn.HeaderText = "";
            this.muc_do_bao_ton_iucn.Name = "muc_do_bao_ton_iucn";
            this.muc_do_bao_ton_iucn.ReadOnly = true;
            this.muc_do_bao_ton_iucn.Visible = false;
            // 
            // muc_do_bao_ton_sdvn
            // 
            this.muc_do_bao_ton_sdvn.DataPropertyName = "muc_do_bao_ton_sdvn";
            this.muc_do_bao_ton_sdvn.HeaderText = "";
            this.muc_do_bao_ton_sdvn.Name = "muc_do_bao_ton_sdvn";
            this.muc_do_bao_ton_sdvn.ReadOnly = true;
            this.muc_do_bao_ton_sdvn.Visible = false;
            // 
            // muc_do_bao_ton_ndcp
            // 
            this.muc_do_bao_ton_ndcp.DataPropertyName = "muc_do_bao_ton_ndcp";
            this.muc_do_bao_ton_ndcp.HeaderText = "";
            this.muc_do_bao_ton_ndcp.Name = "muc_do_bao_ton_ndcp";
            this.muc_do_bao_ton_ndcp.ReadOnly = true;
            this.muc_do_bao_ton_ndcp.Visible = false;
            // 
            // muc_do_bao_ton_nd64cp
            // 
            this.muc_do_bao_ton_nd64cp.DataPropertyName = "muc_do_bao_ton_nd64cp";
            this.muc_do_bao_ton_nd64cp.HeaderText = "";
            this.muc_do_bao_ton_nd64cp.Name = "muc_do_bao_ton_nd64cp";
            this.muc_do_bao_ton_nd64cp.ReadOnly = true;
            this.muc_do_bao_ton_nd64cp.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "created_by";
            this.Column9.HeaderText = "";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "updated_by";
            this.Column10.HeaderText = "";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "namefk";
            this.Column11.HeaderText = "Họ";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 300;
            // 
            // btPrev
            // 
            this.btPrev.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrev.Location = new System.Drawing.Point(16, 3);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(75, 26);
            this.btPrev.TabIndex = 0;
            this.btPrev.Text = "<<";
            this.btPrev.UseVisualStyleBackColor = true;
            this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.Location = new System.Drawing.Point(97, 3);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 26);
            this.btNext.TabIndex = 1;
            this.btNext.Text = ">>";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btPrev);
            this.panel3.Controls.Add(this.btNext);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 592);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1107, 31);
            this.panel3.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 466);
            this.panel1.TabIndex = 22;
            // 
            // ucLoai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucLoai";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1117, 628);
            this.Load += new System.EventHandler(this.ucLoai_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_khac;
        private System.Windows.Forms.DataGridViewTextBoxColumn dac_diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gia_tri_su_dung;
        private System.Windows.Forms.DataGridViewTextBoxColumn phan_bo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguon_tai_lieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn muc_do_bao_ton_iucn;
        private System.Windows.Forms.DataGridViewTextBoxColumn muc_do_bao_ton_sdvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn muc_do_bao_ton_ndcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn muc_do_bao_ton_nd64cp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btPrev;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}
