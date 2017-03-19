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
using System.Reflection;
using System.IO;

using NetOffice.ExcelApi;
using ExcelApi;
using System.Globalization;
using NetOffice.ExcelApi.Enums;

namespace Immath
{
    public partial class Mainmenu : Form
    {
        public Login _login = new Login();
        public string connection = File.ReadAllText(Directory.GetCurrentDirectory() + "/condb.txt");
        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;
        public MySqlDataReader _login_info;
        public Register_students _register_students;
        public Register_teachers _register_teachers;
        public Edit_user _edit_user;
        public Bill _bill;
        public refill _refill;
        public CancelBill _cancelbill;
        CultureInfo ThaiCulture = new CultureInfo("th-TH");
        CultureInfo UsaCulture = new CultureInfo("en-US");
        public Mainmenu(MySqlDataReader login_info,Login login)
        {
            InitializeComponent();
            _login_info = login_info;
            _login = login;
            label1.Text = label1.Text + " " + _login_info["Name"];
            label4.Text = label4.Text + " " + _login_info["money"];
            if (_login_info["Auth"].ToString() == "admin")
            {
                button_register_teacher.Enabled = true;
                button_refill.Enabled = true;
                button_reportallusers.Enabled = true;
                button_upclass.Enabled = true;
                button_calpermonth.Enabled = true;
                button_reportstudent.Enabled = true;
                button_report_student_by_id.Enabled = true;
                button_cancelbill.Enabled = true;
            }
            else
            {
                button_register_teacher.Enabled = false;
                button_refill.Enabled = false;
                button_reportallusers.Enabled = false;
                button_upclass.Enabled = false;
                button_calpermonth.Enabled = false;
                button_reportstudent.Enabled = false;
                button_report_student_by_id.Enabled = false;
                button_cancelbill.Enabled = false;
            }
            _register_students = new Register_students(this);
            _register_teachers = new Register_teachers(this);
            _edit_user = new Edit_user(this);
           
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
            _bill = new Bill(this);
            _bill.ShowDialog();

           
        }

        private void button_refill_Click(object sender, EventArgs e)
        {
            _refill = new refill();
            _refill.ShowDialog();
        }

