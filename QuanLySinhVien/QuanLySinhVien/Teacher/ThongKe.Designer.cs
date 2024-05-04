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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKe));
            this.tracuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tb_rotmon = new System.Windows.Forms.TextBox();
            this.tb_quamon = new System.Windows.Forms.TextBox();
            this.comboBox_mssv = new System.Windows.Forms.ComboBox();
            this.label_monhoc_qld = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tracuu
            // 
            this.tracuu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tracuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tracuu.Location = new System.Drawing.Point(702, 35);
            this.tracuu.Margin = new System.Windows.Forms.Padding(2);
            this.tracuu.Name = "tracuu";
            this.tracuu.Size = new System.Drawing.Size(116, 37);
            this.tracuu.TabIndex = 2;
            this.tracuu.Text = "Tra cứu";
            this.tracuu.UseVisualStyleBackColor = false;
            this.tracuu.Click += new System.EventHandler(this.tracuu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(372, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Qua môn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(661, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rớt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tổng cộng";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(192, 126);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(119, 29);
            this.textBox1.TabIndex = 11;
            // 
            // tb_rotmon
            // 
            this.tb_rotmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_rotmon.Location = new System.Drawing.Point(736, 126);
            this.tb_rotmon.Margin = new System.Windows.Forms.Padding(2);
            this.tb_rotmon.Multiline = true;
            this.tb_rotmon.Name = "tb_rotmon";
            this.tb_rotmon.ReadOnly = true;
            this.tb_rotmon.Size = new System.Drawing.Size(119, 29);
            this.tb_rotmon.TabIndex = 12;
            // 
            // tb_quamon
            // 
            this.tb_quamon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_quamon.Location = new System.Drawing.Point(485, 126);
            this.tb_quamon.Margin = new System.Windows.Forms.Padding(2);
            this.tb_quamon.Multiline = true;
            this.tb_quamon.Name = "tb_quamon";
            this.tb_quamon.ReadOnly = true;
            this.tb_quamon.Size = new System.Drawing.Size(119, 29);
            this.tb_quamon.TabIndex = 13;
            // 
            // comboBox_mssv
            // 
            this.comboBox_mssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_mssv.FormattingEnabled = true;
            this.comboBox_mssv.Location = new System.Drawing.Point(248, 37);
            this.comboBox_mssv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_mssv.Name = "comboBox_mssv";
            this.comboBox_mssv.Size = new System.Drawing.Size(374, 37);
            this.comboBox_mssv.TabIndex = 21;
            // 
            // label_monhoc_qld
            // 
            this.label_monhoc_qld.AutoSize = true;
            this.label_monhoc_qld.BackColor = System.Drawing.Color.Transparent;
            this.label_monhoc_qld.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_monhoc_qld.Location = new System.Drawing.Point(128, 38);
            this.label_monhoc_qld.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_monhoc_qld.Name = "label_monhoc_qld";
            this.label_monhoc_qld.Size = new System.Drawing.Size(114, 29);
            this.label_monhoc_qld.TabIndex = 20;
            this.label_monhoc_qld.Text = "Chọn lớp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(412, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 29);
            this.label5.TabIndex = 32;
            this.label5.Text = "DANH SÁCH";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSSV,
            this.QT,
            this.GK,
            this.CK,
            this.TBM});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(98, 257);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(744, 216);
            this.dataGridView1.TabIndex = 34;
            // 
            // MSSV
            // 
            this.MSSV.HeaderText = "MSSV";
            this.MSSV.MinimumWidth = 6;
            this.MSSV.Name = "MSSV";
            this.MSSV.ReadOnly = true;
            this.MSSV.Width = 125;
            // 
            // QT
            // 
            this.QT.HeaderText = "QT";
            this.QT.MinimumWidth = 6;
            this.QT.Name = "QT";
            this.QT.ReadOnly = true;
            this.QT.Width = 125;
            // 
            // GK
            // 
            this.GK.HeaderText = "GK";
            this.GK.MinimumWidth = 6;
            this.GK.Name = "GK";
            this.GK.ReadOnly = true;
            this.GK.Width = 125;
            // 
            // CK
            // 
            this.CK.HeaderText = "CK";
            this.CK.MinimumWidth = 6;
            this.CK.Name = "CK";
            this.CK.ReadOnly = true;
            this.CK.Width = 125;
            // 
            // TBM
            // 
            this.TBM.HeaderText = "TBM";
            this.TBM.MinimumWidth = 6;
            this.TBM.Name = "TBM";
            this.TBM.ReadOnly = true;
            this.TBM.Width = 125;
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(918, 509);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_mssv);
            this.Controls.Add(this.label_monhoc_qld);
            this.Controls.Add(this.tb_quamon);
            this.Controls.Add(this.tb_rotmon);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tracuu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button tracuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tb_rotmon;
        private System.Windows.Forms.TextBox tb_quamon;
        private System.Windows.Forms.ComboBox comboBox_mssv;
        private System.Windows.Forms.Label label_monhoc_qld;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBM;
    }
}