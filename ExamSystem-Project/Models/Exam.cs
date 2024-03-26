using ExamSystem.Client.Helpers;
using ExamSystem_Project.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.VisualStyles;

namespace ExamSystem_Project.Models
{
  
    public class Exam
    {

        #region Properties

        public int ExamId { get; set; }  //AutoIncrement
        public Guid ExamStrId { get; set; }
        public string ExamTitle { get; set; } //Title
        public DateTime ExamDateTime { get; set; } //available for execution
        public string TeacherFullName { get; set; } // when the thecher was logged on the name show automaticly
        public int TotalHours { get; set; } //Total exam Hours duration 
        public int TotalMinutes { get; set; } //Total exam Minutes duration 
        public bool RandomQuestionOrder { get; set; } //Random order of the questions
        public Course_Enum CourseType { get; set; }
        public List<Question> questions { get; set; }
        
        


        #endregion
        public Exam()
        {
            questions = new List<Question>();
            ExamStrId = Guid.NewGuid();
        }



        public override string ToString()
        {
            return "";
        }






    }


}
