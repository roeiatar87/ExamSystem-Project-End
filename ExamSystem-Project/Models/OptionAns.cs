using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem_Project.Models
{
    public class OptionAns
    {
        public int OptionAnsId { get; set; }
        public Guid OptionAnsStrId { get; set; }
        public Guid QuestionStrId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
        public Question question { get; set; }
        public OptionAns()
        {
            OptionAnsStrId = Guid.NewGuid();
        }

        public override string? ToString()
        {
            return OptionText.ToString();
        }
    }
}


