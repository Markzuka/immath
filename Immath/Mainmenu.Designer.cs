namespace Immath
{
    partial class Mainmenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainmenu));
            this.button_register_student = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_register_teacher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_bill = new System.Windows.Forms.Button();
            this.button_refill = new System.Windows.Forms.Button();
            this.button_reportstudent = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button_reportteacher = new System.Windows.Forms.Button();
            this.button_cancelbill = new System.Windows.Forms.Button();
            this.button_reportallusers = new System.Windows.Forms.Button();
            this.button_upclass = new System.Windows.Forms.Button();
            this.button_calpermonth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_register_student
            // 
            this.button_register_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button_register_student.Location = new System.Drawing.Point(45, 72);
            this.button_register_student.Name = "button_register_student";
            this.button_register_student.Size = new System.Drawing.Size(189, 62);
            this.button_register_student.TabIndex = 1;
            this.button_register_student.Text = "ลงทะเบียนนักเรียน";
            this.button_register_student.UseVisualStyleBackColor = true;
            this.button_register_student.Click += new System.EventHandler(this.button_register_student_Click);
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(518, 12);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(113, 43);
            this.button_logout.TabIndex = 0;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // button_register_teacher
            // 
            this.button_register_teacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button_register_teacher.Location = new System.Drawing.Point(497, 61);
            this.button_register_teacher.Name = "button_register_teacher";
            this.button_register_teacher.Size = new System.Drawing.Size(134, 62);
            this.button_register_teacher.TabIndex = 4;
            this.button_register_teacher.Text = "ลงทะเบียนครู";
            this.button_register_teacher.UseVisualStyleBackColor = true;
            this.button_register_teacher.Click += new System.EventHandler(this.button_register_teacher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login as : อาจารย์";
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(394, 12);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(105, 43);
            this.button_edit.TabIndex = 3;
            this.button_edit.Text = "Edit User info";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_bill
            // 
            this.button_bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button_bill.Location = new System.Drawing.Point(250, 72);
            this.button_bill.Name = "button_bill";
            this.button_bill.Size = new System.Drawing.Size(189, 62);
            this.button_bill.TabIndex = 2;
            this.button_bill.Text = "ลงทะเบียนการสอน";
            this.button_bill.UseVisualStyleBackColor = true;
            this.button_bill.Click += new System.EventHandler(this.button_bill_Click);
            // 
            // button_refill
            // 
            this.button_refill.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button_refill.Location = new System.Drawing.Point(485, 129);
            this.button_refill.Name = "button_refill";
            this.button_refill.Size = new System.Drawing.Size(146, 58);
            this.button_refill.TabIndex = 6;
            this.button_refill.Text = "เติมเงินนักเรียน";
            this.button_refill.UseVisualStyleBackColor = true;
            this.button_refill.Click += new System.EventHandler(this.button_refill_Click);
            // 
            // button_reportstudent
            // 
            this.button_reportstudent.BackColor = System.Drawing.Color.Red;
            this.button_reportstudent.ForeColor = System.Drawing.Color.Gray;
            this.button_reportstudent.Location = new System.Drawing.Point(45, 252);
            this.button_reportstudent.Name = "button_reportstudent";
            this.button_reportstudent.Size = new System.Drawing.Size(103, 42);
            this.button_reportstudent.TabIndex = 7;
            this.button_reportstudent.Text = "ยอดเงินคงเหลือนักเรียน";
            this.button_reportstudent.UseVisualStyleBackColor = false;
            this.button_reportstudent.Click += new System.EventHandler(this.button_reportstudent_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(45, 217);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(142, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ถึง";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(227, 217);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(142, 20);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // button_reportteacher
            // 
            this.button_reportteacher.Location = new System.Drawing.Point(168, 252);
            this.button_reportteacher.Name = "button_reportteacher";
            this.button_reportteacher.Size = new System.Drawing.Size(103, 42);
            this.button_reportteacher.TabIndex = 11;
            this.button_reportteacher.Text = "รายงานครู";
            this.button_reportteacher.UseVisualStyleBackColor = true;
            this.button_reportteacher.Click += new System.EventHandler(this.button_reportteacher_Click);
            // 
            // button_cancelbill
            // 
            this.button_cancelbill.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button_cancelbill.Location = new System.Drawing.Point(484, 190);
            this.button_cancelbill.Name = "button_cancelbill";
            this.button_cancelbill.Size = new System.Drawing.Size(147, 62);
            this.button_cancelbill.TabIndex = 12;
            this.button_cancelbill.Text = "ยกเลิกบิล";
            this.button_cancelbill.UseVisualStyleBackColor = true;
            this.button_cancelbill.Click += new System.EventHandler(this.button_cancelbill_Click);
            // 
            // button_reportallusers
            // 
            this.button_reportallusers.Location = new System.Drawing.Point(168, 300);
            this.button_reportallusers.Name = "button_reportallusers";
            this.button_reportallusers.Size = new System.Drawing.Size(103, 41);
            this.button_reportallusers.TabIndex = 13;
            this.button_reportallusers.Text = "รายงานครูทั้งหมด";
            this.button_reportallusers.UseVisualStyleBackColor = true;
            this.button_reportallusers.Click += new System.EventHandler(this.button_reportallusers_Click);
            // 
            // button_upclass
            // 
            this.button_upclass.Location = new System.Drawing.Point(485, 260);
            this.button_upclass.Name = "button_upclass";
            this.button_upclass.Size = new System.Drawing.Size(68, 34);
            this.button_upclass.TabIndex = 14;
            this.button_upclass.Text = "upclass";
            this.button_upclass.UseVisualStyleBackColor = true;
            this.button_upclass.Click += new System.EventHandler(this.button_upclass_Click);
            // 
            // button_calpermonth
            // 
            this.button_calpermonth.Location = new System.Drawing.Point(485, 300);
            this.button_calpermonth.Name = "button_calpermonth";
            this.button_calpermonth.Size = new System.Drawing.Size(100, 33);
            this.button_calpermonth.TabIndex = 15;
            this.button_calpermonth.Text = "ตัดยอดรายเดือน";
            this.button_calpermonth.UseVisualStyleBackColor = true;
            // 
            // Mainmenu
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(643, 362);
            this.Controls.Add(this.button_calpermonth);
            this.Controls.Add(this.button_upclass);
            this.Controls.Add(this.button_reportallusers);
            this.Controls.Add(this.button_cancelbill);
            this.Controls.Add(this.button_reportteacher);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button_reportstudent);
            this.Controls.Add(this.button_refill);
            this.Controls.Add(this.button_bill);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_register_teacher);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.button_register_student);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mainmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mainmenu_Closed);
            this.Load += new System.EventHandler(this.Mainmenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_register_student;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Button button_register_teacher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_bill;
        private System.Windows.Forms.Button button_refill;
        private System.Windows.Forms.Button button_reportstudent;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button_reportteacher;
        private System.Windows.Forms.Button button_cancelbill;
        private System.Windows.Forms.Button button_reportallusers;
        private System.Windows.Forms.Button button_upclass;
        private System.Windows.Forms.Button button_calpermonth;
    }
}