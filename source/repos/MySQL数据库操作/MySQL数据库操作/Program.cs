using System;
using MySql.Data.MySqlClient;

namespace MySQL数据库操作
{
    class Program
    {
        static void Main(string[] args)
        {
            // 数据库配置
            string connStr = "Database=mysql;datasource=192.168.52.136;port=3306;user=admin;pwd=12345678;SslMode=none";
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from user", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string host = reader.GetString("host");
                string user = reader.GetString("user");
                Console.WriteLine(user + ":" + host);
            }
            reader.Close();

            cmd.ExecuteNonQuery();
            conn.Close();
            Console.ReadKey();
        }
    }
}