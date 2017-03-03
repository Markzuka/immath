using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Immath
{
    public partial class CancelBill : Form
    {
        public string connection = "server=127.0.0.1; database=immath;user=immath; password=math2017; CharSet=tis620;";
        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;
        CultureInfo ThaiCulture = new CultureInfo("th-TH");
        CultureInfo UsaCulture = new CultureInfo("en-US");
        public CancelBill()
        {
            InitializeComponent();
        }

        private void CancelBill_Load(object sender, EventArgs e)
        {

        }

        private void CancelBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connection);
                var conn2 = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select * from bills where (Delete_date is null) and (Book_no = ?Book_no) and (Bill_no = ?Bill_no)";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?Book_no", Int32.Parse( textBox1.Text));
                command.Parameters.AddWithValue("?Bill_no", Int32.Parse( textBox2.Text));
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    MessageBox.Show(rdr["Price_Students"].ToString());
                    conn2.Open();
                    string SQL2 = "update bills set Delete_date=?Delete_date where Datetime =?Datetime";
                    MySqlCommand command2 = new MySqlCommand(SQL2, conn2);
                    command2.Parameters.AddWithValue("?Delete_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
                    command2.Parameters.AddWithValue("?Datetime", rdr["Datetime"]);
                    command2.ExecuteNonQuery();
                    conn2.Close();
                    conn2.Open();
                    SQL2 = "update students set THB=THB+?Thb where id =?id";
                    command2 = new MySqlCommand(SQL2, conn2);
                    command2.Parameters.AddWithValue("?Thb", rdr["Price_Students"]);
                    command2.Parameters.AddWithValue("?id", rdr["Students_id"]);
                    command2.ExecuteNonQuery();
                    conn2.Close();

                }
                if(!rdr.HasRows)
                {
                    MessageBox.Show("dont have or deleted!");
                }
                else
                {
                    MessageBox.Show("Complete!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
           
        }
    }
}
