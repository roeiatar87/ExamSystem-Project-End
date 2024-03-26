using ExamSystem_Project.ApiRequestors;
using ExamSystem_Project.Forms;
using ExamSystem_Project.Helpers;
using ExamSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamSystem_Project.FormModels
{
    public class StudentFormModel
    {
        public Exam exam;
        public StudentForm student;
        public List<Exam> exams;
        public static StudentFormModel studentFormModel;
        public ExamRunForm examRun;
        Dictionary<string, int> filterdTags;
        ExamResultForm examResultForm;


        public StudentFormModel(StudentForm studentFrom)
        {

            this.student = studentFrom;
            exam = new Exam();
            exams = new List<Exam>();
            studentFormModel = this;
            filterdTags = new Dictionary<string, int>();

            GetAllExams();

        }
        public async void GetAllExams()
        {
            try
            {
                exams = await General.mainRequestor.Request_GetExamsByCourseType(student.user.CourseType.Value);

                if (exams.Count > 0)
                {
                    for (int i = 0; i < exams.Count; i++)
                    {
                        bool res = await General.mainRequestor.Request_GetByStudentAndExamId(student.user.UserId, exams[i].ExamId);
                        if (res)
                        {
                            student.dataGridView_StudentExam.DataSource = exams;
                            student.dataGridView_StudentExam.Rows[i].Cells[9] = new DataGridViewTextBoxCell();
                            student.dataGridView_StudentExam.Rows[i].Cells[9].Tag = 1;
                            student.dataGridView_StudentExam.Rows[i].Cells[9].Value = "Finished";
                            student.dataGridView_StudentExam.Rows[i].Cells[9].Style.BackColor = Color.LightGray;
                            student.dataGridView_StudentExam.Rows[i].Cells[10].Tag = 0;
                        }
                        else
                        {
                            student.dataGridView_StudentExam.DataSource = exams;
                            student.dataGridView_StudentExam.Rows[i].Cells[9].Tag = 0;
                            student.dataGridView_StudentExam.Rows[i].Cells[10] = new DataGridViewTextBoxCell();
                            student.dataGridView_StudentExam.Rows[i].Cells[10].Value = "No Results Yet";
                            student.dataGridView_StudentExam.Rows[i].Cells[10].Tag = 1;
                            student.dataGridView_StudentExam.Rows[i].Cells[10].Style.BackColor = Color.LightGray;
                        }



                    }


                }

            }
            catch (Exception ex)
            {


            }
        }



        private void SaveCellTags()
        {
            try
            {
                foreach (DataGridViewRow row in student.dataGridView_StudentExam.Rows)
                {
                    DataGridViewCell cell9 = row.Cells[9];
                    DataGridViewCell cell0 = row.Cells[0];
                    if (!filterdTags.ContainsKey(cell0.Value.ToString()))
                    {
                        filterdTags.Add(cell0.Value.ToString(), int.Parse(cell9.Tag.ToString()));
                    }
                    else
                    {
                        filterdTags[cell0.Value.ToString()] = int.Parse(cell9.Tag.ToString());
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }




        private void RestoreCellTags()
        {
            try
            {
                if (student.dataGridView_StudentExam.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in student.dataGridView_StudentExam.Rows)
                    {
                        DataGridViewCell cell9 = row.Cells[9];
                        DataGridViewCell cell0 = row.Cells[0];
                        if (filterdTags.ContainsKey(cell0.Value.ToString()))
                        {
                            cell9.Tag = filterdTags[cell0.Value.ToString()];
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }

        public void FilterRows(string filterValue)
        {
            try
            {

                if (exams.Count > 0)
                {

                    SaveCellTags();
                    List<Exam> filteredList = exams
                         .Where(item => item.ExamTitle.ToLower().Contains(filterValue))
                         .ToList();
                    student.dataGridView_StudentExam.DataSource = null;
                    student.dataGridView_StudentExam.DataSource = filteredList;
                    RestoreCellTags();


                    if (student.dataGridView_StudentExam.Rows.Count > 0)
                    {
                        for (int i = 0; i < student.dataGridView_StudentExam.Rows.Count; i++)
                        {

                            var x = student.dataGridView_StudentExam.Rows[i].Cells[9].Tag;
                            if ((int)x == 1)
                            {
                                student.dataGridView_StudentExam.Rows[i].Cells[9] = new DataGridViewTextBoxCell();
                                student.dataGridView_StudentExam.Rows[i].Cells[9].Tag = 1;
                                student.dataGridView_StudentExam.Rows[i].Cells[9].Value = "Finished";
                                student.dataGridView_StudentExam.Rows[i].Cells[9].Style.BackColor = Color.LightGray;
                                student.dataGridView_StudentExam.Rows[i].Cells[10].Tag = 0;

                            }
                            else
                            {
                                student.dataGridView_StudentExam.Rows[i].Cells[10] = new DataGridViewTextBoxCell();
                                student.dataGridView_StudentExam.Rows[i].Cells[10].Value = "No Results Yet";
                                student.dataGridView_StudentExam.Rows[i].Cells[10].Tag = 1;
                                student.dataGridView_StudentExam.Rows[i].Cells[10].Style.BackColor = Color.LightGray;

                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {


            }



        }

        public void OpenExamResult(User user)
        {
            try
            {
                int index = student.dataGridView_StudentExam.SelectedRows[0].Index;
                exam = exams[index];
                examResultForm = new ExamResultForm(exam, user);
                examResultForm.ShowDialog();

            }
            catch (Exception ex)
            {


            }


        }
        public void OpenExam(User user)
        {
            try
            {


                int index = student.dataGridView_StudentExam.SelectedRows[0].Index;
                exam = exams[index];
                examRun = new ExamRunForm(exam, user, studentFormModel);
                examRun.ShowDialog();

            }
            catch (Exception ex)
            {


            }


        }

    }


}
