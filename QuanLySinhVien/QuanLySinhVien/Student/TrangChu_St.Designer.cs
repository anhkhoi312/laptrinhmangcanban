namespace QuanLySinhVien.Student
{
    partial class TrangChu_St
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu_St));
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bt_User = new System.Windows.Forms.Button();
            this.btThongBao = new System.Windows.Forms.Button();
            this.btNhapDiem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(314, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1510, 848);
            this.panel1.TabIndex = 0;
            // 
            // bt_User
            // 
            this.bt_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_User.Image = ((System.Drawing.Image)(resources.GetObject("bt_User.Image")));
            this.bt_User.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_User.Location = new System.Drawing.Point(40, 339);
            this.bt_User.Name = "bt_User";
            this.bt_User.Size = new System.Drawing.Size(221, 82);
            this.bt_User.TabIndex = 12;
            this.bt_User.Text = "       Người dùng";
            this.bt_User.UseVisualStyleBackColor = true;
            // 
            // btThongBao
            // 
            this.btThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThongBao.Image = ((System.Drawing.Image)(resources.GetObject("btThongBao.Image")));
            this.btThongBao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThongBao.Location = new System.Drawing.Point(40, 215);
            this.btThongBao.Name = "btThongBao";
            this.btThongBao.Size = new System.Drawing.Size(221, 82);
            this.btThongBao.TabIndex = 11;
            this.btThongBao.Text = " Thông báo";
            this.btThongBao.UseVisualStyleBackColor = true;
            // 
            // btNhapDiem
            // 
            this.btNhapDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNhapDiem.Image = ((System.Drawing.Image)(resources.GetObject("btNhapDiem.Image")));
            this.btNhapDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNhapDiem.Location = new System.Drawing.Point(40, 93);
            this.btNhapDiem.Name = "btNhapDiem";
            this.btNhapDiem.Size = new System.Drawing.Size(221, 82);
            this.btNhapDiem.TabIndex = 10;
            this.btNhapDiem.Text = " Xem điểm";
            this.btNhapDiem.UseVisualStyleBackColor = true;
            // 
            // TrangChu_St
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.bt_User);
            this.Controls.Add(this.btThongBao);
            this.Controls.Add(this.btNhapDiem);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "TrangChu_St";
            this.Text = "TrangChu_St";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button bt_User;
        private System.Windows.Forms.Button btThongBao;
        private System.Windows.Forms.Button btNhapDiem;
    }
}