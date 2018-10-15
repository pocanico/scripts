using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp8
{
    class MySQLConn
    {
        private string MySqlCon = "Database=mysql;datasource=192.168.52.136;port=3306;user=admin;pwd=12345678;SslMode=none;Convert Zero Datetime=True;Allow Zero Datetime=True";
        public DataTable ExecuteQuery(string sqlStr)
        {
            MySqlCommand cmd;
            MySqlConnection con;
            MySqlDataAdapter msda;
            con = new MySqlConnection(MySqlCon);
            con.Open();
            cmd = new MySqlCommand(sqlStr, con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            msda = new MySqlDataAdapter(cmd);
            msda.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
