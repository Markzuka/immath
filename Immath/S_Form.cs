using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Immath
{
    public partial class S_Form : Form
    {
        public string connection = null;
        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;
        public int student_id = 0;
        public S_Form(string con, int id)
        {
            InitializeComponent();
            connection = con;
            student_id = id;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select * from questionnaire where Students_id =?id";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?id", student_id);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    textBox1.Text = rdr["Friend_id"].ToString();
                    textBox2.Text = rdr["Journal"].ToString();
                    textBox3.Text = rdr["Leaflet"].ToString();
                    textBox4.Text = rdr["Etcs"].ToString();
                    if(rdr["Billboards"].ToString() == "1")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                }
                conn.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select * from questionnaire where Students_id= ?id";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?id", student_id);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    conn.Close();
                    conn.Open();
                    SQL = "UPDATE questionnaire SET Journal=?journal,Leaflet=?leaflet,Billboards=?billboards,Etcs=?etcs,Friend_id=?friend_id";
                    command = new MySqlCommand(SQL, conn);
                    command.Parameters.AddWithValue("?journal", textBox2.Text);
                    command.Parameters.AddWithValue("?leaflet", textBox3.Text);
                    if(checkBox1.Checked)
                    {
                        command.Parameters.AddWithValue("?billboards", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("?billboards", 0);
                    }
                   
                    command.Parameters.AddWithValue("?etcs", textBox4.Text);
                    command.Parameters.AddWithValue("?friend_id", textBox1.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("update complete!");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    SQL = "insert into questionnaire(Students_id,Journal,Leaflet,Billboards,Etcs,Friend_id) Values(?students_id,?journal,?leaflet,?billboards,?etcs,?friend_id)";
                    command = new MySqlCommand(SQL, conn);
                    command.Parameters.AddWithValue("?students_id", student_id);
                    command.Parameters.AddWithValue("?journal", textBox2.Text);
                    command.Parameters.AddWithValue("?leaflet", textBox3.Text);
                    if (checkBox1.Checked)
                    {
                        command.Parameters.AddWithValue("?billboards", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("?billboards", 0);
                    }

                    command.Parameters.AddWithValue("?etcs", textBox4.Text);
                    command.Parameters.AddWithValue("?friend_id", textBox1.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("complete");
                    conn.Close();
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

        private void S_Form_Load(object sender, EventArgs e)
        {

        }

        private void S_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
      
        }
    }
}
