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
            this.SuspendLayout();
            // 
            // button_register_student
            // 
            this.button_register_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button_register_student.Location = new System.Drawing.Point(34, 61);
            this.button_register_student.Name = "button_register_student";
            this.button_register_student.Size = new System.Drawing.Size(189, 62);
            this.button_register_student.TabIndex = 0;
            this.button_register_student.Text = "ลงทะเบียนนักเรียน";
            this.button_register_student.UseVisualStyleBackColor = true;
            this.button_register_student.Click += new System.EventHandler(this.button_register_student_Click);
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(518, 12);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(113, 43);
            this.button_logout.TabIndex = 1;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // button_register_teacher
            // 
            this.button_register_teacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button_register_teacher.Location = new System.Drawing.Point(394, 61);
            this.button_register_teacher.Name = "button_register_teacher";
            this.button_register_teacher.Size = new System.Drawing.Size(237, 51);
            this.button_register_teacher.TabIndex = 2;
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
            this.label1.TabIndex = 3;
            this.label1.Text = "Login as : อาจารย์";
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(394, 12);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(105, 43);
            this.button_edit.TabIndex = 4;
            this.button_edit.Text = "Edit User info";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // Mainmenu
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(643, 314);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_register_teacher);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.button_register_student);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}