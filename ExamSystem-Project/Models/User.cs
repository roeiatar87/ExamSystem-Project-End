using ExamSystem.Client.Helpers;
using ExamSystem_Project.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamSystem_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string TypeOfUser { get; set; }
        public string FullName { get; set; }
        public string PassWord { get; set; }
        public string UserId { get; set; }
        public Course_Enum? CourseType { get; set; }

        public User(int id, string? typeOfUser, string? fullname, string? userId , Course_Enum course_, string password)
        {
            Id = id;
            TypeOfUser = typeOfUser;
            FullName = fullname;
            UserId = userId;
            CourseType = course_;
            PassWord = password;
        }
        public User( string? typeOfUser, string? fullname, string? userId, Course_Enum course_,string password)
        {
            
            TypeOfUser = typeOfUser;
            FullName = fullname;
            UserId = userId;
            CourseType = course_;
            PassWord = password;
        }

        public User() { }
    }



}
