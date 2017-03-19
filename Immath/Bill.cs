using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        public string connection = null;
        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;
        public List<int> Code = new List<int>();
        public List<string> Firstname = new List<string>();
        public List<int> Id = new List<int>();
        public int bill_no = int.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "/bill_no.txt"));
        public int book_no = int.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "/book_no.txt"));
        CultureInfo ThaiCulture = new CultureInfo("th-TH");
        CultureInfo UsaCulture = new CultureInfo("en-US");

        public Bill(Mainmenu mainmenu)
        {
            InitializeComponent();
            _login_info = mainmenu._login_info;
            _mainmenu = mainmenu;
            connection = File.ReadAllText(Directory.GetCurrentDirectory() + "/condb.txt");
            clear_value();
        }

        public void clear_value()
        {
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            comboBox9.Visible = false;
            comboBox10.Visible = false;
            comboBox11.Visible = false;
            comboBox12.Visible = false;
            comboBox13.Visible = false;
            comboBox14.Visible = false;
            comboBox15.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
        }

        private void updatebill_no()
        {
            label_book_no.Text = "เล่มที่ :"+book_no;
            label_bill_no.Text = "หมายเลข :" + bill_no;

        }

        private void addbill_no()
        {
            bill_no = bill_no+1;
            File.WriteAllText(Directory.GetCurrentDirectory() + "/bill_no.txt", bill_no.ToString());
            updatebill_no();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            updatebill_no();
            object[] school_level = new object[] { "ประถม","ม.ต้น","ม.ปลาย" };
            comboBox_Class.Items.AddRange(school_level);
            comboBox_Class.SelectedIndex = 0;

            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select Code,Nickname,id from students order by Code ASC";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    Code.Add(rdr.GetInt32(0));
                    Firstname.Add(rdr.GetString(1));
                    Id.Add(rdr.GetInt32(2));
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
            
            button_load_Click(null, null);
        }

        private void Bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            _mainmenu.Show();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            if(numericUpDown_count.Value == 1)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if(numericUpDown_count.Value == 2)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 3)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 4)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;

            }
            else if (numericUpDown_count.Value == 5)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 6)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 7)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 8)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 9)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 10)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = true;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 11)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = true;
                comboBox11.Visible = true;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 12)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = true;
                comboBox11.Visible = true;
                comboBox12.Visible = true;
                comboBox13.Visible = false;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 13)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = true;
                comboBox11.Visible = true;
                comboBox12.Visible = true;
                comboBox13.Visible = true;
                comboBox14.Visible = false;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = false;
                label15.Visible = false;
            }
            else if (numericUpDown_count.Value == 14)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = true;
                comboBox11.Visible = true;
                comboBox12.Visible = true;
                comboBox13.Visible = true;
                comboBox14.Visible = true;
                comboBox15.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = false;
            }
            else if(numericUpDown_count.Value == 15)
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                comboBox7.Visible = true;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = true;
                comboBox11.Visible = true;
                comboBox12.Visible = true;
                comboBox13.Visible = true;
                comboBox14.Visible = true;
                comboBox15.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
            }
            
        }
        
        private void button_save_Click(object sender, EventArgs e)
        {
            int Users_id = (int)_login_info["id"];
            int[] Students_id= { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            double Hour;
            double Price_Students;
            double Price_Users;
            int Bill_no;
            int Book_no;
            Boolean EP;
            String Class="";
            if(numericUpDown_count.Value == 1)
            {
                try
                {
                    for(int i = 0; i < Code.Count; i++)
                    {
                        if(comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text,Int32.Parse(numericUpDown_count.Value.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 2)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 3)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 4)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 5)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 6)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 7)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
             
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 8)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
     

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 9)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
                        if (comboBox9.Text == Code[i].ToString())
                        {
                            Students_id[8] = Id[i];
                        }
                        

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[8], Hour, DateTime.Now.AddSeconds(8).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 10)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
                        if (comboBox9.Text == Code[i].ToString())
                        {
                            Students_id[8] = Id[i];
                        }
                        if (comboBox10.Text == Code[i].ToString())
                        {
                            Students_id[9] = Id[i];
                        }
                        
                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[8], Hour, DateTime.Now.AddSeconds(8).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[9], Hour, DateTime.Now.AddSeconds(9).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 11)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
                        if (comboBox9.Text == Code[i].ToString())
                        {
                            Students_id[8] = Id[i];
                        }
                        if (comboBox10.Text == Code[i].ToString())
                        {
                            Students_id[9] = Id[i];
                        }
                        if (comboBox11.Text == Code[i].ToString())
                        {
                            Students_id[10] = Id[i];
                        }
                        

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[8], Hour, DateTime.Now.AddSeconds(8).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[9], Hour, DateTime.Now.AddSeconds(9).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[10], Hour, DateTime.Now.AddSeconds(10).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 12)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
                        if (comboBox9.Text == Code[i].ToString())
                        {
                            Students_id[8] = Id[i];
                        }
                        if (comboBox10.Text == Code[i].ToString())
                        {
                            Students_id[9] = Id[i];
                        }
                        if (comboBox11.Text == Code[i].ToString())
                        {
                            Students_id[10] = Id[i];
                        }
                        if (comboBox12.Text == Code[i].ToString())
                        {
                            Students_id[11] = Id[i];
                        }
                       
                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[8], Hour, DateTime.Now.AddSeconds(8).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[9], Hour, DateTime.Now.AddSeconds(9).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[10], Hour, DateTime.Now.AddSeconds(10).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[11], Hour, DateTime.Now.AddSeconds(11).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
      
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 13)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
                        if (comboBox9.Text == Code[i].ToString())
                        {
                            Students_id[8] = Id[i];
                        }
                        if (comboBox10.Text == Code[i].ToString())
                        {
                            Students_id[9] = Id[i];
                        }
                        if (comboBox11.Text == Code[i].ToString())
                        {
                            Students_id[10] = Id[i];
                        }
                        if (comboBox12.Text == Code[i].ToString())
                        {
                            Students_id[11] = Id[i];
                        }
                        if (comboBox13.Text == Code[i].ToString())
                        {
                            Students_id[12] = Id[i];
                        }
               

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[8], Hour, DateTime.Now.AddSeconds(8).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[9], Hour, DateTime.Now.AddSeconds(9).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[10], Hour, DateTime.Now.AddSeconds(10).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[11], Hour, DateTime.Now.AddSeconds(11).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[12], Hour, DateTime.Now.AddSeconds(12).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 14)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
                        if (comboBox9.Text == Code[i].ToString())
                        {
                            Students_id[8] = Id[i];
                        }
                        if (comboBox10.Text == Code[i].ToString())
                        {
                            Students_id[9] = Id[i];
                        }
                        if (comboBox11.Text == Code[i].ToString())
                        {
                            Students_id[10] = Id[i];
                        }
                        if (comboBox12.Text == Code[i].ToString())
                        {
                            Students_id[11] = Id[i];
                        }
                        if (comboBox13.Text == Code[i].ToString())
                        {
                            Students_id[12] = Id[i];
                        }
                        if (comboBox14.Text == Code[i].ToString())
                        {
                            Students_id[13] = Id[i];
                        }
      

                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[8], Hour, DateTime.Now.AddSeconds(8).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[9], Hour, DateTime.Now.AddSeconds(9).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[10], Hour, DateTime.Now.AddSeconds(10).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[11], Hour, DateTime.Now.AddSeconds(11).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[12], Hour, DateTime.Now.AddSeconds(12).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[13], Hour, DateTime.Now.AddSeconds(13).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (numericUpDown_count.Value == 15)
            {
                try
                {
                    for (int i = 0; i < Code.Count; i++)
                    {
                        if (comboBox1.Text == Code[i].ToString())
                        {
                            Students_id[0] = Id[i];
                        }
                        if (comboBox2.Text == Code[i].ToString())
                        {
                            Students_id[1] = Id[i];
                        }
                        if (comboBox3.Text == Code[i].ToString())
                        {
                            Students_id[2] = Id[i];
                        }
                        if (comboBox4.Text == Code[i].ToString())
                        {
                            Students_id[3] = Id[i];
                        }
                        if (comboBox5.Text == Code[i].ToString())
                        {
                            Students_id[4] = Id[i];
                        }
                        if (comboBox6.Text == Code[i].ToString())
                        {
                            Students_id[5] = Id[i];
                        }
                        if (comboBox7.Text == Code[i].ToString())
                        {
                            Students_id[6] = Id[i];
                        }
                        if (comboBox8.Text == Code[i].ToString())
                        {
                            Students_id[7] = Id[i];
                        }
                        if (comboBox9.Text == Code[i].ToString())
                        {
                            Students_id[8] = Id[i];
                        }
                        if (comboBox10.Text == Code[i].ToString())
                        {
                            Students_id[9] = Id[i];
                        }
                        if (comboBox11.Text == Code[i].ToString())
                        {
                            Students_id[10] = Id[i];
                        }
                        if (comboBox12.Text == Code[i].ToString())
                        {
                            Students_id[11] = Id[i];
                        }
                        if (comboBox13.Text == Code[i].ToString())
                        {
                            Students_id[12] = Id[i];
                        }
                        if (comboBox14.Text == Code[i].ToString())
                        {
                            Students_id[13] = Id[i];
                        }
                        if (comboBox15.Text == Code[i].ToString())
                        {
                            Students_id[14] = Id[i];
                        }
                        
                    }
                    Hour = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;
                    Bill_no = bill_no;
                    Book_no = book_no;
                    EP = checkBox_EP.Checked;
                    Class = comboBox_Class.Text;
                    Price_Students = Cal_student(1, EP, Class, Hour);
                    Price_Users = Cal_teacher(1, EP, Class, Hour, (int)_login_info["moneytype"]);
                    create_bill((int)_login_info["id"], Students_id[0], Hour, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[1], Hour, DateTime.Now.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[2], Hour, DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[3], Hour, DateTime.Now.AddSeconds(3).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[4], Hour, DateTime.Now.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[5], Hour, DateTime.Now.AddSeconds(5).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[6], Hour, DateTime.Now.AddSeconds(6).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[7], Hour, DateTime.Now.AddSeconds(7).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[8], Hour, DateTime.Now.AddSeconds(8).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[9], Hour, DateTime.Now.AddSeconds(9).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[10], Hour, DateTime.Now.AddSeconds(10).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[11], Hour, DateTime.Now.AddSeconds(11).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[12], Hour, DateTime.Now.AddSeconds(12).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[13], Hour, DateTime.Now.AddSeconds(13).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    create_bill((int)_login_info["id"], Students_id[14], Hour, DateTime.Now.AddSeconds(14).ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), Price_Students, Price_Users, Bill_no, Book_no, EP, Class, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture), textBox_Subject.Text, Int32.Parse(numericUpDown_count.Value.ToString()));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Complete");
            addbill_no();
            Bill_FormClosed(null, null);
        }

        public void create_bill(int user_id,int student_id,double hour,string date,double prices,double pricet,int bill,int book,Boolean ep,string c,string starttime,string subject,int people)
        {
            int eps;
            try
            {
                conn.Open();
                String SQL = "insert into bills (Users_id,Students_id,Hour,Datetime,Price_Students,Price_Users,Delete_date,Bill_no,Book_no,EP,Class,Starttime,Subject,people) Values(?Users_id,?Students_id,?Hour,?Datetime,?Price_Students,?Price_Users,null,?Bill_no,?Book_no,?EP,?Class,?Starttime,?Subject,?people)";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?Users_id", user_id);
                command.Parameters.AddWithValue("?Students_id", student_id);
                command.Parameters.AddWithValue("?Hour", hour);
                command.Parameters.AddWithValue("?Datetime", date);
                command.Parameters.AddWithValue("?Price_Students", prices);
                command.Parameters.AddWithValue("?Price_Users", pricet);
                command.Parameters.AddWithValue("?Bill_no", bill);
                command.Parameters.AddWithValue("?Book_no", book);
                if (ep == true)
                {
                    eps = 0;
                }
                else
                {
                    eps = 1;
                }
                command.Parameters.AddWithValue("?EP", eps);
                command.Parameters.AddWithValue("?Class", c);
                command.Parameters.AddWithValue("?Starttime", starttime);
                command.Parameters.AddWithValue("?Subject", subject);
                command.Parameters.AddWithValue("?people", people);
                command.ExecuteNonQuery();
                conn.Close();
                try
                {
                    conn.Open();
                    SQL = "UPDATE students SET THB=THB-?THB where id =?id";
                    command = new MySqlCommand(SQL, conn);
                    command.Parameters.AddWithValue("?THB", prices);
                    command.Parameters.AddWithValue("?id", student_id);
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

        public double Cal_student(int people,Boolean EP,String Class,double hour)
        {
            int type=0;
            int c=0;
            double price = 0;
            if(EP)
            {
                type = 1;
            }
           
            if (Class == "ประถม")
            {
                c = 0;
            }
            else if(Class =="ม.ต้น")
            {
                c = 1;
            }
            else if(Class == "ม.ปลาย")
            {
                c = 2;
            }

            if(people >8)
            {
                people = 8;
            }

            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select price from rate_students where people = ?people and type = ?type and class = ?class";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?people", people);
                command.Parameters.AddWithValue("?type", type);
                command.Parameters.AddWithValue("?class", c);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    price = rdr.GetInt32(0);
                }
                price = price * hour;
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

            return price;
        }

        public double Cal_teacher(int people, Boolean EP, String Class, double hour,int moneytype)
        {
            int type = 0;
            int c = 0;
            double price = 0;
            if (EP)
            {
                type = 1;
            }

            if (Class == "ประถม")
            {
                c = 0;
            }
            else if (Class == "ม.ต้น")
            {
                c = 1;
            }
            else if (Class == "ม.ปลาย")
            {
                c = 2;
            }

            if (people > 8)
            {
                people = 9;
            }

            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select price from rate_teachers where people = ?people and type = ?type and class = ?class and moneytype = ?moneytype";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?people", people);
                command.Parameters.AddWithValue("?type", type);
                command.Parameters.AddWithValue("?class", c);
                command.Parameters.AddWithValue("?moneytype", moneytype);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    price = rdr.GetInt32(0);
                }
                price = price * hour;
                
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

            return price;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            for(int i =0;i<Code.Count;i++)
            {
                if (comboBox1.Text == Code[i].ToString())
                {
                    label1.Text = Firstname[i];
                }                
            }
            
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox2.Text == Code[i].ToString())
                {
                    label2.Text = Firstname[i];
                }
            }
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox3.Text == Code[i].ToString())
                {
                    label3.Text = Firstname[i];
                }
            }
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox4.Text == Code[i].ToString())
                {
                    label4.Text = Firstname[i];
                }
            }
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox5.Text == Code[i].ToString())
                {
                    label5.Text = Firstname[i];
                }
            }
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox6.Text == Code[i].ToString())
                {
                    label6.Text = Firstname[i];
                }
            }
        }

        private void comboBox7_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox7.Text == Code[i].ToString())
                {
                    label7.Text = Firstname[i];
                }
            }
        }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox8.Text == Code[i].ToString())
                {
                    label8.Text = Firstname[i];
                }
            }
        }

        private void comboBox9_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox9.Text == Code[i].ToString())
                {
                    label9.Text = Firstname[i];
                }
            }
        }

        private void comboBox10_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox10.Text == Code[i].ToString())
                {
                    label10.Text = Firstname[i];
                }
            }
        }

        private void comboBox11_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox11.Text == Code[i].ToString())
                {
                    label11.Text = Firstname[i];
                }
            }
        }

        private void comboBox12_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox12.Text == Code[i].ToString())
                {
                    label12.Text = Firstname[i];
                }
            }
        }

        private void comboBox13_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox13.Text == Code[i].ToString())
                {
                    label13.Text = Firstname[i];
                }
            }
        }

        private void comboBox14_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox14.Text == Code[i].ToString())
                {
                    label14.Text = Firstname[i];
                }
            }
        }

        private void comboBox15_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (comboBox15.Text == Code[i].ToString())
                {
                    label15.Text = Firstname[i];
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value.DayOfWeek != DateTime.Now.DayOfWeek)
            {
                MessageBox.Show("Wrong day");
                dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.DayOfWeek != DateTime.Now.DayOfWeek)
            {
                MessageBox.Show("Wrong day");
                dateTimePicker2.Value = DateTime.Now;
            }
            else
            {

            }
        }
    }
}
