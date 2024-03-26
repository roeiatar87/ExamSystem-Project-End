using ExamSystem_Project.ApiRequestors;
using ExamSystem_Project.Forms;
using ExamSystem_Project.Helpers;
using ExamSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSystem_Project.FormModels
{

    public class TeacherFormModel
    {
        public Exam exam;
        public List<Exam> exams;
        public TeacherForm teacher;
        public General gen = new General();
        public static TeacherFormModel teacherFormModel;
        public DataTable dataTable;
        Dictionary<string, int> filterdTags;
        BuildExamForm buildExam;
        StatisticsForm statisticsForm;
        public TeacherFormModel(TeacherForm teacherForm)
        {
            exam = new Exam();
            exams = new List<Exam>();
            this.teacher = teacherForm;
            teacherFormModel = this;
            filterdTags = new Dictionary<string, int>();
            GetAllExams();

        }
        public async void GetAllExams()
        {
            try
            {
                exams = await General.mainRequestor.Request_GetAll<Exam>("api/exams/getallexams");
                if (exams.Count > 0)
                {
                    teacher.dataGridView_teacherExams.DataSource = exams;
                    for (int i = 0; i < exams.Count; i++)
                    {
                        var res = await General.mainRequestor.Request_GetById<Participation?>(exams[i].ExamId.ToString(), "api/participations");
                        if (res.Student_Id != null)
                        {
                            teacher.dataGridView_teacherExams.DataSource = exams;
                            teacher.dataGridView_teacherExams.Rows[i].Cells[9] = new DataGridViewTextBoxCell();
                            teacher.dataGridView_teacherExams.Rows[i].Cells[9].Tag = 1;
                            teacher.dataGridView_teacherExams.Rows[i].Cells[9].Value = "Executed";
                            teacher.dataGridView_teacherExams.Rows[i].Cells[9].Style.BackColor = Color.LightGray;
                            teacher.dataGridView_teacherExams.Rows[i].Cells[10].Tag = 0;
                        }
                        else
                        {
                            teacher.dataGridView_teacherExams.DataSource = exams;
                            teacher.dataGridView_teacherExams.Rows[i].Cells[9].Tag = 0;
                            teacher.dataGridView_teacherExams.Rows[i].Cells[10] = new DataGridViewTextBoxCell();
                            teacher.dataGridView_teacherExams.Rows[i].Cells[10].Value = "No Statistics";
                            teacher.dataGridView_teacherExams.Rows[i].Cells[10].Tag = 1;
                            teacher.dataGridView_teacherExams.Rows[i].Cells[10].Style.BackColor = Color.LightGray;
                        }
                    }
                }
                else
                {
                    teacher.dataGridView_teacherExams.DataSource = null;
                }
                teacher.CheckDataGridEmpty();
            }
            catch (Exception ex)
            {


            }
        }



        private void SaveCellTags()
        {
            try
            {
                foreach (DataGridViewRow row in teacher.dataGridView_teacherExams.Rows)
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
                if (teacher.dataGridView_teacherExams.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in teacher.dataGridView_teacherExams.Rows)
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
                    teacher.dataGridView_teacherExams.DataSource = null;
                    teacher.dataGridView_teacherExams.DataSource = filteredList;
                    RestoreCellTags();

                    if (teacher.dataGridView_teacherExams.Rows.Count > 0)
                    {
                        for (int i = 0; i < teacher.dataGridView_teacherExams.Rows.Count; i++)
                        {

                            var x = teacher.dataGridView_teacherExams.Rows[i].Cells[9].Tag;
                            if ((int)x == 1)
                            {
                                teacher.dataGridView_teacherExams.Rows[i].Cells[9] = new DataGridViewTextBoxCell();
                                teacher.dataGridView_teacherExams.Rows[i].Cells[9].Tag = 1;
                                teacher.dataGridView_teacherExams.Rows[i].Cells[9].Value = "Executed";
                                teacher.dataGridView_teacherExams.Rows[i].Cells[9].Style.BackColor = Color.LightGray;
                                teacher.dataGridView_teacherExams.Rows[i].Cells[10].Tag = 0;
                            }
                            else
                            {
                                teacher.dataGridView_teacherExams.Rows[i].Cells[10] = new DataGridViewTextBoxCell();
                                teacher.dataGridView_teacherExams.Rows[i].Cells[10].Value = "No Statistics";
                                teacher.dataGridView_teacherExams.Rows[i].Cells[10].Tag = 1;
                                teacher.dataGridView_teacherExams.Rows[i].Cells[10].Style.BackColor = Color.LightGray;

                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {


            }



        }


        public void OpenExistExam(User user)
        {
            try
            {
                int index = teacher.dataGridView_teacherExams.SelectedRows[0].Index;
                exam = exams[index];
                buildExam = new BuildExamForm(exam, user);
                buildExam.ShowDialog();
            }
            catch (Exception ex)
            {


            }
        }

        public void OpenExamStatistics(User user)
        {
            try
            {
                int index = teacher.dataGridView_teacherExams.SelectedRows[0].Index;
                exam = exams[index];
                statisticsForm = new StatisticsForm(exam, user);
                statisticsForm.ShowDialog();
            }
            catch (Exception ex)
            {


            }
        }

        public void CreateNewExam(User user)
        {
            buildExam = new BuildExamForm(null, user);
            buildExam.ShowDialog();
        }

        public bool DialogMsgBox()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete?\n exam : {exam.ExamTitle}", "Confirmation", MessageBoxButtons.YesNo);

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

        public async void DeleteExam()
        {
            try
            {
                bool res = false;
                int index = teacher.dataGridView_teacherExams.SelectedRows[0].Index;
                exam = exams[index];

                 res = DialogMsgBox();
                if (res)
                {
                    res = await General.mainRequestor.Request_Delete(exam.ExamId.ToString(), "api/exams");

                    if (res)
                    {
                        MessageBox.Show(Constants.successDelete);
                        GetAllExams();
                    }
                    else
                    {
                        MessageBox.Show(Constants.notSuccessReg);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
