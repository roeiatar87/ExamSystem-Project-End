using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.ServerAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string ?TypeOfUser { get; set; }
        public string ?FullName { get; set; }
        public string PassWord { get; set; }
        public string UserId { get; set; }
        public Course_Enum? CourseType { get; set; }


    }
    public enum Course_Enum
    {

        C_Sharp,
        JavaSctipt
    }

}