        private void button_reportstudent_Click(object sender, EventArgs e)
        {
            NetOffice.ExcelApi.Application excel = new NetOffice.ExcelApi.Application();

            string file = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\students.xlsx";
            bool exists = File.Exists(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");
            if (!exists)
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");

            String file_save_path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports\\" + "students.xlsx";
            if (File.Exists(file_save_path))
                System.IO.File.Delete(file_save_path);
            System.IO.File.Copy(file, file_save_path, true);
            Workbook wb = excel.Workbooks.Open(file_save_path);
            Worksheet ws = (Worksheet)wb.Sheets[1];
            try
            {
                
                conn = new MySqlConnection(connection);
                conn.Open();

                string SQL = "select * from students ORDER BY Code ASC";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();
                int i = 1;
                while (rdr.Read())
                {            
                    ws.Range("A" + (2 + i)).Value = rdr["Code"];
                    ws.Range("B" + (2 + i)).Value = rdr["Firstname"];
                    ws.Range("C" + (2 + i)).Value = rdr["Lastname"];
                    ws.Range("D" + (2 + i)).Value = rdr["Nickname"];
                    ws.Range("E" + (2 + i)).Value = rdr["School_level"];
                    ws.Range("F" + (2 + i)).Value = rdr["School"];
                    ws.Range("G" + (2 + i)).Value = rdr["Tel"];
                    ws.Range("H" + (2 + i)).Value = rdr["FatherTel"]+","+rdr["MotherTel"]+","+ rdr["LiveTel"];
                    ws.Range("I" + (2 + i)).Value = rdr["THB"];
                    i = i + 1;
                }
                ws.Columns.AutoFit();
                ws.Rows.AutoFit();
                wb.Save();
                

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
                excel.Quit();

                System.Diagnostics.Process.Start(file_save_path);
            }
            excel.Quit();
          
        }

        private void button_reportteacher_Click(object sender, EventArgs e)
        {
            List<int> Code = new List<int>();
            List<int> id = new List<int>();
            List<string> nickname = new List<string>();
            NetOffice.ExcelApi.Application excel = new NetOffice.ExcelApi.Application();

            string file = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\users.xlsx";
            bool exists = File.Exists(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");
            if (!exists)
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");

            String file_save_path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports\\" + "users.xlsx";
            if (File.Exists(file_save_path))
                System.IO.File.Delete(file_save_path);
            System.IO.File.Copy(file, file_save_path, true);

            double sum = 0;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select id,Code,Nickname from students ORDER BY Code ASC";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Code.Add(rdr.GetInt32(1));
                    id.Add(rdr.GetInt32(0));
                    nickname.Add(rdr.GetString(2));
                }
                conn.Close();
                
                conn.Open();
                Workbook wb = excel.Workbooks.Open(file_save_path);
                Worksheet ws = (Worksheet)wb.Sheets[1];
                SQL = "select * from bills where (Users_id =?users_id) and (Delete_date is null) and (Starttime between ?startt and ?stopt) ORDER BY Datetime ASC";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?users_id", _login_info["id"]);
                command.Parameters.AddWithValue("?startt", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
                command.Parameters.AddWithValue("?stopt", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
               
                rdr = command.ExecuteReader();
                int i = 1;

                string last_bon = "";
                string last_bin = "";
                bool x = true;
                while (rdr.Read())
                {
                 
                    ws.Range("A" + (2 + i)).Value = _login_info["Nickname"];
                    for (int j = 0; j < id.Count; j++)
                    {
                        if (rdr["Students_id"].ToString() == id[j].ToString())
                        {
                            ws.Range("B" + (2 + i)).Value = Code[j];
                            ws.Range("C" + (2 + i)).Value = nickname[j];
                        }
                    }
                    ws.Range("D" + (2 + i)).Value = rdr["Datetime"];
                    ws.Range("E" + (2 + i)).Value = rdr["Subject"];
                    string temp = rdr["Starttime"].ToString();
                    DateTime temp_time = Convert.ToDateTime(temp);
                    temp_time=temp_time.AddHours(Convert.ToInt32(rdr["Hour"]));
                    ws.Range("F" + (2 + i)).Value = rdr["Starttime"] + "-" + temp_time;
                    ws.Range("G" + (2 + i)).Value = rdr["Hour"];
                    ws.Range("H" + (2 + i)).Value = rdr["Price_Users"];
                    ws.Range("I" + (2 + i)).Value = rdr["Book_no"];
                    ws.Range("J" + (2 + i)).Value = rdr["Bill_no"];

                    if(last_bon == rdr["Book_no"].ToString())
                    {
                        if (last_bin == rdr["Bill_no"].ToString())
                        {
                            if(x)
                            {
                                ws.Range("A" + (1 + i), "J" + (1 + i)).Interior.Color = XlRgbColor.rgbSkyBlue;
                                ws.Range("A" + (2 + i), "J" + (2 + i)).Interior.Color = XlRgbColor.rgbSkyBlue;
                            }
                        }
                        else
                        {
                            x = !x;
                            sum= sum+double.Parse(rdr["Price_Users"].ToString());
                        }
                    }
                    else
                    {
                        x = !x;
                        sum = sum + double.Parse(rdr["Price_Users"].ToString());
                    }
                    last_bon = rdr["Book_no"].ToString();
                    last_bin = rdr["Bill_no"].ToString();

                    i = i + 1;
                }
                conn.Close();
                ws.Range("M" + (1)).Value = sum;
                ws.Range("M" + (2)).Value = double.Parse(ws.Range("M" + (1)).Value.ToString()) * 0.1;
                ws.Range("M" + (3)).Value = double.Parse(ws.Range("M" + (2)).Value.ToString()) * 0.03;
                ws.Range("M" + (4)).Value = double.Parse(ws.Range("M" + (2)).Value.ToString()) + double.Parse(ws.Range("M" + (3)).Value.ToString());
                ws.Range("M" + (5)).Value = double.Parse(ws.Range("M" + (1)).Value.ToString()) - double.Parse(ws.Range("M" + (4)).Value.ToString());
                ws.Columns.AutoFit();
                ws.Rows.AutoFit();
                wb.Save();
                excel.Quit();
                System.Diagnostics.Process.Start(file_save_path);
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
                excel.Quit();
            }
            excel.Quit();
        }

        private void button_cancelbill_Click(object sender, EventArgs e)
        {
            _cancelbill = new CancelBill();
            _cancelbill.ShowDialog();
        }

        private void button_reportallusers_Click(object sender, EventArgs e)
        {
            List<int> Code = new List<int>();
            List<int> id = new List<int>();
            List<string> nickname = new List<string>();
            NetOffice.ExcelApi.Application excel = new NetOffice.ExcelApi.Application();

            string file = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\users.xlsx";
            bool exists = File.Exists(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");
            if (!exists)
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");

            String file_save_path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports\\" + "users.xlsx";
            if (File.Exists(file_save_path))
                System.IO.File.Delete(file_save_path);
            System.IO.File.Copy(file, file_save_path, true);
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select id,Code,Nickname from students ORDER BY Code ASC";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Code.Add(rdr.GetInt32(1));
                    id.Add(rdr.GetInt32(0));
                    nickname.Add(rdr.GetString(2));
                }
                conn.Close();

                conn.Open();
                Workbook wb = excel.Workbooks.Open(file_save_path);
                Worksheet ws = (Worksheet)wb.Sheets[1];
                SQL = "select * from bills where (Delete_date is null) and (Starttime between ?startt and ?stopt) ORDER BY Datetime ASC";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?users_id", _login_info["id"]);
                command.Parameters.AddWithValue("?startt", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
                command.Parameters.AddWithValue("?stopt", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));

                rdr = command.ExecuteReader();
                int i = 1;

                string last_bon = "";
                string last_bin = "";
                bool x = true;
                while (rdr.Read())
                {

                    ws.Range("A" + (2 + i)).Value = _login_info["Nickname"];
                    for (int j = 0; j < id.Count; j++)
                    {
                        if (rdr["Students_id"].ToString() == id[j].ToString())
                        {
                            ws.Range("B" + (2 + i)).Value = Code[j];
                            ws.Range("C" + (2 + i)).Value = nickname[j];
                        }
                    }
                    ws.Range("D" + (2 + i)).Value = rdr["Datetime"];
                    ws.Range("E" + (2 + i)).Value = rdr["Subject"];
                    string temp = rdr["Starttime"].ToString();
                    DateTime temp_time = Convert.ToDateTime(temp);
                    temp_time = temp_time.AddHours(Convert.ToInt32(rdr["Hour"]));
                    ws.Range("F" + (2 + i)).Value = rdr["Starttime"] + "-" + temp_time;
                    ws.Range("G" + (2 + i)).Value = rdr["Hour"];
                    ws.Range("H" + (2 + i)).Value = rdr["Price_Users"];
                    ws.Range("I" + (2 + i)).Value = rdr["Book_no"];
                    ws.Range("J" + (2 + i)).Value = rdr["Bill_no"];

                    if (last_bon == rdr["Book_no"].ToString())
                    {
                        if (last_bin == rdr["Bill_no"].ToString())
                        {
                            if (x)
                            {
                                ws.Range("A" + (1 + i), "J" + (1 + i)).Interior.Color = XlRgbColor.rgbSkyBlue;
                                ws.Range("A" + (2 + i), "J" + (2 + i)).Interior.Color = XlRgbColor.rgbSkyBlue;
                            }
                        }
                        else
                        {
                            x = !x;
                        }
                    }
                    else
                    {
                        x = !x;
                    }
                    last_bon = rdr["Book_no"].ToString();
                    last_bin = rdr["Bill_no"].ToString();

                    i = i + 1;
                }

                ws.Columns.AutoFit();
                ws.Rows.AutoFit();
                wb.Save();
                excel.Quit();
                System.Diagnostics.Process.Start(file_save_path);
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
                excel.Quit();
            }
            excel.Quit();
        }

        private void button_upclass_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "UPDATE students SET School_level=?new where School_level=?old";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "มหาลัย");
                command.Parameters.AddWithValue("?old", "ม.6");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ม.6");
                command.Parameters.AddWithValue("?old", "ม.5");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ม.5");
                command.Parameters.AddWithValue("?old", "ม.4");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ม.4");
                command.Parameters.AddWithValue("?old", "ม.3");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ม.3");
                command.Parameters.AddWithValue("?old", "ม.2");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ม.2");
                command.Parameters.AddWithValue("?old", "ม.1");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ม.1");
                command.Parameters.AddWithValue("?old", "ป.6");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ป.6");
                command.Parameters.AddWithValue("?old", "ป.5");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ป.5");
                command.Parameters.AddWithValue("?old", "ป.4");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ป.4");
                command.Parameters.AddWithValue("?old", "ป.3");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ป.3");
                command.Parameters.AddWithValue("?old", "ป.2");
                command.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SQL = "UPDATE students SET School_level=?new where School_level=?old";
                command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?new", "ป.2");
                command.Parameters.AddWithValue("?old", "ป.1");
                command.ExecuteNonQuery();
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

