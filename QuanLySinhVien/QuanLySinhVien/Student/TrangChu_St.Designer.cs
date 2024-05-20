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
            this.btXemdiem = new System.Windows.Forms.Button();
            this.btThongbao = new System.Windows.Forms.Button();
            this.btUser = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btChat = new System.Windows.Forms.Button();
            this.btDeadline = new System.Windows.Forms.Button();
            this.bt_dangXuat = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(338, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 593);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btXemdiem
            // 
            this.btXemdiem.AutoSize = true;
            this.btXemdiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXemdiem.Image = ((System.Drawing.Image)(resources.GetObject("btXemdiem.Image")));
            this.btXemdiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXemdiem.Location = new System.Drawing.Point(3, 2);
            this.btXemdiem.Name = "btXemdiem";
            this.btXemdiem.Size = new System.Drawing.Size(333, 88);
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
            this.btThongbao.Location = new System.Drawing.Point(3, 85);
            this.btThongbao.Name = "btThongbao";
            this.btThongbao.Size = new System.Drawing.Size(333, 91);
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
            this.btUser.Location = new System.Drawing.Point(3, 252);
            this.btUser.Name = "btUser";
            this.btUser.Size = new System.Drawing.Size(333, 82);
            this.btUser.TabIndex = 15;
            this.btUser.Text = "Người dùng";
            this.btUser.UseVisualStyleBackColor = true;
            this.btUser.Click += new System.EventHandler(this.btUser_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btChat);
            this.panel2.Controls.Add(this.btDeadline);
            this.panel2.Controls.Add(this.bt_dangXuat);
            this.panel2.Controls.Add(this.btXemdiem);
            this.panel2.Controls.Add(this.btUser);
            this.panel2.Controls.Add(this.btThongbao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 595);
            this.panel2.TabIndex = 16;
            // 
            // btChat
            // 
            this.btChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChat.Location = new System.Drawing.Point(3, 340);
            this.btChat.Name = "btChat";
            this.btChat.Size = new System.Drawing.Size(329, 80);
            this.btChat.TabIndex = 32;
            this.btChat.Text = "CHAT";
            this.btChat.UseVisualStyleBackColor = true;
            this.btChat.Click += new System.EventHandler(this.btChat_Click);
            // 
            // btDeadline
            // 
            this.btDeadline.AutoSize = true;
            this.btDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeadline.Image = ((System.Drawing.Image)(resources.GetObject("btDeadline.Image")));
            this.btDeadline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeadline.Location = new System.Drawing.Point(3, 174);
            this.btDeadline.Name = "btDeadline";
            this.btDeadline.Size = new System.Drawing.Size(333, 82);
            this.btDeadline.TabIndex = 31;
            this.btDeadline.Text = "Deadline";
            this.btDeadline.UseVisualStyleBackColor = true;
            this.btDeadline.Click += new System.EventHandler(this.btDeadline_Click);
            // 
            // bt_dangXuat
            // 
            this.bt_dangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_dangXuat.BackColor = System.Drawing.Color.Thistle;
            this.bt_dangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_dangXuat.Location = new System.Drawing.Point(2, 547);
            this.bt_dangXuat.Margin = new System.Windows.Forms.Padding(2);
            this.bt_dangXuat.Name = "bt_dangXuat";
            this.bt_dangXuat.Size = new System.Drawing.Size(334, 46);
            this.bt_dangXuat.TabIndex = 30;
            this.bt_dangXuat.Text = "Đăng xuất";
            this.bt_dangXuat.UseVisualStyleBackColor = false;
            this.bt_dangXuat.Click += new System.EventHandler(this.bt_dangXuat_Click);
            // 
            // TrangChu_St
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1316, 595);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "TrangChu_St";
            this.Text = "TrangChu_St";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btXemdiem;
        private System.Windows.Forms.Button btThongbao;
        private System.Windows.Forms.Button btUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_dangXuat;
        private System.Windows.Forms.Button btDeadline;
        private System.Windows.Forms.Button btChat;
    }
}