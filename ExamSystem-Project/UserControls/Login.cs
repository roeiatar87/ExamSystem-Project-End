using ExamSystem_Project.ApiRequestors;
using ExamSystem_Project.Forms;
using ExamSystem_Project.Helpers;
using ExamSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamSystem_Project.UserControls
{
    public partial class Login : UserControl
    {


        public string userid;
        public string password;
        public User? userResponse;
        public User user;
        StudentForm student;
        TeacherForm teacher;

        public Login()
        {
            InitializeComponent();
            //button_loginStart.Enabled = false;
            userid = string.Empty;
            password = string.Empty;
            user = new User();
            userResponse = new User();



        }

        private void label_registerNow_Click(object sender, EventArgs e)
        {
            MainForm.main.UISwitch("Register");
        }


        private async void button_loginStart_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox_password.Text == "") || textBox_userId.Text == "")
                {
                    MessageBox.Show(Constants.requiredfields);
                }
                else
                {


                    password = textBox_password.Text;
                    userid = textBox_userId.Text;

                    if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                    {
                        MessageBox.Show(Helpers.Constants.passwordRegex);
                        return;
                    }
                    if (!Regex.IsMatch(userid, "^[0-9]{9}$"))
                    {
                        MessageBox.Show(Constants.userIdRegex);
                        return;
                    }
                  
                    user = new User() { PassWord = password, UserId = userid };
                    userResponse = await General.mainRequestor.Request_LoginAsync(user);

                    if (userResponse != null)
                    {
                        if (userResponse.TypeOfUser == "Student")
                        {

                            student = new StudentForm(userResponse);
                            student.Show();
                            MainForm.main.Hide();
                        }
                        else if (userResponse.TypeOfUser == "Teacher")
                        {
                            teacher = new TeacherForm(userResponse);
                            teacher.Show();

                            MainForm.main.Hide();

                        }
                    }
                    else
                    {
                        MessageBox.Show(Constants.invalidMsg);
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        private void button_teacher_Click(object sender, EventArgs e)
        {
            textBox_userId.Text = "301325528";
            textBox_password.Text = "Roei1234";
        }

        private void button1_student_Click(object sender, EventArgs e)
        {
            textBox_userId.Text = "300884335";
            textBox_password.Text = "Roei1234";
        }

        private void button2_student_Click(object sender, EventArgs e)
        {
            textBox_userId.Text = "339923054";
            textBox_password.Text = "Roei1234";
        }

        private void button3_student_Click(object sender, EventArgs e)
        {
            textBox_userId.Text = "344912936";
            textBox_password.Text = "Roei1234";
        }
    }
}
