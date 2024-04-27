namespace FarmingProject.FormLayer
{
    partial class FrmAnaMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaMenu));
            this.pictureBoxAdminGirisi = new System.Windows.Forms.PictureBox();
            this.pictureBoxCikis = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdminGirisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCikis)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAdminGirisi
            // 
            this.pictureBoxAdminGirisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAdminGirisi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAdminGirisi.Image")));
            this.pictureBoxAdminGirisi.Location = new System.Drawing.Point(25, 32);
            this.pictureBoxAdminGirisi.Name = "pictureBoxAdminGirisi";
            this.pictureBoxAdminGirisi.Size = new System.Drawing.Size(109, 100);
            this.pictureBoxAdminGirisi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAdminGirisi.TabIndex = 0;
            this.pictureBoxAdminGirisi.TabStop = false;
            this.pictureBoxAdminGirisi.Click += new System.EventHandler(this.pictureBoxAdminGirisi_Click);
            // 
            // pictureBoxCikis
            // 
            this.pictureBoxCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCikis.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCikis.Image")));
            this.pictureBoxCikis.Location = new System.Drawing.Point(190, 32);
            this.pictureBoxCikis.Name = "pictureBoxCikis";
            this.pictureBoxCikis.Size = new System.Drawing.Size(102, 100);
            this.pictureBoxCikis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCikis.TabIndex = 2;
            this.pictureBoxCikis.TabStop = false;
            this.pictureBoxCikis.Click += new System.EventHandler(this.pictureBoxCikis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(33, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Admin Girişi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(221, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Çıkış";
            // 
            // FrmAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 178);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxCikis);
            this.Controls.Add(this.pictureBoxAdminGirisi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAnaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdminGirisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCikis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAdminGirisi;
        private System.Windows.Forms.PictureBox pictureBoxCikis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}