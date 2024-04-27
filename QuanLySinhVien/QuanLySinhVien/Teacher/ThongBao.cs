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
    public partial class ThongBao : Form
    {
        public ThongBao()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            timerLabel.Text = dateTime.ToString();
        }
        private void ThongBao_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void comboBox_mssv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
