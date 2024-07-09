using ServerFormsMultiThread;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
       
        private void linkLabel_QuyenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           this.Hide();
            Quyenmk qmk = new Quyenmk();
            qmk.ShowDialog();
        }
    

        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
            this.Close();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();   
        

        private void TenTKtextBox__TextChanged(object sender, EventArgs e)
        {

        }

        private void chkhienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhienthi.Checked == true)
            {
                textBox_MatKhau.PasswordChar = '\0';
            }
            else
            {
                textBox_MatKhau.PasswordChar = '●';
            }
        }

        private void textBox_MatKhau_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tentk = textBox_TentaiKhoan.Text;
            string matkhau = textBox_MatKhau.Text;
            if (tentk.Trim() == "") { MessageBox.Show("Vui lòng nhập tên tài khoản!"); }
            else if (matkhau.Trim() == "") { MessageBox.Show("vui lòng nhập mật khẩu! "); }
            else
            {
                string query = "Select * from TaiKhoan where email = '" + tentk + "' and matkhau = '" + matkhau + "' ";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    this.Hide();
                    ServerForm hm = new ServerForm();
                    hm.ShowDialog();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        // chuyển qua item đăng kí
       
        private void btndangki_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
    }
    }
}
