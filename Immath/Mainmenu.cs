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
using System.Drawing;
using System.Resources;
namespace Immath
{
    public partial class Mainmenu : Form
    {
        public Login _login = new Login();
        public MySqlDataReader _login_info;
        public Register_students _register_students;
        public Register_teachers _register_teachers;
        public Edit_user _edit_user;
        public Bill _bill;
        public Mainmenu(MySqlDataReader login_info,Login login)
        {
            InitializeComponent();
            _login_info = login_info;
            _login = login;
            label1.Text = label1.Text + " " + _login_info["Name"];
            if (_login_info["Auth"].ToString() == "admin")
            {
                button_register_teacher.Enabled = true;
            }
            else
            {
                button_register_teacher.Enabled = false;
            }
            _register_students = new Register_students(this);
            _register_teachers = new Register_teachers(this);
            _edit_user = new Edit_user(this);
            _bill = new Bill(this);
        }

        private void Mainmenu_Load(object sender, EventArgs e)
        {
            
        }

        private void Mainmenu_Closed(object sender, FormClosedEventArgs e)
        {
            _login.Show();
            _login.clear_password();
        }

        public void button_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            _login.Show();
            _login.clear_password();
        }

        private void button_register_student_Click(object sender, EventArgs e)
        {
            this.Hide();
            _register_students.clear_content();
            _register_students.ShowDialog();
        }

        private void button_register_teacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            _register_teachers.ShowDialog();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            _edit_user.ShowDialog();
        }

        private void button_bill_Click(object sender, EventArgs e)
        {
            this.Hide();

            _bill.ShowDialog();

           
        }
    }
}
