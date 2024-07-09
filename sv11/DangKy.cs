using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;

namespace Đăng_nhập__đăng_xuất
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public bool CheckAccount(string ac)// check mk, tk 
        {
            return Regex.IsMatch(ac, @"^[a-zA-Z0-9]{6,24}$");
        }

        public bool CheckEmail(string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9]{6,24}@gmail.com$");
        }
        Modify modify = new Modify();
        private void button_DangKy_Click(object sender, EventArgs e)
        {
            string Ho = txtho.Text;
            string Ten = txtten.Text;
            string Email = txtemail.Text;
            string MK = txtmk.Text;

            string Mk2 = txtmk2.Text;
            string date = txtdate.Text;
            string gioitinh = cbbgioitinh.Text;
            if (!CheckAccount(Email)) { MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-25 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường! "); return; }
            if (!CheckAccount(MK)) { MessageBox.Show("Vui lòng nhập mật khẩu dài 6-25 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường! "); return; }
            if (Mk2 != MK) { MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác!"); return; }
            if (modify.TaiKhoans("Select * from TaiKhoan where email = '" + Email + "'").Count != 0) { MessageBox.Show("Email này đã được đăng kí! Vui lòng đăng kí Email khác"); return; }
            if(Ho=="" || Ten=="" || date =="" || gioitinh == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đu thông tin"); return;
            }
            try
            {

                string query = "Insert into TaiKhoan values (N'" + Ho + "',N'" + Ten + "','" + Email + "',N'" + MK + "','" + date + "',N'" + gioitinh + "')";
                modify.Command(query);
                if (MessageBox.Show("Đăng kí thành công, bạn có muốn đăng nhập luôn không?", "tiêu đề", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã được đăng kí, vui lòng đăng kí tên tài khoản khác!");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Date_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
        }
    
    }
}
