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
    public partial class Mainmenu : Form
    {
        private Login _login = new Login();
        private MySqlDataReader _login_info;
        
        public Mainmenu(MySqlDataReader login_info,Login login)
        {
            InitializeComponent();
            _login_info = login_info;
            _login = login;
            label1.Text = label1.Text + " " + _login_info["Name"];
            
           
        }

        private void Mainmenu_Load(object sender, EventArgs e)
        {
            
        }

        private void Mainmenu_Closed(object sender, FormClosedEventArgs e)
        {
            _login.Show();
            _login.clear_password();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            _login.Show();
            _login.clear_password();
        }

        private void button_register_student_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register_students _register_students = new Register_students(_login_info,this);
            _register_students.Show();
        }

        private void button_register_teacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register_teachers _register_teachers = new Register_teachers(_login_info,this);
            _register_teachers.Show();
        }
    }
}
