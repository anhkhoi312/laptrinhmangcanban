using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLySinhVien.Chat
{
    public partial class userControlMessage : UserControl
    {
        public userControlMessage(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private string username;
        //sửa nội dung label để hiện thị 
        public void setLabel(string content, string username)
        {
            if (this.username != username) //kiểm tra có phải tin nhắn của bản thân không nếu phải => hiển thị bên phải 
            {
                label2.Visible = true;
                label2.Text = $"{username}: {content}";
                label1.Visible = false;
            }
            else // false => hiển thị bên trái
            {
                label1.Visible = true;
                label1.Text = $"{content} :{username}";
                label2.Visible = false;
            }
        }
        public string getString(string username)
        {
            if (this.username != username)
            {
                if (label2.Text != "label2")
                {
                    return label2.Text;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                if (label1.Text != "label1")
                {
                    return label1.Text;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
