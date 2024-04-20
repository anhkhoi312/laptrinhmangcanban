namespace QuanLySinhVien.Student
{
    partial class NhanTb
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
            this.label2 = new System.Windows.Forms.Label();
            this.TEN_GV = new System.Windows.Forms.CheckedListBox();
            this.THONG_BAO = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách thông báo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nội dung";
            // 
            // TEN_GV
            // 
            this.TEN_GV.FormattingEnabled = true;
            this.TEN_GV.Location = new System.Drawing.Point(25, 41);
            this.TEN_GV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TEN_GV.Name = "TEN_GV";
            this.TEN_GV.Size = new System.Drawing.Size(143, 123);
            this.TEN_GV.TabIndex = 2;
            // 
            // THONG_BAO
            // 
            this.THONG_BAO.FormattingEnabled = true;
            this.THONG_BAO.ItemHeight = 16;
            this.THONG_BAO.Location = new System.Drawing.Point(222, 38);
            this.THONG_BAO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.THONG_BAO.Name = "THONG_BAO";
            this.THONG_BAO.Size = new System.Drawing.Size(143, 132);
            this.THONG_BAO.TabIndex = 3;
            // 
            // NhanTb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 208);
            this.Controls.Add(this.THONG_BAO);
            this.Controls.Add(this.TEN_GV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NhanTb";
            this.Text = "NhanTb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox TEN_GV;
        private System.Windows.Forms.ListBox THONG_BAO;
    }
}