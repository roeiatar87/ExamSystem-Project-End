using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem_Project.Models
{
    public class Question
    {


        public int QuestionId { get; set; }
        public Guid QuestionStrId { get; set; }
        public string Text { get; set; }
        public List<OptionAns> Options { get; set; }
        public Guid ExamStrId { get; set; }
        public bool RandomAnsOrder { get; set; }
        public Exam exam { get; set; }
        public int IndexCorrect
        {
            get
            {
                int foundIndex = -1;
                var option = Options.SingleOrDefault(o => o.IsCorrect == true);
                if (option != null)
                {
                    foundIndex = Options.IndexOf(option);
                }
                return foundIndex;
            }
        }

        public Question()
        {
            QuestionStrId = Guid.NewGuid();
            Options = new List<OptionAns>();

        }

        public override string? ToString()
        {
            return $"{Text}";
        }
    }
}

