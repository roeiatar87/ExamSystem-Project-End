using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ExamSystem_Project.Models
{
    public class Error
    {
        public int ErrorId { get; set; }
        public string QuestionContent { get; set; }
        public string CorrectAnswer { get; set; }
        public string StudentAnswer { get; set; }
        public int ParticipationId { get; set; }

        public override string ToString()
        {
            return QuestionContent;
        }

    }
}
