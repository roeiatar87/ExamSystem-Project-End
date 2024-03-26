using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.ServerAPI.Models
{
    public class Participation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ParticipationId { get; set; }
        public string Student_Id { get; set; }
        public string Student_Name { get; set; }
        public int Exam_Id { get; set; }
        public float Grade { get; set; }
        public List<Error> errors { get; set; }


    }
}
