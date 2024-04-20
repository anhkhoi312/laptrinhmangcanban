using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class TrangChu_Tea : Form
    {
        public TrangChu_Tea()
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
        private void btNhapDiem_Click_1(object sender, EventArgs e)
        {
            openChildForm(new QuanLyDiem());
        }

        private void btThongKe_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ThongKe());
        }

        private void btThongBao_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ThongBao());
        }

        private void btDsLop_Click_1(object sender, EventArgs e)
        {
            openChildForm(new QuanLyLop());
        }

        private void bt_User_Click(object sender, EventArgs e)
        {
            openChildForm(new User_Tea ());
        }

        private void TrangChu_Tea_Load(object sender, EventArgs e)
        {

        }
    }
}
