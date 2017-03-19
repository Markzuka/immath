using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Immath
{
    public partial class Edit_user : Form
    {
        private MySqlDataReader _login_info;
        private Mainmenu _mainmenu;
        public string connection = null;
        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;
        public Edit_user(Mainmenu mainmenu)
        {
            InitializeComponent();
            _mainmenu = mainmenu;
            _login_info = _mainmenu._login_info;
            textBox1.Text = _login_info["Username"].ToString();
            textBox2.Text = _login_info["Password"].ToString();
            textBox3.Text = _login_info["Name"].ToString();
            textBox4.Text = _login_info["Nickname"].ToString();
            connection = File.ReadAllText(Directory.GetCurrentDirectory() + "/condb.txt");
        }

        private void Edit_user_Load(object sender, EventArgs e)
        {

        }

        private void Edit_user_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            _mainmenu.Show();
        }

        private void button_edit_user_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "UPDATE users SET Username=?Username,Password=?Password,Name=?Name,Nickname=?Nickname where id =?id";
       
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?Username", textBox1.Text);
                command.Parameters.AddWithValue("?Password", textBox2.Text);
                command.Parameters.AddWithValue("?Name", textBox3.Text);
                command.Parameters.AddWithValue("?Nickname", textBox4.Text);
                command.Parameters.AddWithValue("?id", _login_info["id"]);
                command.ExecuteNonQuery();
                MessageBox.Show("update complete!");
                this.Hide();
                _mainmenu.button_logout_Click(null,null);
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
