using QuanLySinhVien.Chat;
using QuanLySinhVien.Student;
using QuanLySinhVien.Teacher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class TrangChu_Tea : Form
    {
        private List<Button> buttons;
        private Form activeForm = null;
        private Color activeButtonColor = Color.Gray;
        private Color defaultButtonColor = Color.White;

        private Dictionary<Button, Form> buttonFormMapping;

        public TrangChu_Tea()
        {
            InitializeComponent();
            InitializeButtons();
            InitializeButtonFormMapping();
        }

        private void InitializeButtons()
        {
            // Thêm các Button vào danh sách
            buttons = new List<Button> { btNhapDiem, btThongKe, btThongBao, btDsLop, bt_User, btTask, bt_dangXuat, button1 };

            // Gán sự kiện Click cho mỗi Button
            foreach (var button in buttons)
            {
                button.Click += Button_Click;
            }
        }

        private void InitializeButtonFormMapping()
        {
            buttonFormMapping = new Dictionary<Button, Form>
            {
                { btNhapDiem, new QuanLyDiem() },
                { btThongKe, new ThongKe() },
                { btThongBao, new ThongBao() },
                { btDsLop, new QuanLyLop() },
                { bt_User, new User_Tea() },
                { btTask, new giaoTask() },
                { button1, new chatBox() }
            };
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


            // Gán form tương ứng cho mỗi nút bằng cách sử dụng thuộc tính Tag
            btNhapDiem.Tag = new QuanLyDiem();
            btThongKe.Tag = new ThongKe();
            btThongBao.Tag = new ThongBao();
            btDsLop.Tag = new QuanLyLop();
            bt_User.Tag = new User_Tea();
            btTask.Tag = new giaoTask();
            button1.Tag = new chatBox();

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

        private void TrangChu_Tea_Load(object sender, EventArgs e)
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
