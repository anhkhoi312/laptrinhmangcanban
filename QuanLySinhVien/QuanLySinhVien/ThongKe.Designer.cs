namespace QuanLySinhVien
{
    partial class ThongKe
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_mssv = new System.Windows.Forms.Label();
            this.label_hoten = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_sdt = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column_lop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_monhoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_diemgk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_diemck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_diemtb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_mssv = new System.Windows.Forms.TextBox();
            this.textBox_hoten = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_sdt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số sinh viên";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tra cứu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label_mssv
            // 
            this.label_mssv.AutoSize = true;
            this.label_mssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mssv.Location = new System.Drawing.Point(38, 210);
            this.label_mssv.Name = "label_mssv";
            this.label_mssv.Size = new System.Drawing.Size(103, 20);
            this.label_mssv.TabIndex = 3;
            this.label_mssv.Text = "Mã sinh viên";
            // 
            // label_hoten
            // 
            this.label_hoten.AutoSize = true;
            this.label_hoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hoten.Location = new System.Drawing.Point(38, 276);
            this.label_hoten.Name = "label_hoten";
            this.label_hoten.Size = new System.Drawing.Size(59, 20);
            this.label_hoten.TabIndex = 4;
            this.label_hoten.Text = "Họ tên";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.Location = new System.Drawing.Point(41, 351);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(51, 20);
            this.label_email.TabIndex = 5;
            this.label_email.Text = "Email";
            // 
            // label_sdt
            // 
            this.label_sdt.AutoSize = true;
            this.label_sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sdt.Location = new System.Drawing.Point(41, 410);
            this.label_sdt.Name = "label_sdt";
            this.label_sdt.Size = new System.Drawing.Size(106, 20);
            this.label_sdt.TabIndex = 6;
            this.label_sdt.Text = "Số điện thoại";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_lop,
            this.column_monhoc,
            this.column_diemgk,
            this.column_diemck,
            this.column_diemtb});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(271, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(868, 378);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column_lop
            // 
            this.column_lop.Text = "Lớp";
            // 
            // column_monhoc
            // 
            this.column_monhoc.Text = "Môn học";
            // 
            // column_diemgk
            // 
            this.column_diemgk.Text = "Điểm giữa kì";
            // 
            // column_diemck
            // 
            this.column_diemck.Text = "Điểm cuối kì";
            // 
            // column_diemtb
            // 
            this.column_diemtb.Text = "Điểm trung bình";
            // 
            // textBox_mssv
            // 
            this.textBox_mssv.Location = new System.Drawing.Point(45, 251);
            this.textBox_mssv.Name = "textBox_mssv";
            this.textBox_mssv.ReadOnly = true;
            this.textBox_mssv.Size = new System.Drawing.Size(100, 22);
            this.textBox_mssv.TabIndex = 8;
            // 
            // textBox_hoten
            // 
            this.textBox_hoten.Location = new System.Drawing.Point(45, 316);
            this.textBox_hoten.Name = "textBox_hoten";
            this.textBox_hoten.ReadOnly = true;
            this.textBox_hoten.Size = new System.Drawing.Size(100, 22);
            this.textBox_hoten.TabIndex = 9;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(45, 385);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.ReadOnly = true;
            this.textBox_email.Size = new System.Drawing.Size(100, 22);
            this.textBox_email.TabIndex = 10;
            // 
            // textBox_sdt
            // 
            this.textBox_sdt.Location = new System.Drawing.Point(45, 456);
            this.textBox_sdt.Name = "textBox_sdt";
            this.textBox_sdt.ReadOnly = true;
            this.textBox_sdt.Size = new System.Drawing.Size(100, 22);
            this.textBox_sdt.TabIndex = 11;
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 600);
            this.Controls.Add(this.textBox_sdt);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_hoten);
            this.Controls.Add(this.textBox_mssv);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label_sdt);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_hoten);
            this.Controls.Add(this.label_mssv);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_mssv;
        private System.Windows.Forms.Label label_hoten;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_sdt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column_lop;
        private System.Windows.Forms.ColumnHeader column_monhoc;
        private System.Windows.Forms.ColumnHeader column_diemgk;
        private System.Windows.Forms.ColumnHeader column_diemck;
        private System.Windows.Forms.ColumnHeader column_diemtb;
        private System.Windows.Forms.TextBox textBox_mssv;
        private System.Windows.Forms.TextBox textBox_hoten;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_sdt;
    }
}