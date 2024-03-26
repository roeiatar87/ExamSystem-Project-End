using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.ServerAPI.Models
{
    public class Error
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ErrorId { get; set; }
        public string QuestionContent { get; set; }
        public string CorrectAnswer { get; set; }
        public string StudentAnswer { get; set; }
        public int ParticipationId { get; set; }
       // public Participation participation { get; set; }
    }
}
