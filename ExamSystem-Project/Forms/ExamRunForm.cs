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
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using ExamSystem_Project.FormModels;
using ExamSystem.Client.Helpers;
using ExamSystem_Project.ApiRequestors;

namespace ExamSystem_Project.Forms
{
    public partial class ExamRunForm : Form
    {

        private readonly int[] numbersArr = { 1, 2, 3, 4, 5, 6, 7 };
        public RunExamFormModel examModel;
        public static ExamRunForm runExam;
        public StudentFormModel studentModel;
        public User user;
        public TimerClass timer;
        public ExamAvailability examAvailability;
       


        public ExamRunForm(Exam exam, User user1, StudentFormModel stu)
        {
            InitializeComponent();
            this.user = user1;
            InitializeAll();
            runExam = this;
            examAvailability = new ExamAvailability(exam);
            examModel = new RunExamFormModel(exam);
            this.studentModel = stu;
            timer = new TimerClass(exam.TotalHours, exam.TotalMinutes, 00);
            timer.TimeUpdater += Timer_Update;
        }

        public void InitializeAll()
        {
            try
            {
                tabControl1.TabPages.Remove(tabPage_step2);
                panel_questions.SendToBack();

                // Set DPI Awareness
                this.AutoScaleMode = AutoScaleMode.Dpi;

                // Set StartPosition to Manual
                StartPosition = FormStartPosition.CenterScreen;

                // Calculate and set the position and size of the form
                Rectangle screen = Screen.FromPoint(Cursor.Position).WorkingArea;

                // Set maximum width and height for the form
                int maxWidth = screen.Width - 100; // Adjust this value as needed
                int maxHeight = screen.Height - 100; // Adjust this value as needed
                int desiredFormWidth = 1546; // Set your desired form width
                int w = Math.Min(desiredFormWidth, maxWidth);
                int h = Math.Min(Height, maxHeight);

                Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
                Size = new Size(w, h);

                button_SaveExamBuilder.Visible = false;
                button_next.Visible = false;
                button_Previous.Visible = false;
             
            }
            catch (Exception ex)
            {


            }
        }

        //Updating the Timer
        public void Timer_Update(object sender, MyTimerEventArgs e)
        {
            label_timer.Invoke((MethodInvoker)delegate { label_timer.Text = sender.ToString(); });
            if (e.IsExpired)
            {
                examModel.SaveExam(e.IsExpired);
            }
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            try
            {
                button_Previous.Visible = true;
                if (examModel.questionIndex != examModel.exam.questions.Count - 1)
                {
                    examModel.ClearAllControls();
                    examModel.CreateDynamicFullFields(1);

                }

            }
            catch (Exception ex)
            {


            }
        }

        private void button_Previous_Click(object sender, EventArgs e)
        {
            try
            {

                if (examModel.questionIndex > 0)
                {
                    examModel.ClearAllControls();
                    examModel.CreateDynamicFullFields(2);
                }
            }
            catch (Exception ex)
            {


            }

        }

        public void ExamButtonHandler(Label text)
        {
            ChangeTextBoxColor(text);
            bool res = CheckEmptyPanelControls(panel1);
            button_next.Enabled = res;

        }

        public bool CheckEmptyPanelControls(Panel panel)
        {
            bool res = true;
            foreach (Control item in panel.Controls)
            {
                if (item is TextBox t)
                {
                    if (string.IsNullOrEmpty(t.Text))
                    {

                        res = false;
                        break;
                    }
                }
                if (item is ComboBox c)
                {
                    if (c.SelectedItem == null || c.SelectedIndex == -1)
                    {
                        res = false;
                        break;
                    }
                }
            }

            return res;
        }

        public void ChangeTextBoxColor(Label text)
        {
            if (text.Text == string.Empty)
            {
                text.BackColor = Color.MistyRose;
            }
            else
            {
                text.BackColor = Color.White;
            }
        }

        private void button_SaveExamBuilder_Click(object sender, EventArgs e)
        {
            examModel.SaveExam(false);
        }

        private void button_start_Click(object sender, EventArgs e)
        {

            bool res = false;
            res = examAvailability.IsExamAvailable();

            if (res)
            {

                examModel.CreateQuestions();
                timer.StartTimer();
                button_next.Visible = true;
            }
            else
            {
                MessageBox.Show(Constants.NotAvailable + examModel.exam.ExamDateTime);
            }

        }

        private void ExamRunForm_Shown(object sender, EventArgs e)
        {

        }

        private void ExamRunForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
