namespace ExamSystem_Project.UserControls
{
    partial class Login
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label_characters = new Label();
            label_userid = new Label();
            label_registerNow = new Label();
            label2 = new Label();
            textBox_password = new TextBox();
            textBox_userId = new TextBox();
            button_loginStart = new Button();
            panel3 = new Panel();
            button_teacher = new Button();
            button1_student = new Button();
            button2_student = new Button();
            button3_student = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 135, 209);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(679, 121);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(254, 255, 255);
            label1.Location = new Point(279, 40);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 45);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label_characters);
            panel2.Controls.Add(label_userid);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(label_registerNow);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox_password);
            panel2.Controls.Add(textBox_userId);
            panel2.Controls.Add(button_loginStart);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(315, 85);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(679, 628);
            panel2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(0, 135, 209);
            label4.Location = new Point(142, 182);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(46, 30);
            label4.TabIndex = 10;
            label4.Text = "Id :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(0, 135, 209);
            label3.Location = new Point(56, 291);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(124, 30);
            label3.TabIndex = 9;
            label3.Text = "Password :";
            // 
            // label_characters
            // 
            label_characters.AutoSize = true;
            label_characters.ForeColor = SystemColors.GrayText;
            label_characters.Location = new Point(195, 342);
            label_characters.Margin = new Padding(2, 0, 2, 0);
            label_characters.Name = "label_characters";
            label_characters.Size = new Size(388, 25);
            label_characters.TabIndex = 6;
            label_characters.Text = "8+ characters, 1 uppercase, 1 lowercase, 1 digit.";
            // 
            // label_userid
            // 
            label_userid.AutoSize = true;
            label_userid.ForeColor = SystemColors.GrayText;
            label_userid.Location = new Point(195, 230);
            label_userid.Margin = new Padding(2, 0, 2, 0);
            label_userid.Name = "label_userid";
            label_userid.Size = new Size(179, 25);
            label_userid.TabIndex = 5;
            label_userid.Text = "Enter valid 9-digit ID.";
            // 
            // label_registerNow
            // 
            label_registerNow.AutoSize = true;
            label_registerNow.Cursor = Cursors.Hand;
            label_registerNow.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label_registerNow.ForeColor = Color.FromArgb(0, 160, 244);
            label_registerNow.Location = new Point(266, 552);
            label_registerNow.Margin = new Padding(2, 0, 2, 0);
            label_registerNow.Name = "label_registerNow";
            label_registerNow.Size = new Size(140, 28);
            label_registerNow.TabIndex = 4;
            label_registerNow.Text = "Register Now";
            label_registerNow.Click += label_registerNow_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(239, 526);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(202, 25);
            label2.TabIndex = 3;
            label2.Text = "Don't have an account ?";
            // 
            // textBox_password
            // 
            textBox_password.BackColor = Color.Snow;
            textBox_password.BorderStyle = BorderStyle.FixedSingle;
            textBox_password.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_password.ForeColor = SystemColors.ControlText;
            textBox_password.Location = new Point(195, 289);
            textBox_password.Margin = new Padding(2);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(336, 37);
            textBox_password.TabIndex = 2;
            // 
            // textBox_userId
            // 
            textBox_userId.BackColor = Color.Snow;
            textBox_userId.BorderStyle = BorderStyle.FixedSingle;
            textBox_userId.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_userId.ForeColor = SystemColors.ControlText;
            textBox_userId.Location = new Point(195, 181);
            textBox_userId.Margin = new Padding(2);
            textBox_userId.Name = "textBox_userId";
            textBox_userId.Size = new Size(336, 37);
            textBox_userId.TabIndex = 1;
            // 
            // button_loginStart
            // 
            button_loginStart.BackColor = Color.FromArgb(0, 135, 209);
            button_loginStart.FlatStyle = FlatStyle.Flat;
            button_loginStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_loginStart.ForeColor = Color.White;
            button_loginStart.Location = new Point(250, 402);
            button_loginStart.Margin = new Padding(2);
            button_loginStart.Name = "button_loginStart";
            button_loginStart.Size = new Size(182, 59);
            button_loginStart.TabIndex = 0;
            button_loginStart.Text = "Login";
            button_loginStart.UseVisualStyleBackColor = false;
            button_loginStart.Click += button_loginStart_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gainsboro;
            panel3.Location = new Point(296, 69);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(715, 662);
            panel3.TabIndex = 4;
            // 
            // button_teacher
            // 
            button_teacher.Location = new Point(1091, 69);
            button_teacher.Name = "button_teacher";
            button_teacher.Size = new Size(141, 45);
            button_teacher.TabIndex = 10;
            button_teacher.Text = "teacher";
            button_teacher.UseVisualStyleBackColor = true;
            button_teacher.Click += button_teacher_Click;
            // 
            // button1_student
            // 
            button1_student.Location = new Point(1091, 146);
            button1_student.Name = "button1_student";
            button1_student.Size = new Size(141, 45);
            button1_student.TabIndex = 11;
            button1_student.Text = "student";
            button1_student.UseVisualStyleBackColor = true;
            button1_student.Click += button1_student_Click;
            // 
            // button2_student
            // 
            button2_student.Location = new Point(1091, 221);
            button2_student.Name = "button2_student";
            button2_student.Size = new Size(141, 45);
            button2_student.TabIndex = 12;
            button2_student.Text = "student";
            button2_student.UseVisualStyleBackColor = true;
            button2_student.Click += button2_student_Click;
            // 
            // button3_student
            // 
            button3_student.Location = new Point(1091, 295);
            button3_student.Name = "button3_student";
            button3_student.Size = new Size(141, 45);
            button3_student.TabIndex = 13;
            button3_student.Text = "student";
            button3_student.UseVisualStyleBackColor = true;
            button3_student.Click += button3_student_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(button3_student);
            Controls.Add(button2_student);
            Controls.Add(button1_student);
            Controls.Add(button_teacher);
            Controls.Add(panel2);
            Controls.Add(panel3);
            ForeColor = Color.FromArgb(100, 121, 95);
            Margin = new Padding(2);
            Name = "Login";
            Size = new Size(1278, 801);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox textBox_userId;
        private Button button_loginStart;
        private TextBox textBox_password;
        private Label label2;
        private Label label_registerNow;
        private Panel panel3;
        private Label label_userid;
        private Label label_characters;
        private Label label4;
        private Label label3;
        private Button button_teacher;
        private Button button1_student;
        private Button button2_student;
        private Button button3_student;
    }
}
