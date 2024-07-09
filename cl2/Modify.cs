using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Đăng_nhập__đăng_xuất
{
    internal class Modify
    {
        public Modify() 
        { 
        }

        SqlCommand sqlCommand;// dung de truy van cac cau lenh 
        SqlDataReader dataReader; // dung de doc gia tri trong bang

        public List<TaiKhoan> TaiKhoans(string query)// check tai khoan
        {
            List<TaiKhoan> taikhoans = new List<TaiKhoan>();

            using(SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while(dataReader.Read())
                {
                    taikhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(3), dataReader.GetString(1)));

                }
                sqlConnection.Close();
            }
            return taikhoans;
        }
        public void Command(string query)
        {
            using(SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();// thuc thi cau truy van 
                sqlConnection.Close();
            }
        }
    }
}
