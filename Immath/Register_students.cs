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
    public partial class Register_students : Form
    {
        private Mainmenu _mainmenu;
        private MySqlDataReader _login_info;
        public Register_students(Mainmenu mainmenu)
        {
            InitializeComponent();
            _login_info = mainmenu._login_info;
            _mainmenu = mainmenu;
        }

        private void Register_students_Load(object sender, EventArgs e)
        {

        }

        private void Register_students_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            _mainmenu.Show();

        }
    }
}
