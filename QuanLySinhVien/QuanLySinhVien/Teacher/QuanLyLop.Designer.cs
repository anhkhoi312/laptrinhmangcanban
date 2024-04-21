namespace QuanLySinhVien
{
    partial class QuanLyLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyLop));
            this.groupbox_enter_stu_info = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button1_them = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_mssv = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column_mssv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_sdt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox_mssv = new System.Windows.Forms.ComboBox();
            this.label_monhoc_qld = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupbox_enter_stu_info.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox_enter_stu_info
            // 
            this.groupbox_enter_stu_info.BackColor = System.Drawing.Color.Transparent;
            this.groupbox_enter_stu_info.Controls.Add(this.button1);
            this.groupbox_enter_stu_info.Controls.Add(this.button1_them);
            this.groupbox_enter_stu_info.Controls.Add(this.textBox1);
            this.groupbox_enter_stu_info.Controls.Add(this.label_mssv);
            this.groupbox_enter_stu_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_enter_stu_info.Location = new System.Drawing.Point(19, 3);
            this.groupbox_enter_stu_info.Name = "groupbox_enter_stu_info";
            this.groupbox_enter_stu_info.Size = new System.Drawing.Size(272, 267);
            this.groupbox_enter_stu_info.TabIndex = 0;
            this.groupbox_enter_stu_info.TabStop = false;
            this.groupbox_enter_stu_info.Text = "Chỉnh sửa danh sách";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(11, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 50);
            this.button1.TabIndex = 13;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button1_them
            // 
            this.button1_them.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_them.Location = new System.Drawing.Point(11, 210);
            this.button1_them.Name = "button1_them";
            this.button1_them.Size = new System.Drawing.Size(130, 50);
            this.button1_them.TabIndex = 12;
            this.button1_them.Text = "Thêm";
            this.button1_them.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 36);
            this.textBox1.TabIndex = 8;
            // 
            // label_mssv
            // 
            this.label_mssv.AutoSize = true;
            this.label_mssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mssv.Location = new System.Drawing.Point(6, 63);
            this.label_mssv.Name = "label_mssv";
            this.label_mssv.Size = new System.Drawing.Size(148, 25);
            this.label_mssv.TabIndex = 0;
            this.label_mssv.Text = "Mã số sinh viên";
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_mssv,
            this.column_ten,
            this.column_sdt,
            this.column_email});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(445, 208);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(620, 337);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column_mssv
            // 
            this.column_mssv.Text = "MSSV";
            this.column_mssv.Width = 100;
            // 
            // column_ten
            // 
            this.column_ten.Text = "Họ tên";
            this.column_ten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_ten.Width = 180;
            // 
            // column_sdt
            // 
            this.column_sdt.Text = "Số điện thoại";
            this.column_sdt.Width = 150;
            // 
            // column_email
            // 
            this.column_email.Text = "Email";
            this.column_email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_email.Width = 100;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(74, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(253, 54);
            this.button3.TabIndex = 15;
            this.button3.Text = "XUẤT RA FILE EXCEL";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // comboBox_mssv
            // 
            this.comboBox_mssv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_mssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_mssv.FormattingEnabled = true;
            this.comboBox_mssv.Location = new System.Drawing.Point(368, 46);
            this.comboBox_mssv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_mssv.Name = "comboBox_mssv";
            this.comboBox_mssv.Size = new System.Drawing.Size(585, 37);
            this.comboBox_mssv.TabIndex = 17;
            // 
            // label_monhoc_qld
            // 
            this.label_monhoc_qld.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_monhoc_qld.AutoSize = true;
            this.label_monhoc_qld.BackColor = System.Drawing.Color.Transparent;
            this.label_monhoc_qld.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_monhoc_qld.Location = new System.Drawing.Point(225, 47);
            this.label_monhoc_qld.Name = "label_monhoc_qld";
            this.label_monhoc_qld.Size = new System.Drawing.Size(114, 29);
            this.label_monhoc_qld.TabIndex = 16;
            this.label_monhoc_qld.Text = "Chọn lớp";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(663, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 29);
            this.label5.TabIndex = 32;
            this.label5.Text = "DANH SÁCH";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 100);
            this.panel1.TabIndex = 34;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(352, 42);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(512, 37);
            this.comboBox1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn lớp";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 141);
            this.panel2.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.groupbox_enter_stu_info);
            this.panel3.Location = new System.Drawing.Point(55, 253);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(345, 315);
            this.panel3.TabIndex = 36;
            // 
            // QuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 611);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_mssv);
            this.Controls.Add(this.label_monhoc_qld);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyLop";
            this.Text = "QuanLySinhVien";
            this.groupbox_enter_stu_info.ResumeLayout(false);
            this.groupbox_enter_stu_info.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox_enter_stu_info;
        private System.Windows.Forms.Label label_mssv;
        private System.Windows.Forms.Button button1_them;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column_mssv;
        private System.Windows.Forms.ColumnHeader column_ten;
        private System.Windows.Forms.ColumnHeader column_sdt;
        private System.Windows.Forms.ColumnHeader column_email;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox_mssv;
        private System.Windows.Forms.Label label_monhoc_qld;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

