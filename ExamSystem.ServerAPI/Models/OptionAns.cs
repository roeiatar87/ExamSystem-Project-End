using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.ServerAPI.Models
{
    public class OptionAns
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OptionAnsId { get; set; }
        public Guid OptionAnsStrId { get; set; }
        public Guid QuestionStrId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
       

    }
}


