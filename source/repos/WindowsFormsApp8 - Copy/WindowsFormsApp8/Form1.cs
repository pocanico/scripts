using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime timer = new DateTime();
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            dateTimePicker1.Text = year + "/1/1";
            //dateTimePicker1.Text = year + "/" + month + "/1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string name = textBox1.Text;
            string ip = textBox2.Text;
            MySQLConn con = new MySQLConn();
            //string sql = string.Format("select name from person where date(birthday) between {0} and {1}", date1,date2);
            string sql = "select * from person where name like '%"+name+"%' and ip like '%"+ip+"%' and date(birthday) between '"+date1+"' and '"+date2+"'";
            //string sql = "select * from person where date(birthday) between '2018-10-13' and '2018-10-13'";
            //string sql = "select name from person";
            //MessageBox.Show(sql);
            dataGridView1.DataSource = con.ExecuteQuery(sql);
        }
    }
}
