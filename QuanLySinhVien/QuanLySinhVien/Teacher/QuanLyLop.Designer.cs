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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupbox_enter_stu_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox_enter_stu_info
            // 
            this.groupbox_enter_stu_info.BackColor = System.Drawing.Color.DarkGray;
            this.groupbox_enter_stu_info.Controls.Add(this.button1);
            this.groupbox_enter_stu_info.Controls.Add(this.button1_them);
            this.groupbox_enter_stu_info.Controls.Add(this.textBox1);
            this.groupbox_enter_stu_info.Controls.Add(this.label_mssv);
            this.groupbox_enter_stu_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_enter_stu_info.Location = new System.Drawing.Point(14, 13);
            this.groupbox_enter_stu_info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupbox_enter_stu_info.Name = "groupbox_enter_stu_info";
            this.groupbox_enter_stu_info.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupbox_enter_stu_info.Size = new System.Drawing.Size(594, 140);
            this.groupbox_enter_stu_info.TabIndex = 0;
            this.groupbox_enter_stu_info.TabStop = false;
            this.groupbox_enter_stu_info.Text = "Chỉnh sửa danh sách";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Location = new System.Drawing.Point(253, 75);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 44);
            this.button1.TabIndex = 13;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button1_them
            // 
            this.button1_them.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1_them.Location = new System.Drawing.Point(382, 75);
            this.button1_them.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1_them.Name = "button1_them";
            this.button1_them.Size = new System.Drawing.Size(109, 44);
            this.button1_them.TabIndex = 12;
            this.button1_them.Text = "Thêm";
            this.button1_them.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 82);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 30);
            this.textBox1.TabIndex = 8;
            // 
            // label_mssv
            // 
            this.label_mssv.AutoSize = true;
            this.label_mssv.Location = new System.Drawing.Point(17, 42);
            this.label_mssv.Name = "label_mssv";
            this.label_mssv.Size = new System.Drawing.Size(148, 25);
            this.label_mssv.TabIndex = 0;
            this.label_mssv.Text = "Mã số sinh viên";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_mssv,
            this.column_ten,
            this.column_sdt,
            this.column_email});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 217);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(594, 140);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(16, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Chọn lớp";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 28);
            this.comboBox1.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(407, 165);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 44);
            this.button3.TabIndex = 15;
            this.button3.Text = "XUẤT RA FILE EXCEL";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // QuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 370);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupbox_enter_stu_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuanLyLop";
            this.Text = "QuanLySinhVien";
            this.groupbox_enter_stu_info.ResumeLayout(false);
            this.groupbox_enter_stu_info.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

