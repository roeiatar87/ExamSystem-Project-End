using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.ServerAPI.Models
{
    public class Question
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionId { get; set; }
        public Guid QuestionStrId { get; set; }
        public string Text { get; set; }
        public List<OptionAns> Options { get; set; }
        public Guid ExamStrId { get; set; }
        public bool RandomAnsOrder { get; set; }
        public int IndexCorrect { get; set; }
    }
}

