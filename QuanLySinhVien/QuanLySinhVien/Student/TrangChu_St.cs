using QuanLySinhVien.Chat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien.Student
{
    public partial class TrangChu_St : Form
    {
        private List<Button> buttons;
        private Form activeForm = null;
        private Color activeButtonColor = Color.Gray;
        private Color defaultButtonColor = Color.White;

        public TrangChu_St()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            // Thêm các Button vào danh sách
            buttons = new List<Button> { btXemdiem, btThongbao, btDeadline, btChat, btn_video, btUser, bt_dangXuat };

            // Gán sự kiện Click cho mỗi Button
            foreach (var button in buttons)
            {
                button.Click += Button_Click;
            }

            // Gán form tương ứng cho mỗi nút bằng cách sử dụng thuộc tính Tag
            btXemdiem.Tag = new xemDiem();
            btThongbao.Tag = new NhanTb();
            btDeadline.Tag = new Deadline();
            btChat.Tag = new chatBox();
            btn_video.Tag = new video();
            btUser.Tag = new User_St();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Đặt tất cả các Button về màu mặc định
            foreach (var button in buttons)
            {
                button.BackColor = defaultButtonColor;
            }

            // Đặt màu xám cho Button được nhấn
            clickedButton.BackColor = activeButtonColor;

            // Mở Form tương ứng với Button được nhấn
            if (clickedButton.Tag is Form)
            {
                openChildForm(clickedButton.Tag as Form);
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void TrangChu_St_Load(object sender, EventArgs e)
        {

        }
        private void bt_dangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap form = new DangNhap();
            form.ShowDialog();
        }
    }
}
