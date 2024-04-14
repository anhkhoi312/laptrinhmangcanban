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
            this.label_thongke = new System.Windows.Forms.Label();
            this.textBox_mssv_thongke = new System.Windows.Forms.TextBox();
            this.tracuu = new System.Windows.Forms.Button();
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
            // label_thongke
            // 
            this.label_thongke.AutoSize = true;
            this.label_thongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thongke.Location = new System.Drawing.Point(7, 9);
            this.label_thongke.Name = "label_thongke";
            this.label_thongke.Size = new System.Drawing.Size(178, 29);
            this.label_thongke.TabIndex = 0;
            this.label_thongke.Text = "Mã số sinh viên";
            // 
            // textBox_mssv_thongke
            // 
            this.textBox_mssv_thongke.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_mssv_thongke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_mssv_thongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_mssv_thongke.Location = new System.Drawing.Point(12, 41);
            this.textBox_mssv_thongke.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.textBox_mssv_thongke.Name = "textBox_mssv_thongke";
            this.textBox_mssv_thongke.Size = new System.Drawing.Size(233, 35);
            this.textBox_mssv_thongke.TabIndex = 1;
            // 
            // tracuu
            // 
            this.tracuu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tracuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tracuu.Location = new System.Drawing.Point(12, 90);
            this.tracuu.Name = "tracuu";
            this.tracuu.Size = new System.Drawing.Size(122, 42);
            this.tracuu.TabIndex = 2;
            this.tracuu.Text = "Tra cứu";
            this.tracuu.UseVisualStyleBackColor = false;
            // 
            // label_mssv
            // 
            this.label_mssv.AutoSize = true;
            this.label_mssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mssv.Location = new System.Drawing.Point(13, 144);
            this.label_mssv.Name = "label_mssv";
            this.label_mssv.Size = new System.Drawing.Size(134, 26);
            this.label_mssv.TabIndex = 3;
            this.label_mssv.Text = "Mã sinh viên";
            // 
            // label_hoten
            // 
            this.label_hoten.AutoSize = true;
            this.label_hoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hoten.Location = new System.Drawing.Point(8, 224);
            this.label_hoten.Name = "label_hoten";
            this.label_hoten.Size = new System.Drawing.Size(76, 26);
            this.label_hoten.TabIndex = 4;
            this.label_hoten.Text = "Họ tên";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.Location = new System.Drawing.Point(8, 305);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(68, 26);
            this.label_email.TabIndex = 5;
            this.label_email.Text = "Email";
            // 
            // label_sdt
            // 
            this.label_sdt.AutoSize = true;
            this.label_sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sdt.Location = new System.Drawing.Point(13, 390);
            this.label_sdt.Name = "label_sdt";
            this.label_sdt.Size = new System.Drawing.Size(139, 26);
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
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(271, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(640, 446);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column_lop
            // 
            this.column_lop.Text = "Lớp";
            this.column_lop.Width = 94;
            // 
            // column_monhoc
            // 
            this.column_monhoc.Text = "Môn học";
            this.column_monhoc.Width = 128;
            // 
            // column_diemgk
            // 
            this.column_diemgk.Text = "Điểm giữa kì";
            this.column_diemgk.Width = 128;
            // 
            // column_diemck
            // 
            this.column_diemck.Text = "Điểm cuối kì";
            this.column_diemck.Width = 128;
            // 
            // column_diemtb
            // 
            this.column_diemtb.Text = "Điểm trung bình";
            this.column_diemtb.Width = 162;
            // 
            // textBox_mssv
            // 
            this.textBox_mssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_mssv.Location = new System.Drawing.Point(13, 173);
            this.textBox_mssv.Name = "textBox_mssv";
            this.textBox_mssv.ReadOnly = true;
            this.textBox_mssv.Size = new System.Drawing.Size(233, 35);
            this.textBox_mssv.TabIndex = 8;
            // 
            // textBox_hoten
            // 
            this.textBox_hoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_hoten.Location = new System.Drawing.Point(12, 253);
            this.textBox_hoten.Name = "textBox_hoten";
            this.textBox_hoten.ReadOnly = true;
            this.textBox_hoten.Size = new System.Drawing.Size(233, 35);
            this.textBox_hoten.TabIndex = 9;
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email.Location = new System.Drawing.Point(13, 334);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.ReadOnly = true;
            this.textBox_email.Size = new System.Drawing.Size(233, 35);
            this.textBox_email.TabIndex = 10;
            // 
            // textBox_sdt
            // 
            this.textBox_sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_sdt.Location = new System.Drawing.Point(13, 419);
            this.textBox_sdt.Name = "textBox_sdt";
            this.textBox_sdt.ReadOnly = true;
            this.textBox_sdt.Size = new System.Drawing.Size(227, 35);
            this.textBox_sdt.TabIndex = 11;
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 515);
            this.Controls.Add(this.textBox_sdt);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_hoten);
            this.Controls.Add(this.textBox_mssv);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label_sdt);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_hoten);
            this.Controls.Add(this.label_mssv);
            this.Controls.Add(this.tracuu);
            this.Controls.Add(this.textBox_mssv_thongke);
            this.Controls.Add(this.label_thongke);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_thongke;
        private System.Windows.Forms.TextBox textBox_mssv_thongke;
        private System.Windows.Forms.Button tracuu;
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