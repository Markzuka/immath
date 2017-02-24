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
using AForge.Video;
using AForge.Video.DirectShow;
using System.Globalization;

namespace Immath
{
    public partial class Register_students : Form
    {
        private Mainmenu _mainmenu;
        private MySqlDataReader _login_info;
        FilterInfoCollection dvlist;
        VideoCaptureDevice cam;
        CultureInfo ThaiCulture = new CultureInfo("th-TH");
        CultureInfo UsaCulture = new CultureInfo("en-US");
        public Register_students(Mainmenu mainmenu)
        {
            InitializeComponent();
            _login_info = mainmenu._login_info;
            _mainmenu = mainmenu;
        }
        public void clear_content()
        {
            textBox_Firstname.Text = "";
            textBox_Lastname.Text = "";
            //comboBox_Titlename.SelectedIndex = 0;
            textBox_Nickname.Text = "";
            //comboBox_Sex.SelectedIndex = 0;
            dateTimePicker_DateOfBirth.Value = DateTime.Now;
            textBox_DreamJob.Text = "";
            textBox_Tel.Text = "";
            textBox_Email.Text = "";
            textBox_Facebook.Text = "";
            textBox_School.Text = "";
            //comboBox_School_level.SelectedIndex = 0;
            textBox_LastAvgGrade.Text = "0.00";
            textBox_MathG.Text = "0.00";
            textBox_SciG.Text = "0.00";
            textBox_EngG.Text = "0.00";
            textBox_PhyG.Text = "0.00";
            textBox_CheG.Text = "0.00";
            textBox_BioG.Text = "0.00";
            textBox_Kindergarten.Text = "";
            textBox_PrimarySchool.Text = "";
            textBox_JuniorHighSchool.Text = "";
            textBox_SeniorSchool.Text = "";
            textBox_FatherName.Text = "";
            textBox_FatherJob.Text = "";
            textBox_FatherTel.Text = "";
            textBox_MotherName.Text = "";
            textBox_MotherJob.Text = "";
            textBox_MotherTel.Text = "";
            textBox_LiveName.Text = "";
            textBox_LiveRelation.Text = "";
            textBox_LiveTel.Text = "";
            textBox_Address.Text = "";
            textBox_Note.Text = "";
            textBox_Line_id.Text = "";
            textBox_Line_id_parent.Text = "";
            textbox_Code.Text = "";
            label_THB.Text = "0 THB";
            //Pic

        }
        private void Register_students_Load(object sender, EventArgs e)
        {
            object[] titlename = new object[] { "ด.ช.", "ด.ญ.", "นาย" ,"นาง","นางสาว","ม.ร.ว.","ม.ล."};
            comboBox_Titlename.Items.AddRange(titlename);
            comboBox_Titlename.SelectedIndex=0;
            object[] sex = new object[] { "ชาย", "หญิง" };
            comboBox_Sex.Items.AddRange(sex);
            comboBox_Sex.SelectedIndex = 0;
            object[] school_level = new object[] { "ป.1" ,"ป.2" ,"ป.3" ,"ป.4" ,"ป.5","ป.6","ม.1","ม.2", "ม.3", "ม.4", "ม.5", "ม.6" ,"มหาลัย"};
            comboBox_School_level.Items.AddRange(school_level);
            comboBox_School_level.SelectedIndex = 0;
            dvlist = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo info in dvlist)
            {
                camlist.Items.Add(info.Name);
            }
            camlist.SelectedIndex=0;
            cam = new VideoCaptureDevice(dvlist[camlist.SelectedIndex].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
         }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap b = (Bitmap)eventArgs.Frame.Clone();
            Pic.Image = b;
            //throw new NotImplementedException();
        }

