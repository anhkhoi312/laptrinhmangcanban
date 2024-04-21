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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_dangxuat = new System.Windows.Forms.Button();
            this.btXemdiem = new System.Windows.Forms.Button();
            this.btThongbao = new System.Windows.Forms.Button();
            this.btUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(345, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 620);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_dangxuat
            // 
            this.btn_dangxuat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_dangxuat.Location = new System.Drawing.Point(784, 697);
            this.btn_dangxuat.Name = "btn_dangxuat";
            this.btn_dangxuat.Size = new System.Drawing.Size(187, 55);
            this.btn_dangxuat.TabIndex = 11;
            this.btn_dangxuat.Text = "Đăng xuất";
            this.btn_dangxuat.UseVisualStyleBackColor = true;
            // 
            // btXemdiem
            // 
            this.btXemdiem.AutoSize = true;
            this.btXemdiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemdiem.Image = ((System.Drawing.Image)(resources.GetObject("btXemdiem.Image")));
            this.btXemdiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXemdiem.Location = new System.Drawing.Point(40, 93);
            this.btXemdiem.Name = "btXemdiem";
            this.btXemdiem.Size = new System.Drawing.Size(285, 82);
            this.btXemdiem.TabIndex = 13;
            this.btXemdiem.Text = " Xem điểm";
            this.btXemdiem.UseVisualStyleBackColor = true;
            this.btXemdiem.Click += new System.EventHandler(this.btXemdiem_Click);
            // 
            // btThongbao
            // 
            this.btThongbao.AutoSize = true;
            this.btThongbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThongbao.Image = ((System.Drawing.Image)(resources.GetObject("btThongbao.Image")));
            this.btThongbao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThongbao.Location = new System.Drawing.Point(40, 223);
            this.btThongbao.Name = "btThongbao";
            this.btThongbao.Size = new System.Drawing.Size(285, 82);
            this.btThongbao.TabIndex = 14;
            this.btThongbao.Text = "Thông báo";
            this.btThongbao.UseVisualStyleBackColor = true;
            this.btThongbao.Click += new System.EventHandler(this.btThongbao_Click);
            // 
            // btUser
            // 
            this.btUser.AutoSize = true;
            this.btUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUser.Image = ((System.Drawing.Image)(resources.GetObject("btUser.Image")));
            this.btUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUser.Location = new System.Drawing.Point(40, 354);
            this.btUser.Name = "btUser";
            this.btUser.Size = new System.Drawing.Size(285, 82);
            this.btUser.TabIndex = 15;
            this.btUser.Text = "Người dùng";
            this.btUser.UseVisualStyleBackColor = true;
            this.btUser.Click += new System.EventHandler(this.btUser_Click);
            // 
            // TrangChu_St
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1456, 776);
            this.Controls.Add(this.btUser);
            this.Controls.Add(this.btThongbao);
            this.Controls.Add(this.btXemdiem);
            this.Controls.Add(this.btn_dangxuat);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "TrangChu_St";
            this.Text = "TrangChu_St";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_dangxuat;
        private System.Windows.Forms.Button btXemdiem;
        private System.Windows.Forms.Button btThongbao;
        private System.Windows.Forms.Button btUser;
    }
}