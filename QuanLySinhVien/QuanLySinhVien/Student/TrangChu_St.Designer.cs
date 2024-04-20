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
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bt_xemDiem = new System.Windows.Forms.Button();
            this.bt_nhanTb = new System.Windows.Forms.Button();
            this.bt_UserSt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(155, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 420);
            this.panel1.TabIndex = 0;
            // 
            // bt_xemDiem
            // 
            this.bt_xemDiem.Location = new System.Drawing.Point(12, 12);
            this.bt_xemDiem.Name = "bt_xemDiem";
            this.bt_xemDiem.Size = new System.Drawing.Size(117, 53);
            this.bt_xemDiem.TabIndex = 1;
            this.bt_xemDiem.Text = "Xem Điểm";
            this.bt_xemDiem.UseVisualStyleBackColor = true;
            this.bt_xemDiem.Click += new System.EventHandler(this.bt_xemDiem_Click);
            // 
            // bt_nhanTb
            // 
            this.bt_nhanTb.Location = new System.Drawing.Point(12, 90);
            this.bt_nhanTb.Name = "bt_nhanTb";
            this.bt_nhanTb.Size = new System.Drawing.Size(117, 53);
            this.bt_nhanTb.TabIndex = 2;
            this.bt_nhanTb.Text = "Thông báo";
            this.bt_nhanTb.UseVisualStyleBackColor = true;
            this.bt_nhanTb.Click += new System.EventHandler(this.bt_nhanTb_Click);
            // 
            // bt_UserSt
            // 
            this.bt_UserSt.Location = new System.Drawing.Point(12, 168);
            this.bt_UserSt.Name = "bt_UserSt";
            this.bt_UserSt.Size = new System.Drawing.Size(117, 53);
            this.bt_UserSt.TabIndex = 3;
            this.bt_UserSt.Text = "Tài khoản";
            this.bt_UserSt.UseVisualStyleBackColor = true;
            this.bt_UserSt.Click += new System.EventHandler(this.bt_UserSt_Click);
            // 
            // TrangChu_St
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 444);
            this.Controls.Add(this.bt_UserSt);
            this.Controls.Add(this.bt_nhanTb);
            this.Controls.Add(this.bt_xemDiem);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrangChu_St";
            this.Text = "TrangChu_St";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button bt_xemDiem;
        private System.Windows.Forms.Button bt_nhanTb;
        private System.Windows.Forms.Button bt_UserSt;
    }
}