        private void button_report_student_by_id_Click(object sender, EventArgs e)
        {
            List<int> Code = new List<int>();
            List<int> id = new List<int>();
            List<string> nickname = new List<string>();
            List<DateTime> date = new List<DateTime>();
            List<double> money = new List<double>();
            List<string> teacher_name = new List<string>();
            List<int> teacher_id = new List<int>();
            NetOffice.ExcelApi.Application excel = new NetOffice.ExcelApi.Application();

            string file = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\studentr.xlsx";
            bool exists = File.Exists(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");
            if (!exists)
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports");

            String file_save_path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\reports\\" + "studentr.xlsx";
            if (File.Exists(file_save_path))
                System.IO.File.Delete(file_save_path);
            System.IO.File.Copy(file, file_save_path, true);
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select id,Code,Nickname from students where Code =?Code";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                command.Parameters.AddWithValue("?Code", textBox_code.Text);
                rdr = command.ExecuteReader();

                if (rdr.Read())
                {
                    Code.Add(rdr.GetInt32(1));
                    id.Add(rdr.GetInt32(0));
                    nickname.Add(rdr.GetString(2));
                }
                else
                {
                    MessageBox.Show("dont have");
                }
                conn.Close();

                if (Code.Count != 0)
                {
                    conn.Open();
                    SQL = "select * from refill where students_id =?students_id";
                    command = new MySqlCommand(SQL, conn);
                    command.Parameters.AddWithValue("?students_id", id[0]);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        date.Add(DateTime.Parse(rdr["Date"].ToString()));
                        money.Add(double.Parse(rdr["Money"].ToString()));
                    }
                    conn.Close();
                    conn.Open();
                    SQL = "select * from users";
                    command = new MySqlCommand(SQL, conn);
                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        teacher_id.Add(Int32.Parse(rdr["id"].ToString()));
                        teacher_name.Add(rdr["Nickname"].ToString());
                    }
                    conn.Close();
                    conn.Open();
                    SQL = "select * from bills where (Delete_date is null) and (Students_id = ?student_id) ORDER BY Datetime ASC";
                    command = new MySqlCommand(SQL, conn);
                    command.Parameters.AddWithValue("?student_id", id[0]);
                    rdr = command.ExecuteReader();

                    Workbook wb = excel.Workbooks.Open(file_save_path);
                    Worksheet ws = (Worksheet)wb.Sheets[1];
                    int i = 1;
                    ws.Range("B" + (2)).Value = nickname[0];
                    ws.Range("D" + (2)).Value = Code[0];
                    while (rdr.Read())
                    {
                        for (int j = 0; j < teacher_id.Count; j++)
                        {
                            if (rdr["Users_id"].ToString() == teacher_id[j].ToString())
                            {
                                ws.Range("A" + (i + 3)).Value = teacher_name[j];
                            }

                        }

                        ws.Range("B" + (i + 3)).Value = rdr["Datetime"];
                        ws.Range("C" + (i + 3)).Value = rdr["Subject"];
                        ws.Range("D" + (i + 3)).Value = rdr["Hour"];
                        ws.Range("E" + (i + 3)).Value = rdr["people"];
                        ws.Range("F" + (i + 3)).Value = rdr["Price_Students"];
                        i = i + 1;
                    }
                    conn.Close();
                    for (i = 0; i < money.Count; i++)
                    {
                        ws.Range("H" + (i + 4)).Value = date[i];
                        ws.Range("I" + (i + 4)).Value = money[i];
                    }



                    ws.Columns.AutoFit();
                    ws.Rows.AutoFit();
                    wb.Save();
                    excel.Quit();
                    System.Diagnostics.Process.Start(file_save_path);
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
                excel.Quit();
            }
            excel.Quit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                   dateTimePicker1.Value.Day, 0, 0, 0);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month,
                   dateTimePicker2.Value.Day, 23, 59, 59);
        }

        private void button_calpermonth_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connection);
                MySqlConnection conn2 = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select DISTINCT Bill_no,Book_no,Users_id,Price_Users from bills where up is null and Book_no = 1 and Delete_date is null";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();
                DateTime now = DateTime.Now;
                while (rdr.Read())
                {

                    conn2.Open();
                    SQL = "update users set money=money+?money where id = ?id";
                    command = new MySqlCommand(SQL, conn2);
                    command.Parameters.AddWithValue("?money", Double.Parse(rdr["Price_Users"].ToString()) * 0.1 * 1.03);
                    command.Parameters.AddWithValue("?id", Int32.Parse(rdr["Users_id"].ToString()));
                    command.ExecuteNonQuery();
                    conn2.Close();
                    conn2.Open();
                    SQL = "update bills set up=?up where Bill_no = ?Bill_no and Book_no = ?Book_no";
                    command = new MySqlCommand(SQL, conn2);
                    command.Parameters.AddWithValue("?up", now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
                    command.Parameters.AddWithValue("?Bill_no", rdr["Bill_no"].ToString());
                    command.Parameters.AddWithValue("?Book_no", rdr["Book_no"].ToString());
                    command.ExecuteNonQuery();
                    conn2.Close();

                }
                conn.Close();
                conn.Open();
                SQL = "select DISTINCT Bill_no,Book_no,Users_id,Price_Users from bills where up is null and Book_no = 2 and Delete_date is null";
                command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {

                    conn2.Open();
                    SQL = "update users set money=money+?money where id = ?id";
                    command = new MySqlCommand(SQL, conn2);
                    command.Parameters.AddWithValue("?money", Double.Parse(rdr["Price_Users"].ToString()) * 0.1 * 1.03);
                    command.Parameters.AddWithValue("?id", Int32.Parse(rdr["Users_id"].ToString()));
                    command.ExecuteNonQuery();
                    conn2.Close();
                    conn2.Open();
                    SQL = "update bills set up=?up where Bill_no = ?Bill_no and Book_no = ?Book_no";
                    command = new MySqlCommand(SQL, conn2);
                    command.Parameters.AddWithValue("?up", now.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
                    command.Parameters.AddWithValue("?Bill_no", rdr["Bill_no"].ToString());
                    command.Parameters.AddWithValue("?Book_no", rdr["Book_no"].ToString());
                    command.ExecuteNonQuery();
                    conn2.Close();

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
    }
}
