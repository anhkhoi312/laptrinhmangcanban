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
            ThongKe a  = new ThongKe();
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyDiem quanLyDiem = new QuanLyDiem();
            quanLyDiem.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thongbao a = new Thongbao();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
