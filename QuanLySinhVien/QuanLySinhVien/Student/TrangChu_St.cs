using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.Student
{
    public partial class TrangChu_St : Form
    {
        public TrangChu_St()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(ChildForm);
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void bt_xemDiem_Click(object sender, EventArgs e)
        {
            openChildForm(new xemDiem());
        }

        private void bt_nhanTb_Click(object sender, EventArgs e)
        {
            openChildForm(new NhanTb());
        }

        private void bt_UserSt_Click(object sender, EventArgs e)
        {
            openChildForm(new User_St());
        }
    }
}
