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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSystem_Project.Forms
{
    public partial class ExamResultForm : Form
    {
        public Exam exam;
        public User user;
        public List<Error> errorsList;
        public Error error;
        public Participation participation;


        public ExamResultForm(Exam recivedexam, User reciveduser)
        {
            InitializeComponent();
            this.user = reciveduser;
            this.exam = recivedexam;
            InitializeAll();
        }


        public void InitializeAll()
        {
            // Set DPI Awareness
            this.AutoScaleMode = AutoScaleMode.Dpi;

            // Set StartPosition to Manual
            StartPosition = FormStartPosition.CenterScreen;

            // Calculate and set the position and size of the form
            Rectangle screen = Screen.FromPoint(Cursor.Position).WorkingArea;

            // Set maximum width and height for the form
            int maxWidth = screen.Width - 100; // Adjust this value as needed
            int maxHeight = screen.Height - 100; // Adjust this value as needed
            int desiredFormWidth = 1200; // Set your desired form width
            int w = Math.Min(desiredFormWidth, maxWidth);
            int h = Math.Min(Height, maxHeight);

            int dataGridViewWidth = 1500; // Set your desired width


            Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
            Size = new Size(w, h);

            participation = new Participation();
            errorsList = new List<Error>();
            error = new Error();
            GetPaticipation();
            label_examName.Text = exam.ExamTitle;
        }


        public async void GetPaticipation()
        {
            try
            {
                participation = await General.mainRequestor.Request_GetParticipationBySE(user.UserId, exam.ExamId);
                UpdateStudentLabels();
                GetErrors();

            }
            catch (Exception ex)
            {


            }

        }


        public void GetErrors()
        {
            try
            {
                listBox_errorsList.DataSource = null;
                listBox_errorsList.Items.Clear();

                if (participation != null)
                {
                    if (participation.errors.Count > 0)
                    {
                        foreach (var item in participation.errors)
                        {
                            listBox_errorsList.Items.Add(item.QuestionContent);
                            errorsList.Add(item);
                        }
                        listBox_errorsList.SelectedIndex = 0;
                        label_selectedAnswer.Visible = true;
                        label_currectAnswer.Visible = true;
                        GetError();
                        UpdateAnswersLabels();
                    }
                    else
                    {
                        listBox_errorsList.Items.Add("No Errors congratulations :)");
                        label_selectedAnswer.Visible = false;
                        label_currectAnswer.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }

        public void GetError()
        {
            try
            {
                var index = listBox_errorsList.SelectedIndex;
                if (index != -1)
                {
                    error = errorsList[index];
                }

            }
            catch (Exception ex)
            {


            }

        }

        public void UpdateStudentLabels()
        {
            label_studentName.Text = participation.Student_Name;
            label_idStudent.Text = participation.Student_Id;
            label_gradeStudent.Text = participation.Grade.ToString();
        }

        public void UpdateAnswersLabels()
        {
            label_currectAnswer.Text = error.CorrectAnswer;
            label_selectedAnswer.Text = error.StudentAnswer;
        }

        private void listBox_errorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetError();
            UpdateAnswersLabels();
        }
    }
}
