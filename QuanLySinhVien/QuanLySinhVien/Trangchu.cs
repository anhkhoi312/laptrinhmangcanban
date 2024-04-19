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
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            ThongKe a  = new ThongKe();
            a.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            QuanLyDiem quanLyDiem = new QuanLyDiem();
            quanLyDiem.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Thongbao a = new Thongbao();
            a.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
