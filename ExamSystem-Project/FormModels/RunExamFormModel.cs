
using ExamSystem_Project.Forms;
using ExamSystem_Project.Helpers;
using ExamSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ExamSystem_Project.FormModels
{
    public class RunExamFormModel
    {
        public int textBoxCounter = 0; 
        public int optionNameCounter = 1;
        public int CurrectAnswerCount = 0;
        public Exam exam;
        public Label dynamicLabelOption;
        public Question question;
        public OptionAns optionAns;
        public Label dynamicLabel;
        public RadioButton radioButton;
        public List<RadioButton> radioButtonList;
        public List<Label> labelList;
        public List<Label> labelListOptions;
        public List<Control> ControlsList;
        public int questionIndex = 0;
        public ExamRunForm runExam;
        public bool isExist = false;
        public Dictionary<int, int> checkedDictionary;
        public Participation participation;
        public Error error;

        public RunExamFormModel(Exam examFromSt)
        {
            this.runExam = ExamRunForm.runExam;
            this.exam = examFromSt;
            FillAllExamFields();
            radioButtonList = new List<RadioButton>();
            labelListOptions = new List<Label>();
            ControlsList = new List<Control>();
            labelList = new List<Label>();
            checkedDictionary = new Dictionary<int, int>();
            participation = new Participation();

        }

        public void CreateDynamicOptions()
        {

            try
            {

                // Create a unique identifier for the dynamic controls
                string controlId = Guid.NewGuid().ToString();

              
                dynamicLabel = new Label
                {
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 135, 209),
                    Text = "Option " + optionNameCounter + " :",
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    Location = new Point(runExam.label_question.Left, Convert.ToInt32(GetTopMargin())),
                    AutoSize = true,
                    Tag = controlId 
                };

                labelList.Add(dynamicLabel);
                
                dynamicLabelOption = new Label
                {
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    Location = new Point(runExam.textBox_QuetionContent.Left - 80, dynamicLabel.Top),
                    Name = "label_labeloption" + optionNameCounter,
                    AutoSize = true,
                    Tag = controlId, 

                };

                labelListOptions.Add(dynamicLabelOption);


                radioButton = new RadioButton
                {
                    Text = " ",
                    Name = "radioButton_IsCorrect" + optionNameCounter,
                    AutoSize = true,
                    CheckAlign = System.Drawing.ContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 135, 209),
                    Location = new Point(dynamicLabelOption.Right + 10, dynamicLabelOption.Top),
                    Tag = controlId
                };

                radioButton.CheckedChanged += (object sender, EventArgs e) =>
                {
                    SaveMarkedIndex(sender, e);
                };
                radioButtonList.Add(radioButton);



                // Add Label, TextBox, and Delete button to the panel_questions
                runExam.panel_questions.Controls.Add(dynamicLabel);
                runExam.panel_questions.Controls.Add(dynamicLabelOption);
                runExam.panel_questions.Controls.Add(radioButton);

                // Increment the counter for the next TextBox
                textBoxCounter++;
                optionNameCounter++;


            }
            catch (Exception ex)
            {


            }
        }

        public void CreateDynamicFullFields(int val)
        {
            try
            {
                switch (val)
                {
                    case 1:
                        if (questionIndex <= exam.questions.Count - 1)
                        {
                            questionIndex++;
                        }
                        break;
                    case 2:
                        if (questionIndex >= 0)
                        {
                            questionIndex--;
                        }
                        break;
                    default:
                        break;
                }

                runExam.textBox_QuetionContent.Text = exam.questions[questionIndex].Text;
                question = exam.questions[questionIndex];
                runExam.label_qNum.Text = $"{questionIndex + 1} / {exam.questions.Count}";
                for (int i = 0; i < question.Options.Count; i++)
                {
                    CreateDynamicOptions();
                    labelListOptions[i].Text = question.Options[i].ToString();


                    if (val == 1 || val == 2)
                    {
                        if (questionIndex >= 0 && questionIndex < checkedDictionary.Count)
                        {
                            if (checkedDictionary[questionIndex] == i)
                            {
                                radioButtonList[i].Checked = true;
                            }
                        }
                    }
                    // = question.Options[i].IsCorrect;

                }

                if (questionIndex == exam.questions.Count - 1)
                {

                    runExam.button_SaveExamBuilder.Visible = true;
                    runExam.button_next.Visible = false;
                }
                else
                {
                    runExam.button_SaveExamBuilder.Visible = false;
                    runExam.button_next.Visible = true;
                }



            }
            catch (Exception ex)
            {


            }

        }

        public void SaveMarkedIndex(object sender, EventArgs e)
        {
            try
            {
                int index = radioButtonList.FindIndex(x => x.Checked == true);
                if (index >= 0 && !checkedDictionary.ContainsKey(questionIndex))
                {
                    checkedDictionary.Add(questionIndex, index);
                }
                else
                    checkedDictionary[questionIndex] = index;
            }
            catch (Exception ex)
            {

            }
  


        }

        public bool DialogMsgBox()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to send the exam?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public void GetExamAnswers()
        {
            try
            {
                string questionContent = string.Empty;
                string currectAns = string.Empty;
                string worngAns = string.Empty;
                int indexCur = 0;
                int indexWorng = 0;


                for (int i = 0; i < exam.questions.Count; i++)
                {
                    if (checkedDictionary.Keys.Contains(i))
                    {
                        if (exam.questions[i].IndexCorrect == checkedDictionary[i])
                        {
                            CurrectAnswerCount++;
                        }
                        else
                        {
                            questionContent = exam.questions[i].Text;
                            indexCur = exam.questions[i].IndexCorrect;
                            currectAns = exam.questions[i].Options[indexCur].OptionText;
                            indexWorng = checkedDictionary[i];
                            worngAns = exam.questions[i].Options[indexWorng].OptionText;
                            AddError(questionContent, currectAns, worngAns);
                        }
                    }
                    else
                    {
                        questionContent = exam.questions[i].Text;
                        indexCur = exam.questions[i].IndexCorrect;
                        currectAns = exam.questions[i].Options[indexCur].OptionText;
                        worngAns = "answer was empty";
                        AddError(questionContent, currectAns, worngAns);
                    }

                }
            }
            catch (Exception ex)
            {


            }
        }

        public void AddError(string questionContent, string currectAns, string worngAns)
        {
            try
            {
                error = new Error();
                error.QuestionContent = questionContent;
                error.CorrectAnswer = currectAns;
                error.StudentAnswer = worngAns;
                participation.errors.Add(error);

            }
            catch (Exception ex)
            {


            }
        }


        public void CreatePaticipation()
        {
            try
            {

                participation.Exam_Id = exam.ExamId;
                participation.Student_Id = runExam.user.UserId;
                participation.Student_Name = runExam.user.FullName;
                participation.Grade = CalculateExamGrade();
            }
            catch (Exception ex)
            {

            }
        }

        public float CalculateExamGrade()
        {

            try
            {
                float grade = 0;
                float scorePerAns = (float)(100.0 / exam.questions.Count);
                grade = CurrectAnswerCount * scorePerAns;
                grade = (float)Math.Round((double)grade);

                return grade;

            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public async void SaveExam(bool isExpired)
        {
            try
            {
                bool res = false;
                res = isExpired ? true : DialogMsgBox();
                string msg = string.Empty;

                if (res)
                {
                    GetExamAnswers();
                    CreatePaticipation();

                    res = await General.mainRequestor.Request_NewPost<Participation>(participation, "api/participations/create");
                    if (res)
                    {

                        msg = isExpired ? Constants.ExpierdMsg : Constants.SendSuccess;


                        runExam.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show(msg);
                            runExam.Close();
                            runExam.studentModel.GetAllExams();
                        });


                    }
                }
                else
                {
                    return;
                }



            }
            catch (Exception ex)
            {

            }
        }



        private double GetTopMargin()
        {
            try
            {
                double topMargin = 50;

                // Find the last TextBox in panel_questions and adjust the top margin
                if (runExam.panel_questions.Controls.Count > 0)
                {
                    foreach (Control control in runExam.panel_questions.Controls)
                    {
                        if (control is TextBox text)
                        {
                            topMargin += text.Height + 20; // Increase the space between TextBoxes
                        }
                        if (control is Label label)
                        {
                            topMargin += label.Height + 10; // Increase the space between TextBoxes
                        }
                    }
                }

                return topMargin;
            }
            catch (Exception ex)
            {
               return 0;


            }
       
        }

        public void FillAllExamFields()
        {

            runExam.label_examTitle_S.Text = exam.ExamTitle;
            runExam.label_TeacherName_S.Text = exam.TeacherFullName;
            runExam.label_totalExamTime_S.Text = $"{exam.TotalHours:00}:{exam.TotalMinutes:00}";
            runExam.label_course_S.Text = exam.CourseType.ToString();
            runExam.label_pointQuestion_S.Text = (100.0 / exam.questions.Count).ToString("F2");

        }

        public void ClearAllControls()
        {
            try
            {
                for (int i = 0; i < radioButtonList.Count; i++)
                {
                    runExam.panel_questions.Controls.Remove(labelList[i]);
                    runExam.panel_questions.Controls.Remove(labelListOptions[i]);
                    runExam.panel_questions.Controls.Remove(radioButtonList[i]);

                }
                textBoxCounter = 0;
                optionNameCounter = 1;

                runExam.textBox_QuetionContent.Text = string.Empty;
                labelListOptions = new List<Label>();
                radioButtonList = new List<RadioButton>();
                labelList = new List<Label>();
            }
            catch (Exception ex)
            {

            
            }
        }


        public void CreateQuestions()
        {
            try
            {
                runExam.panel_questions.BringToFront();
                runExam.tabControl1.TabPages.Add(runExam.tabPage_step2);
                runExam.tabControl1.TabPages.Remove(runExam.tabPage_step1);
                ClearAllControls();
                CreateDynamicFullFields(0);
            }
            catch (Exception ex)
            {



            }
        }

    }
}
