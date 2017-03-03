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
        public string connection = null;
        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;
        public Register_teachers(Mainmenu mainmenu)
        {
            InitializeComponent();
            _login_info = mainmenu._login_info;
            _mainmenu = mainmenu;
            connection = _mainmenu.connection;
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

            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "insert into users(Username,Password,Name,Auth,Nickname,moneytype) Values(?Username,?Password,?Name,?Auth,?Nickname,?moneytype)";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?Username", textBox1.Text);
                command.Parameters.AddWithValue("?Password", "immath555");
                command.Parameters.AddWithValue("?Name", textBox2.Text);
                command.Parameters.AddWithValue("?Auth", "user");
                command.Parameters.AddWithValue("?Nickname", textBox3.Text);
                command.Parameters.AddWithValue("?moneytype", 1);
                command.ExecuteNonQuery();
                MessageBox.Show("Register complete!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
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
    }
}
