using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
//一个方法类，里面实现,数据库连接，shp新建、更新,并能把数据返回给form用于显示
//为避免新建对象，所有函数均采用static形式
namespace DesktopWindowsApplication1
{
    public class DataLoad
    {
        private SqlConnection conn;
        private void ConnectDatabase()
        {
            String conString = "server=47.99.196.197;database=CLASS;uid=class;pwd=ae2021";
            conn = new SqlConnection(conString);
            conn.Open();
            if (conn.State != ConnectionState.Open)
                MessageBox.Show("ERROR!!!");
            else
            {
                MessageBox.Show("connection succeed!!!");
            }
        }
        public SqlDataReader ExecuteSQL(string sql)
        {
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();
            return dr;
        }

        //构造函数
        public DataLoad()
        {
            ConnectDatabase();
        }
        ~DataLoad()
        {
            //conn.Close();
        }




    }
}
