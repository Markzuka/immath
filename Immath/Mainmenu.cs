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

namespace Immath
{
    public partial class Mainmenu : Form
    {
        public Login _login = new Login();
        public string connection = "server=127.0.0.1; database=immath;user=immath; password=math2017; CharSet=tis620;";
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
            if (_login_info["Auth"].ToString() == "admin")
            {
                button_register_teacher.Enabled = true;
                button_refill.Enabled = true;
                button_reportallusers.Enabled = true;
                button_upclass.Enabled = true;
                button_calpermonth.Enabled = true;
            }
            else
            {
                button_register_teacher.Enabled = false;
                button_refill.Enabled = false;
                button_reportallusers.Enabled = false;
                button_upclass.Enabled = false;
                button_calpermonth.Enabled = false;
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
                command.Parameters.AddWithValue("?startt", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));
                command.Parameters.AddWithValue("?stopt", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss", UsaCulture));

                rdr = command.ExecuteReader();
                int i = 1;

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
    }
}
