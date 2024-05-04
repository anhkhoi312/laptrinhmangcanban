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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_monhoc_qld = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bt_ListNoti = new System.Windows.Forms.Button();
            this.btn_Tb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(687, 184);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 44);
            this.comboBox1.TabIndex = 19;
            // 
            // label_monhoc_qld
            // 
            this.label_monhoc_qld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_monhoc_qld.AutoSize = true;
            this.label_monhoc_qld.BackColor = System.Drawing.Color.Transparent;
            this.label_monhoc_qld.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_monhoc_qld.Location = new System.Drawing.Point(321, 192);
            this.label_monhoc_qld.Name = "label_monhoc_qld";
            this.label_monhoc_qld.Size = new System.Drawing.Size(360, 36);
            this.label_monhoc_qld.TabIndex = 18;
            this.label_monhoc_qld.Text = "Chọn lớp để gửi hông báo";
            // 
            // btSend
            // 
            this.btSend.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.Location = new System.Drawing.Point(955, 670);
            this.btSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(97, 44);
            this.btSend.TabIndex = 22;
            this.btSend.Text = "Gửi";
            this.btSend.UseVisualStyleBackColor = false;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(256, 292);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(796, 373);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // bt_ListNoti
            // 
            this.bt_ListNoti.BackColor = System.Drawing.Color.Thistle;
            this.bt_ListNoti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ListNoti.Location = new System.Drawing.Point(33, 350);
            this.bt_ListNoti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_ListNoti.Name = "bt_ListNoti";
            this.bt_ListNoti.Size = new System.Drawing.Size(217, 109);
            this.bt_ListNoti.TabIndex = 25;
            this.bt_ListNoti.Text = "Xem thông báo đã gửi";
            this.bt_ListNoti.UseVisualStyleBackColor = false;
            this.bt_ListNoti.Click += new System.EventHandler(this.bt_ListNoti_Click);
            // 
            // btn_Tb
            // 
            this.btn_Tb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tb.Location = new System.Drawing.Point(33, 292);
            this.btn_Tb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Tb.Name = "btn_Tb";
            this.btn_Tb.Size = new System.Drawing.Size(217, 54);
            this.btn_Tb.TabIndex = 26;
            this.btn_Tb.Text = "Thông báo";
            this.btn_Tb.UseVisualStyleBackColor = false;
            this.btn_Tb.Click += new System.EventHandler(this.btn_Tb_Click);
            // 
            // ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1243, 764);
            this.Controls.Add(this.btn_Tb);
            this.Controls.Add(this.bt_ListNoti);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_monhoc_qld);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ThongBao";
            this.Text = "Thongbao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_monhoc_qld;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bt_ListNoti;
        private System.Windows.Forms.Button btn_Tb;
    }
}