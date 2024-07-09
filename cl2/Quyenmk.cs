using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đăng_nhập__đăng_xuất
{
    public partial class Quyenmk : Form
    {
        public Quyenmk()
        {
            InitializeComponent();
            
        }
        Modify modify = new Modify();
        private void Quyenmk_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_laylaimk_Click(object sender, EventArgs e)
        {
            string email = textBox_emDangki.Text;
            if(email.Trim() =="") { MessageBox.Show("Vui lòng nhập email đăng kí!"); }
            else
            {
                string query = "Select * from TaiKhoan where email = '"+email+"'";
                if(modify.TaiKhoans(query).Count !=0) 
                {
                    txtkq.ForeColor = Color.Blue;
                    txtkq.Text =  modify.TaiKhoans(query)[0].MatKhau;
                    
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Email này chưa đươc đăng kí:";
                }

                if (modify.TaiKhoans(query).Count != 0)
                {
                    if (MessageBox.Show("Mật khẩu của bạn là: " + modify.TaiKhoans(query)[0].MatKhau +"\n bạn có muốn đăng nhập luôn không?", "tiêu đề", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        DangNhap dangNhap = new DangNhap();
                        dangNhap.ShowDialog();
                        this.Hide();

                    }

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
