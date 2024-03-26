using ExamSystem_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamSystem_Project.Helpers
{
    public class ExamAvailability
    {
   
        private DateTime examEndTime;
        private DateTime currentDateTime;
        private Exam exam;
        public const int ExamBuffer = 30;

        public ExamAvailability(Exam Myexam)
        {
            this.exam = Myexam;
        }

        public bool IsExamAvailable()
        {
            try
            {
                currentDateTime = DateTime.Now;
                examEndTime = exam.ExamDateTime.AddMinutes(ExamBuffer);

                // Check if the current date is within the exam date range
                if (currentDateTime.Date == exam.ExamDateTime.Date)
                {
                    // Check if the current time is within the exam time range
                    if (currentDateTime.TimeOfDay >= exam.ExamDateTime.TimeOfDay && currentDateTime.TimeOfDay <= examEndTime.TimeOfDay)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }


            return false;
        }
    }
}