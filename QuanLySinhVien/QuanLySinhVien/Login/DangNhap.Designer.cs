using System.Windows.Forms;

namespace QuanLySinhVien
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.showpass = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(355, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // UserBox
            // 
            this.UserBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(164)))), ((int)(((byte)(227)))));
            this.UserBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserBox.Location = new System.Drawing.Point(350, 174);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(294, 25);
            this.UserBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.NavajoWhite;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(350, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Đăng nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.OldLace;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(493, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "Quên mật khẩu";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PassBox
            // 
            this.PassBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(164)))), ((int)(((byte)(227)))));
            this.PassBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassBox.Location = new System.Drawing.Point(350, 235);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(294, 25);
            this.PassBox.TabIndex = 10;
            this.PassBox.UseSystemPasswordChar = true;
            // 
            // showpass
            // 
            this.showpass.AutoSize = true;
            this.showpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(164)))), ((int)(((byte)(227)))));
            this.showpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showpass.Location = new System.Drawing.Point(519, 274);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(125, 20);
            this.showpass.TabIndex = 11;
            this.showpass.Text = "Show Password";
            this.showpass.UseVisualStyleBackColor = false;
            this.showpass.CheckedChanged += new System.EventHandler(this.showpass_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(350, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 1);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(350, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 1);
            this.panel2.TabIndex = 13;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(164)))), ((int)(((byte)(227)))));
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.errorLabel.Location = new System.Drawing.Point(324, 365);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(238, 20);
            this.errorLabel.TabIndex = 14;
            this.errorLabel.Text = "Vui lòng nhập đầy đủ thông tin!";
            this.errorLabel.Visible = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(886, 521);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showpass);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNhap";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.CheckBox showpass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Label errorLabel;
    }
}