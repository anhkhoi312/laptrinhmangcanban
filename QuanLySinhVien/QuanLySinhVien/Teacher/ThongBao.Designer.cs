using System.Windows.Forms;

namespace QuanLySinhVien
{
    partial class ThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongBao));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_monhoc_qld = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bt_ListNoti = new System.Windows.Forms.Button();
            this.btn_Tb = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(891, 763);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "GỬI";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(347, 22);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(218, 37);
            this.comboBox1.TabIndex = 19;
            // 
            // label_monhoc_qld
            // 
            this.label_monhoc_qld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_monhoc_qld.AutoSize = true;
            this.label_monhoc_qld.BackColor = System.Drawing.Color.Transparent;
            this.label_monhoc_qld.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_monhoc_qld.Location = new System.Drawing.Point(32, 25);
            this.label_monhoc_qld.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_monhoc_qld.Name = "label_monhoc_qld";
            this.label_monhoc_qld.Size = new System.Drawing.Size(302, 29);
            this.label_monhoc_qld.TabIndex = 18;
            this.label_monhoc_qld.Text = "Chọn lớp để gửi hông báo";
            // 
            // btSend
            // 
            this.btSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSend.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.Location = new System.Drawing.Point(611, 156);
            this.btSend.Margin = new System.Windows.Forms.Padding(2);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(81, 37);
            this.btSend.TabIndex = 22;
            this.btSend.Text = "Gửi";
            this.btSend.UseVisualStyleBackColor = false;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(18, 13);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(674, 139);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // bt_ListNoti
            // 
            this.bt_ListNoti.BackColor = System.Drawing.Color.Thistle;
            this.bt_ListNoti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ListNoti.Location = new System.Drawing.Point(28, 348);
            this.bt_ListNoti.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ListNoti.Name = "bt_ListNoti";
            this.bt_ListNoti.Size = new System.Drawing.Size(181, 91);
            this.bt_ListNoti.TabIndex = 25;
            this.bt_ListNoti.Text = "Xem thông báo đã gửi";
            this.bt_ListNoti.UseVisualStyleBackColor = false;
            this.bt_ListNoti.Click += new System.EventHandler(this.bt_ListNoti_Click);
            // 
            // btn_Tb
            // 
            this.btn_Tb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tb.Location = new System.Drawing.Point(28, 132);
            this.btn_Tb.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Tb.Name = "btn_Tb";
            this.btn_Tb.Size = new System.Drawing.Size(181, 45);
            this.btn_Tb.TabIndex = 26;
            this.btn_Tb.Text = "Thông báo";
            this.btn_Tb.UseVisualStyleBackColor = false;
            this.btn_Tb.Click += new System.EventHandler(this.btn_Tb_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label_monhoc_qld);
            this.panel1.Location = new System.Drawing.Point(250, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 78);
            this.panel1.TabIndex = 27;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(18, 15);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(674, 262);
            this.richTextBox2.TabIndex = 28;
            this.richTextBox2.Text = "";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.btSend);
            this.panel2.Location = new System.Drawing.Point(214, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(714, 193);
            this.panel2.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.richTextBox2);
            this.panel3.Location = new System.Drawing.Point(214, 333);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(714, 292);
            this.panel3.TabIndex = 30;
            // 
            // ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1036, 637);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Tb);
            this.Controls.Add(this.bt_ListNoti);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongBao";
            this.Text = "Thongbao";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_monhoc_qld;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bt_ListNoti;
        private System.Windows.Forms.Button btn_Tb;
        private Panel panel1;
        private RichTextBox richTextBox2;
        private Panel panel2;
        private Panel panel3;
    }
}