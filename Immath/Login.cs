using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Immath
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
   
        }
        public void clear_password()
        {
            PasswordTB.Text = "";
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1; database=immath;user=immath; password=math2017; CharSet=tis620;";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                
                string SQL = "select * from users where username='"+ UsernameTB.Text+"' and password='"+ PasswordTB.Text + "'";
                MySqlCommand command = new MySqlCommand(SQL,conn);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    //MessageBox.Show(rdr.GetInt32(0) + ": "+ rdr["name"]);
                    this.Hide();
                    Mainmenu mainmenu = new Mainmenu(rdr,this);
                    mainmenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("wrong username or password");
                    UsernameTB.Text = "";
                    PasswordTB.Text = "";
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

        private void PasswordTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button_login_Click(null, null);

            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Environment.Exit(0);
        }
    }
}
