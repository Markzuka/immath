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
    public partial class Register_teachers : Form
    {
        private MySqlDataReader _login_info;
        private Mainmenu _mainmenu;
        public Register_teachers(Mainmenu mainmenu)
        {
            InitializeComponent();
            _login_info = mainmenu._login_info;
            _mainmenu = mainmenu;
    }

        private void Register_teachers_Load(object sender, EventArgs e)
        {

        }

        private void Register_teachers_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            _mainmenu.Show();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1; database=immath;user=immath; password=math2017; CharSet=tis620;";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "insert into users(Username,Password,Name,Auth,Nickname) Values(?Username,?Password,?Name,?Auth,?Nickname)";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.Add("?Username", textBox1.Text);
                command.Parameters.Add("?Password", "immath555");
                command.Parameters.Add("?Name", textBox2.Text);
                command.Parameters.Add("?Auth", "user");
                command.Parameters.Add("?Nickname", textBox3.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Register complete!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
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
