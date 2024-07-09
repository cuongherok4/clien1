using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Specialized;


namespace Đăng_nhập__đăng_xuất
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=ACER-NITRO-5-20\SQLEXPRESS01;Initial Catalog=DuanNet;Integrated Security=True;";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
