
namespace DongThucVat
{
    partial class ucChonAdmin
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
            this.btQL = new System.Windows.Forms.Button();
            this.btDMK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btQL
            // 
            this.btQL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btQL.BackColor = System.Drawing.Color.Teal;
            this.btQL.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQL.ForeColor = System.Drawing.Color.White;
            this.btQL.Location = new System.Drawing.Point(398, 200);
            this.btQL.Name = "btQL";
            this.btQL.Size = new System.Drawing.Size(320, 100);
            this.btQL.TabIndex = 0;
            this.btQL.Text = "Quản lý người dùng";
            this.btQL.UseVisualStyleBackColor = false;
            this.btQL.Click += new System.EventHandler(this.btQL_Click);
            // 
            // btDMK
            // 
            this.btDMK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btDMK.BackColor = System.Drawing.Color.DarkCyan;
            this.btDMK.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btDMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDMK.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDMK.ForeColor = System.Drawing.Color.White;
            this.btDMK.Location = new System.Drawing.Point(398, 337);
            this.btDMK.Name = "btDMK";
            this.btDMK.Size = new System.Drawing.Size(320, 100);
            this.btDMK.TabIndex = 1;
            this.btDMK.Text = "Đổi mật khẩu";
            this.btDMK.UseVisualStyleBackColor = false;
            this.btDMK.Click += new System.EventHandler(this.btDMK_Click);
            // 
            // ucChonAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btDMK);
            this.Controls.Add(this.btQL);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucChonAdmin";
            this.Size = new System.Drawing.Size(1117, 628);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btQL;
        private System.Windows.Forms.Button btDMK;
    }
}
