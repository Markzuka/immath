namespace Immath
{
    partial class Bill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill));
            this.label_countstudent = new System.Windows.Forms.Label();
            this.numericUpDown_count = new System.Windows.Forms.NumericUpDown();
            this.button_load = new System.Windows.Forms.Button();
            this.label_รหัสนักเรียน = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label_ถึง = new System.Windows.Forms.Label();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.label_ระดับชั้น = new System.Windows.Forms.Label();
            this.checkBox_EP = new System.Windows.Forms.CheckBox();
            this.button_save = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.label_book_no = new System.Windows.Forms.Label();
            this.label_bill_no = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_Subject = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).BeginInit();
            this.SuspendLayout();
            // 
            // label_countstudent
            // 
            this.label_countstudent.AutoSize = true;
            this.label_countstudent.Location = new System.Drawing.Point(186, 34);
            this.label_countstudent.Name = "label_countstudent";
            this.label_countstudent.Size = new System.Drawing.Size(81, 13);
            this.label_countstudent.TabIndex = 1;
            this.label_countstudent.Text = "จำนวนนักเรียน";
            // 
            // numericUpDown_count
            // 
            this.numericUpDown_count.Location = new System.Drawing.Point(301, 32);
            this.numericUpDown_count.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_count.Name = "numericUpDown_count";
            this.numericUpDown_count.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_count.TabIndex = 2;
            this.numericUpDown_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(390, 32);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 3;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // label_รหัสนักเรียน
            // 
            this.label_รหัสนักเรียน.AutoSize = true;
            this.label_รหัสนักเรียน.Location = new System.Drawing.Point(61, 67);
            this.label_รหัสนักเรียน.Name = "label_รหัสนักเรียน";
            this.label_รหัสนักเรียน.Size = new System.Drawing.Size(67, 13);
            this.label_รหัสนักเรียน.TabIndex = 4;
            this.label_รหัสนักเรียน.Text = "รหัสนักเรียน";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(149, 290);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(157, 20);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(362, 290);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker2.TabIndex = 22;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label_ถึง
            // 
            this.label_ถึง.AutoSize = true;
            this.label_ถึง.Location = new System.Drawing.Point(312, 294);
            this.label_ถึง.Name = "label_ถึง";
            this.label_ถึง.Size = new System.Drawing.Size(19, 13);
            this.label_ถึง.TabIndex = 21;
            this.label_ถึง.Text = "ถึง";
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Location = new System.Drawing.Point(127, 332);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(95, 21);
            this.comboBox_Class.TabIndex = 24;
            // 
            // label_ระดับชั้น
            // 
            this.label_ระดับชั้น.AutoSize = true;
            this.label_ระดับชั้น.Location = new System.Drawing.Point(57, 335);
            this.label_ระดับชั้น.Name = "label_ระดับชั้น";
            this.label_ระดับชั้น.Size = new System.Drawing.Size(47, 13);
            this.label_ระดับชั้น.TabIndex = 23;
            this.label_ระดับชั้น.Text = "ระดับชั้น";
            // 
            // checkBox_EP
            // 
            this.checkBox_EP.AutoSize = true;
            this.checkBox_EP.Location = new System.Drawing.Point(273, 334);
            this.checkBox_EP.Name = "checkBox_EP";
            this.checkBox_EP.Size = new System.Drawing.Size(102, 17);
            this.checkBox_EP.TabIndex = 25;
            this.checkBox_EP.Text = "English Program";
            this.checkBox_EP.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(277, 383);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(81, 43);
            this.button_save.TabIndex = 27;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(65, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(169, 92);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(77, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.TextChanged += new System.EventHandler(this.comboBox2_TextChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(281, 92);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(77, 21);
            this.comboBox3.TabIndex = 7;
            this.comboBox3.TextChanged += new System.EventHandler(this.comboBox3_TextChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(400, 92);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(77, 21);
            this.comboBox4.TabIndex = 8;
            this.comboBox4.TextChanged += new System.EventHandler(this.comboBox4_TextChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(519, 92);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(77, 21);
            this.comboBox5.TabIndex = 9;
            this.comboBox5.TextChanged += new System.EventHandler(this.comboBox5_TextChanged);
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(65, 146);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(77, 21);
            this.comboBox6.TabIndex = 10;
            this.comboBox6.TextChanged += new System.EventHandler(this.comboBox6_TextChanged);
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(169, 146);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(77, 21);
            this.comboBox7.TabIndex = 11;
            this.comboBox7.TextChanged += new System.EventHandler(this.comboBox7_TextChanged);
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(281, 146);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(77, 21);
            this.comboBox8.TabIndex = 12;
            this.comboBox8.TextChanged += new System.EventHandler(this.comboBox8_TextChanged);
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(400, 146);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(77, 21);
            this.comboBox9.TabIndex = 13;
            this.comboBox9.TextChanged += new System.EventHandler(this.comboBox9_TextChanged);
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(519, 146);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(77, 21);
            this.comboBox10.TabIndex = 14;
            this.comboBox10.TextChanged += new System.EventHandler(this.comboBox10_TextChanged);
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(65, 204);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(77, 21);
            this.comboBox11.TabIndex = 15;
            this.comboBox11.TextChanged += new System.EventHandler(this.comboBox11_TextChanged);
            // 
            // comboBox12
            // 
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(169, 204);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(77, 21);
            this.comboBox12.TabIndex = 16;
            this.comboBox12.TextChanged += new System.EventHandler(this.comboBox12_TextChanged);
            // 
            // comboBox13
            // 
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Location = new System.Drawing.Point(281, 204);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(77, 21);
            this.comboBox13.TabIndex = 17;
            this.comboBox13.TextChanged += new System.EventHandler(this.comboBox13_TextChanged);
            // 
            // comboBox14
            // 
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Location = new System.Drawing.Point(400, 204);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(77, 21);
            this.comboBox14.TabIndex = 18;
            this.comboBox14.TextChanged += new System.EventHandler(this.comboBox14_TextChanged);
            // 
            // comboBox15
            // 
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.Location = new System.Drawing.Point(519, 204);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(77, 21);
            this.comboBox15.TabIndex = 19;
            this.comboBox15.TextChanged += new System.EventHandler(this.comboBox15_TextChanged);
            // 
            // label_book_no
            // 
            this.label_book_no.AutoSize = true;
            this.label_book_no.Location = new System.Drawing.Point(516, 9);
            this.label_book_no.Name = "label_book_no";
            this.label_book_no.Size = new System.Drawing.Size(10, 13);
            this.label_book_no.TabIndex = 28;
            this.label_book_no.Text = "-";
            // 
            // label_bill_no
            // 
            this.label_bill_no.AutoSize = true;
            this.label_bill_no.Location = new System.Drawing.Point(516, 34);
            this.label_bill_no.Name = "label_bill_no";
            this.label_bill_no.Size = new System.Drawing.Size(10, 13);
            this.label_bill_no.TabIndex = 29;
            this.label_bill_no.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(397, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(516, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(169, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(278, 243);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(397, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "label14";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(516, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "label15";
            // 
            // textBox_Subject
            // 
            this.textBox_Subject.Location = new System.Drawing.Point(446, 333);
            this.textBox_Subject.Name = "textBox_Subject";
            this.textBox_Subject.Size = new System.Drawing.Size(111, 20);
            this.textBox_Subject.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(390, 335);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 46;
            this.label16.Text = "วิชา";
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 447);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox_Subject);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_bill_no);
            this.Controls.Add(this.label_book_no);
            this.Controls.Add(this.comboBox11);
            this.Controls.Add(this.comboBox12);
            this.Controls.Add(this.comboBox13);
            this.Controls.Add(this.comboBox14);
            this.Controls.Add(this.comboBox15);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.comboBox9);
            this.Controls.Add(this.comboBox10);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.checkBox_EP);
            this.Controls.Add(this.label_ระดับชั้น);
            this.Controls.Add(this.comboBox_Class);
            this.Controls.Add(this.label_ถึง);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label_รหัสนักเรียน);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.numericUpDown_count);
            this.Controls.Add(this.label_countstudent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bill_FormClosed);
            this.Load += new System.EventHandler(this.Bill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_countstudent;
        private System.Windows.Forms.NumericUpDown numericUpDown_count;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Label label_รหัสนักเรียน;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label_ถึง;
        private System.Windows.Forms.ComboBox comboBox_Class;
        private System.Windows.Forms.Label label_ระดับชั้น;
        private System.Windows.Forms.CheckBox checkBox_EP;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.ComboBox comboBox13;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.ComboBox comboBox15;
        private System.Windows.Forms.Label label_book_no;
        private System.Windows.Forms.Label label_bill_no;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_Subject;
        private System.Windows.Forms.Label label16;
    }
}