        private void Register_students_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.cam.Stop();
            _mainmenu.Show();

        }

        private void button_takephoto_Click(object sender, EventArgs e)
        {
            if(cam.IsRunning)
            {
                cam.Stop();
                RealPic.Image = Pic.Image;
                cam.Start();
            }
           
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1; database=immath;user=immath; password=math2017; CharSet=tis620;";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select * from students where code='" + textbox_Code.Text+"'";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    conn.Close();
                    conn.Open();
                    SQL = "UPDATE students SET Firstname=?FirstName,Lastname=?Lastname,Titlename=?Titlename,Nickname=?Nickname,Sex=?Sex,DateOfBirth=?DateOfBirth,DreamJob=?DreamJob,Tel=?Tel,Email=?Email,Facebook=?Facebook,School=?School,School_level=?School_level,LastAvgGrade=?LastAvgGrade,MathG=?MathG,SciG=?SciG,EngG=?EngG,PhyG=?PhyG,CheG=?CheG,BioG=?BioG,Kindergarten=?Kindergarten,PrimarySchool=?PrimarySchool,JuniorHighSchool=?JuniorHighSchool,SeniorHighSchool=?SeniorHighSchool,FatherName=?FatherName,FatherJob=?FatherJob,FatherTel=?FatherTel,MotherName=?MotherName,MotherJob=?MotherJob,MotherTel=?MotherTel,Address=?Address,LiveName=?LiveName,LiveRelation=?LiveRelation,LiveTel=?LiveTel,Note=?Note,Line_id=?Line_id,Line_id_parent=?Line_id_parent  where Code =?Code";
                    command = new MySqlCommand(SQL, conn);
                    command.Parameters.Add("?Firstname", textBox_Firstname.Text);
                    command.Parameters.Add("?Lastname", textBox_Lastname.Text);
                    command.Parameters.Add("?Titlename", comboBox_Titlename.Text);
                    command.Parameters.Add("?Nickname", textBox_Nickname.Text);
                    command.Parameters.Add("?Sex", comboBox_Sex.Text);                   
                    command.Parameters.Add("?DateOfBirth", dateTimePicker_DateOfBirth.Value.Date.ToString("yyyy-MM-dd HH:mm", UsaCulture));
                    command.Parameters.Add("?DreamJob", textBox_DreamJob.Text);
                    command.Parameters.Add("?Tel", textBox_Tel.Text);
                    command.Parameters.Add("?Email", textBox_Email.Text);
                    command.Parameters.Add("?Facebook", textBox_Facebook.Text);
                    command.Parameters.Add("?School", textBox_School.Text);
                    command.Parameters.Add("?School_level", comboBox_School_level.Text);
                    command.Parameters.Add("?LastAvgGrade", textBox_LastAvgGrade.Text);
                    command.Parameters.Add("?MathG", textBox_MathG.Text);
                    command.Parameters.Add("?SciG", textBox_SciG.Text);
                    command.Parameters.Add("?EngG", textBox_EngG.Text);
                    command.Parameters.Add("?PhyG", textBox_PhyG.Text);
                    command.Parameters.Add("?CheG", textBox_CheG.Text);
                    command.Parameters.Add("?BioG", textBox_BioG.Text);
                    command.Parameters.Add("?Kindergarten", textBox_Kindergarten.Text);
                    command.Parameters.Add("?PrimarySchool", textBox_PrimarySchool.Text);
                    command.Parameters.Add("?JuniorHighSchool", textBox_JuniorHighSchool.Text);
                    command.Parameters.Add("?SeniorHighSchool", textBox_SeniorSchool.Text);
                    command.Parameters.Add("?FatherName", textBox_FatherName.Text);
                    command.Parameters.Add("?FatherJob", textBox_FatherJob.Text);
                    command.Parameters.Add("?FatherTel", textBox_FatherTel.Text);
                    command.Parameters.Add("?MotherName", textBox_MotherName.Text);
                    command.Parameters.Add("?MotherJob", textBox_MotherJob.Text);
                    command.Parameters.Add("?MotherTel", textBox_MotherTel.Text);
                    command.Parameters.Add("?Address", textBox_Address.Text);
                    command.Parameters.Add("?LiveName", textBox_LiveName.Text);
                    command.Parameters.Add("?LiveRelation", textBox_LiveRelation.Text);
                    command.Parameters.Add("?LiveTel", textBox_LiveTel.Text);
                    command.Parameters.Add("?Note", textBox_Note.Text);
                    command.Parameters.Add("?Line_id", textBox_Line_id.Text);
                    command.Parameters.Add("?Line_id_parent", textBox_Line_id_parent.Text);
                    command.Parameters.Add("?Code", textbox_Code.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("update complete!");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    SQL = "insert into students(Firstname,Lastname,Titlename,Nickname,Sex,Code,THB,DateOfBirth,DreamJob,Tel,Email,Facebook,School,School_level,LastAvgGrade,MathG,SciG,EngG,PhyG,CheG,BioG,Kindergarten,PrimarySchool,JuniorHighSchool,SeniorHighSchool,FatherName,FatherJob,FatherTel,MotherName,MotherJob,MotherTel,Address,LiveName,LiveRelation,LiveTel,Pic,Note,Line_id,Line_id_parent) Values(?Firstname,?Lastname,?Titlename,?Nickname,?Sex,?Code,0,?DateOfBirth,?DreamJob,?Tel,?Email,?Facebook,?School,?School_level,?LastAvgGrade,?MathG,?SciG,?EngG,?PhyG,?CheG,?BioG,?Kindergarten,?PrimarySchool,?JuniorHighSchool,?SeniorHighSchool,?FatherName,?FatherJob,?FatherTel,?MotherName,?MotherJob,?MotherTel,?Address,?LiveName,?LiveRelation,?LiveTel,null,?Note,?Line_id,?Line_id_parent)";
                    command = new MySqlCommand(SQL, conn);
                    command.Parameters.Add("?Firstname", textBox_Firstname.Text);
                    command.Parameters.Add("?Lastname", textBox_Lastname.Text);
                    command.Parameters.Add("?Titlename", comboBox_Titlename.Text);
                    command.Parameters.Add("?Nickname", textBox_Nickname.Text);
                    command.Parameters.Add("?Sex", comboBox_Sex.Text);
                    command.Parameters.Add("?Code", textbox_Code.Text);
                    command.Parameters.Add("?DateOfBirth", dateTimePicker_DateOfBirth.Value.Date.ToString("yyyy-MM-dd HH:mm", UsaCulture));
                    command.Parameters.Add("?DreamJob", textBox_DreamJob.Text);
                    command.Parameters.Add("?Tel", textBox_Tel.Text);
                    command.Parameters.Add("?Email", textBox_Email.Text);
                    command.Parameters.Add("?Facebook", textBox_Facebook.Text);
                    command.Parameters.Add("?School", textBox_School.Text);
                    command.Parameters.Add("?School_level", comboBox_School_level.Text);
                    command.Parameters.Add("?LastAvgGrade", textBox_LastAvgGrade.Text);
                    command.Parameters.Add("?MathG", textBox_MathG.Text);
                    command.Parameters.Add("?SciG", textBox_SciG.Text);
                    command.Parameters.Add("?EngG", textBox_EngG.Text);
                    command.Parameters.Add("?PhyG", textBox_PhyG.Text);
                    command.Parameters.Add("?CheG", textBox_CheG.Text);
                    command.Parameters.Add("?BioG", textBox_BioG.Text);
                    command.Parameters.Add("?Kindergarten", textBox_Kindergarten.Text);
                    command.Parameters.Add("?PrimarySchool", textBox_PrimarySchool.Text);
                    command.Parameters.Add("?JuniorHighSchool", textBox_JuniorHighSchool.Text);
                    command.Parameters.Add("?SeniorHighSchool", textBox_SeniorSchool.Text);
                    command.Parameters.Add("?FatherName", textBox_FatherName.Text);
                    command.Parameters.Add("?FatherJob", textBox_FatherJob.Text);
                    command.Parameters.Add("?FatherTel", textBox_FatherTel.Text);
                    command.Parameters.Add("?MotherName", textBox_MotherName.Text);
                    command.Parameters.Add("?MotherJob", textBox_MotherJob.Text);
                    command.Parameters.Add("?MotherTel", textBox_MotherTel.Text);
                    command.Parameters.Add("?Address", textBox_Address.Text);
                    command.Parameters.Add("?LiveName", textBox_LiveName.Text);
                    command.Parameters.Add("?LiveRelation", textBox_LiveRelation.Text);
                    command.Parameters.Add("?LiveTel", textBox_LiveTel.Text);
                    command.Parameters.Add("?Note", textBox_Note.Text);
                    command.Parameters.Add("?Line_id", textBox_Line_id.Text);
                    command.Parameters.Add("?Line_id_parent", textBox_Line_id_parent.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("complete");
                    conn.Close();
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

        private void button_findbycode_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1; database=immath;user=immath; password=math2017; CharSet=tis620;";
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                string SQL = "select * from students where code='" + textbox_Code.Text + "'";
                MySqlCommand command = new MySqlCommand(SQL, conn);
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    clear_content();
                    textBox_Firstname.Text = rdr["Firstname"].ToString();
                    textBox_Lastname.Text = rdr["Lastname"].ToString();
                    textBox_Nickname.Text = rdr["Nickname"].ToString();
                    comboBox_Titlename.Text = rdr["Titlename"].ToString();
                    comboBox_Sex.Text = rdr["Sex"].ToString();                   
                    textBox_DreamJob.Text = rdr["DreamJob"].ToString();
                    textBox_Tel.Text = rdr["Tel"].ToString();
                    textBox_Email.Text = rdr["Email"].ToString();
                    textBox_Facebook.Text = rdr["Facebook"].ToString();
                    textBox_School.Text = rdr["School"].ToString();
                    comboBox_School_level.Text = rdr["School_level"].ToString();
                    textBox_LastAvgGrade.Text = rdr["LastAvgGrade"].ToString();
                    textBox_MathG.Text = rdr["MathG"].ToString();
                    textBox_SciG.Text = rdr["SciG"].ToString();
                    textBox_EngG.Text = rdr["EngG"].ToString();
                    textBox_PhyG.Text = rdr["PhyG"].ToString();
                    textBox_CheG.Text = rdr["CheG"].ToString();
                    textBox_BioG.Text = rdr["BioG"].ToString();
                    textBox_Kindergarten.Text = rdr["Kindergarten"].ToString();
                    textBox_PrimarySchool.Text = rdr["PrimarySchool"].ToString();
                    textBox_JuniorHighSchool.Text = rdr["JuniorHighSchool"].ToString();
                    textBox_SeniorSchool.Text = rdr["SeniorHighSchool"].ToString();
                    textBox_FatherName.Text = rdr["FatherName"].ToString();
                    textBox_FatherJob.Text = rdr["FatherJob"].ToString();
                    textBox_FatherTel.Text = rdr["FatherTel"].ToString();
                    textBox_MotherName.Text = rdr["MotherName"].ToString();
                    textBox_MotherJob.Text = rdr["MotherJob"].ToString();
                    textBox_MotherTel.Text = rdr["MotherTel"].ToString();
                    textBox_LiveName.Text = rdr["LiveName"].ToString();
                    textBox_LiveRelation.Text = rdr["LiveRelation"].ToString();
                    textBox_LiveTel.Text = rdr["LiveTel"].ToString();
                    textBox_Address.Text = rdr["Address"].ToString();
                    textBox_Note.Text = rdr["Note"].ToString();
                    textBox_Line_id.Text = rdr["Line_id"].ToString();
                    textBox_Line_id_parent.Text = rdr["Line_id_parent"].ToString();
                    textbox_Code.Text = rdr["Code"].ToString();
                    label_THB.Text = rdr["THB"].ToString()+" THB";
                    dateTimePicker_DateOfBirth.Value = (DateTime)rdr["DateOfBirth"];
                }
                else
                {
                    MessageBox.Show("Dont have id");
                    clear_content();
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

        private void button_clear_Click(object sender, EventArgs e)
        {
            clear_content();
        }
    }
}
