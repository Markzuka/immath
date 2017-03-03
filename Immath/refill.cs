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
    public partial class refill : Form
    {
        public string connection = "server=127.0.0.1; database=immath;user=immath; password=math2017; CharSet=tis620;";
        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;
        CultureInfo ThaiCulture = new CultureInfo("th-TH");
        CultureInfo UsaCulture = new CultureInfo("en-US");
        public List<int> Id = new List<int>();
        public List<int> Code = new List<int>();
        public refill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "UPDATE students SET THB=THB+?THB where Code =?Code";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?THB", Int32.Parse(textBox_thb.Text));
                command.Parameters.AddWithValue("?Code", Int32.Parse(textBox_code.Text));
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "insert into Refill(students_id,Date,Money) Values(?student_id,?date,?money)";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.Clear();
                for(int i=0;i<Id.Count;i++)
                {
                    if(Code[i].ToString()== textBox_code.Text)
                    {
                        command.Parameters.AddWithValue("?student_id", Id[i]);
                    }
                }
                command.Parameters.AddWithValue("?date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
                command.Parameters.AddWithValue("?money", Int32.Parse(textBox_thb.Text));
                command.ExecuteNonQuery();
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
            MessageBox.Show("Complete");
            refill_FormClosed(null, null);
        }

        private void refill_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void refill_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select id,Code from students order by Code ASC";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    Id.Add(rdr.GetInt32(0));
                    Code.Add(rdr.GetInt32(1));
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
