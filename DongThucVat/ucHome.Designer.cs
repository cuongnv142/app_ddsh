﻿
namespace DongThucVat
{
    partial class ucHome
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
            this.pbHome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHome
            // 
            this.pbHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbHome.Location = new System.Drawing.Point(15, 14);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(1087, 600);
            this.pbHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHome.TabIndex = 4;
            this.pbHome.TabStop = false;
            // 
            // ucHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pbHome);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.Name = "ucHome";
            this.Size = new System.Drawing.Size(1117, 628);
            this.Load += new System.EventHandler(this.ucHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbHome;
    }
}
