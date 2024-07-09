using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đăng_nhập__đăng_xuất
{
    internal class TaiKhoan
    {
        private string tenTaiKhoan;
        private string matKhau;
        private string ten;

        public TaiKhoan() 
        {
        }

        public TaiKhoan(string tenTaiKhoan, string matKhau, string ten)
        {
            this.tenTaiKhoan = tenTaiKhoan;
            this.matKhau = matKhau;
            this.ten = ten;
        }

        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string tem {  get => ten; set => ten = value;}
    }
}
