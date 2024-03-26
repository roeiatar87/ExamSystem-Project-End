using ExamSystem_Project.ApiRequestors;
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

namespace ExamSystem_Project.UserControls
{
    public partial class Register : UserControl
    {

        public bool success;
        public string selectedItem;
        public UserType_Enum userType;
        public Course_Enum? courseType;
        public string fullname;
        public string userid;
        public User user;
        public string password;

        public Register()
        {
            InitializeComponent();

            success = false;
            selectedItem = string.Empty;
            userType = new UserType_Enum();
            courseType = new Course_Enum();
            fullname = string.Empty;
            userid = string.Empty;
            password = string.Empty;
            user = new User();
            label_firlas.Visible = false;
            label_pass.Visible = false;
            label_cour.Visible = false;
            label_teaStu.Visible = false;
            label_id.Visible = false;
        }

        private void label_LoginNow_Click(object sender, EventArgs e)
        {
          
            MainForm.main.UISwitch("Login");
        }

        private async void button_Register_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox_textName.Text == "") || textBox_textid.Text == "")
                {
                    MessageBox.Show(Helpers.Constants.requiredfields);
                }
                else if (comboBox_Type.SelectedIndex == 0)
                {
                    MessageBox.Show(Helpers.Constants.typeSelect);
                }
                else
                {
                    selectedItem = comboBox_Type.SelectedItem.ToString();
                    //Convert String from ComboBox (string) to Enum UserType  
                   bool res = Enum.TryParse(selectedItem, out UserType_Enum userType);
                    if (res)
                    {
                        if (userType == UserType_Enum.Student && comboBox_Course_Select.SelectedIndex == 0)
                        {
                            MessageBox.Show(Helpers.Constants.curseSelect);
                        }
                        else
                        {
                            password = textBox_password.Text;
                            fullname = textBox_textName.Text;
                            userid = textBox_textid.Text;
                            if (!Regex.IsMatch(fullname, "^[a-zA-Z]+\\s[a-zA-Z]+$"))
                            {
                                MessageBox.Show(Helpers.Constants.fullNameRegex);

                                return;
                            }
                            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                            {
                                MessageBox.Show(Helpers.Constants.passwordRegex);
                                return;
                            }
                            if (!Regex.IsMatch(userid, "^[0-9]{9}$"))
                            {
                                MessageBox.Show(Helpers.Constants.userIdRegex);
                                return;
                            }
                            if (userType == UserType_Enum.Teacher)
                            {
                                courseType = null;
                            }

                            user = new User() { TypeOfUser = userType.ToString(), FullName = fullname, UserId = userid, CourseType = courseType, PassWord = password };

                            User rtnUser = await General.mainRequestor.Request_GetById<User>(userid, $"api/users");
                            if (rtnUser.UserId == null)
                            {

                                success = await General.mainRequestor.Request_NewPost(user, "api/users/register");
                                if (success)
                                {

                                    MessageBox.Show(Helpers.Constants.successReg);
                                    ResetFormControls();
                                    MainForm.main.UISwitch("Login");


                                }
                                else
                                {
                                    MessageBox.Show(Helpers.Constants.notSuccessReg);
                                    return;
                                }
                            }

                            else
                            {
                                MessageBox.Show(Helpers.Constants.alreadyExists);
                            }
                        }
                    }
                  


                }
            }
            catch (Exception ex)
            {

             
            }

          


        }

        private void ResetFormControls()
        {
            textBox_textName.Text = string.Empty;
            textBox_textid.Text = string.Empty;
            textBox_password.Text = string.Empty;
            comboBox_Type.SelectedIndex = 0;
            label_firlas.Visible = false;
            label_id.Visible = false;
            label_pass.Visible = false;
            label_cour.Visible = false;
            label_teaStu.Visible = false;
        }

        private void Register_Load(object sender, EventArgs e)
        {

            comboBox_Type.Items.Insert(0, "Click to select");
            comboBox_Type.SelectedIndex = 0;
            comboBox_Type.Items.Insert(1, UserType_Enum.Teacher);
            comboBox_Type.Items.Insert(2, UserType_Enum.Student);

            comboBox_Course_Select.Items.Insert(0, "Click to select");
            comboBox_Course_Select.SelectedIndex = 0;
            comboBox_Course_Select.Items.Insert(1, Course_Enum.C_Sharp);
            comboBox_Course_Select.Items.Insert(2, Course_Enum.JavaSctipt);
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_Type.SelectedIndex)
            {
                case 1:
                    comboBox_Course_Select.Enabled = false;
                    break;
                case 2:
                    comboBox_Course_Select.Enabled = true;
                    label_cour.Visible = true;

                    break;
                default:
                    comboBox_Course_Select.Enabled = false;
                    break;
            }
        }

        private void textBox_textName_TextChanged(object sender, EventArgs e)
        {
            label_firlas.Visible = true;
        }

        private void textBox_textid_TextChanged(object sender, EventArgs e)
        {
            label_id.Visible = true;
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            label_pass.Visible = true;
        }

        private void comboBox_Type_MouseClick(object sender, MouseEventArgs e)
        {
            label_teaStu.Visible = true;
        }


    }
}
