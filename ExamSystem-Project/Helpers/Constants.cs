using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem_Project.Helpers
{
   public static class Constants
    {
        public const string requiredfields = "All Feelds Must be Full!";
        public const string typeSelect = "Pleas Select Your Type\nTecher/Student";
        public const string curseSelect = "Pleas Select Your Course!";
        public const string successReg = "You have successfully registered";
        public const string notSuccessReg = "Erorr: Not successfull";
        public const string alreadyExists = "User already exists";
        public const string userIdRegex = "User ID should be a valid ID consisting of 9 digits.";
        public const string fullNameRegex = "Please enter a full name with a first name and a last name.";
        public const string invalidMsg = "Invalid Name or Id!";
        public const string passwordRegex = "Password must meet the following criteria:\n" +
                    "- At least one uppercase letter\n" +
                    "- At least one lowercase letter\n" +
                    "- At least one digit\n" +
                    "- Minimum length of 8 characters";
        public const string About = "The Exam System is a comprehensive platform designed to facilitate the creation, administration, and evaluation of exams.\n\n"
                + "It serves both educators (teachers) and students, providing a seamless and efficient process for conducting assessments.";
        public const string BuildSuccess = "Build Exam Successfully";
        public const string SendSuccess = "Send Exam Successfully";
        public const string ExpierdMsg = "Time expired";
        public const string NotAvailable = "Exam is not available for execution!\nexam date is :";
        public const string successDelete = "Delete successfully";

    }
}


