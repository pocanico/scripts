using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, EventArgs e)
        {
            string str = "Server=192.168.52.131;Database=mysql;Uid=admin;PWD=123456";
            MySqlConnection con = new MySqlConnection(str);//实例化链接
            con.Open();//开启连接
            string strcmd = "select * from mysql.user";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            //DataTable dt = new DataTable();

            
            DataSet ds = new DataSet();
            DataTable table1 = new DataTable();
            ada.Fill(ds, "table1");
            //dg.DataContext = ds;
            dg.ItemsSource = ds.Tables;
            //ada.Fill(ds);//查询结果填充数据集
            //ada.Fill(ds);            //Console.Write(ds.Tables[0]);
            //dg.DataContext = ds.Tables;
            //dg.DataSource = ds.Tables[0];
            //dg.ItemsSource = ds.Tables;


            ada.Fill(ds, "user");
            DataTable dt = ds.Tables["user"];
            this.dg.ItemsSource = dt.DefaultView;



            con.Close();//关闭连接
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
