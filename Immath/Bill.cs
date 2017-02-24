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
    public partial class Bill : Form
    {
        private Mainmenu _mainmenu;
        private MySqlDataReader _login_info;
        public Bill(Mainmenu mainmenu)
        {
            InitializeComponent();
            _login_info = mainmenu._login_info;
            _mainmenu = mainmenu;
            clear_value();
        }
        public void clear_value()
        {
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            numericUpDown4.Visible = false;
            numericUpDown5.Visible = false;
            numericUpDown6.Visible = false;
            numericUpDown7.Visible = false;
            numericUpDown8.Visible = false;
            numericUpDown9.Visible = false;
            numericUpDown10.Visible = false;
            numericUpDown11.Visible = false;
            numericUpDown12.Visible = false;
            numericUpDown13.Visible = false;
            numericUpDown14.Visible = false;
            numericUpDown15.Visible = false;

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            int bill_no = int.Parse(File.ReadAllText(Directory.GetCurrentDirectory()+"/bill_no.txt"));
            int book_no = int.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "/book_no.txt"));
            //book_no = book_no + 29;
            //File.WriteAllText(Directory.GetCurrentDirectory() + "/book_no.txt", book_no.ToString());
        }

        private void Bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            _mainmenu.Show();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            if(numericUpDown_count.Value == 1)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = false;
                numericUpDown3.Visible = false;
                numericUpDown4.Visible = false;
                numericUpDown5.Visible = false;
                numericUpDown6.Visible = false;
                numericUpDown7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;

            }
            else if(numericUpDown_count.Value == 2)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = false;
                numericUpDown4.Visible = false;
                numericUpDown5.Visible = false;
                numericUpDown6.Visible = false;
                numericUpDown7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 3)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = false;
                numericUpDown5.Visible = false;
                numericUpDown6.Visible = false;
                numericUpDown7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 4)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = false;
                numericUpDown6.Visible = false;
                numericUpDown7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;

            }
            else if (numericUpDown_count.Value == 5)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = false;
                numericUpDown7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 6)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = false;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 7)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 8)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = false;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 9)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
                numericUpDown10.Visible = false;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 10)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
                numericUpDown10.Visible = true;
                numericUpDown11.Visible = false;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 11)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
                numericUpDown10.Visible = true;
                numericUpDown11.Visible = true;
                numericUpDown12.Visible = false;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 12)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
                numericUpDown10.Visible = true;
                numericUpDown11.Visible = true;
                numericUpDown12.Visible = true;
                numericUpDown13.Visible = false;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 13)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
                numericUpDown10.Visible = true;
                numericUpDown11.Visible = true;
                numericUpDown12.Visible = true;
                numericUpDown13.Visible = true;
                numericUpDown14.Visible = false;
                numericUpDown15.Visible = false;
            }
            else if (numericUpDown_count.Value == 14)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
                numericUpDown10.Visible = true;
                numericUpDown11.Visible = true;
                numericUpDown12.Visible = true;
                numericUpDown13.Visible = true;
                numericUpDown14.Visible = true;
                numericUpDown15.Visible = false;
            }
            else if(numericUpDown_count.Value == 15)
            {
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                numericUpDown5.Visible = true;
                numericUpDown6.Visible = true;
                numericUpDown7.Visible = true;
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
                numericUpDown10.Visible = true;
                numericUpDown11.Visible = true;
                numericUpDown12.Visible = true;
                numericUpDown13.Visible = true;
                numericUpDown14.Visible = true;
                numericUpDown15.Visible = true;
            }
            else
            {
                clear_value();
            }
        }
    }
}
