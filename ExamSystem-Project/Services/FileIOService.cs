//using ExamSystem.Client.Models;
//using Microsoft.Win32;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using System.Xml;


//namespace ExamSystem.Client.Services
//{
//    public class FileIOService
//    {
//        public static void SaveTeacherToFile(Teacher teacher)
//        {
//            string usersFolder = CreateUsersFolder();
//            string path = Path.Combine(usersFolder, "Teachers.json");

//            // If the file exists, read the existing JSON data from it
//            List<Teacher> existingList = ReadTeachersFromFile();


//            // Add the new data to the existing list
//            existingList.Add(teacher);

//            // Serialize the updated list to JSON
//            var options = new JsonSerializerOptions { WriteIndented = true };
//            string updatedJson = JsonSerializer.Serialize(existingList, options);

//            // Write the updated JSON back to the file
//            File.WriteAllText(path, updatedJson);

//        }

//        public static void SaveStudentToFile(Student student)
//        {
//            string usersFolder = CreateUsersFolder();
//            string path = Path.Combine(usersFolder, "Students.json");

//            // If the file exists, read the existing JSON data from it
//            List<Student> existingList = ReadStudentsFromFile();

//            // Add the new data to the existing list
//            existingList.Add(student);

//            // Serialize the updated list to JSON
//            var options = new JsonSerializerOptions { WriteIndented = true };
//            string updatedJson = JsonSerializer.Serialize(existingList, options);

//            // Write the updated JSON back to the file
//            File.WriteAllText(path, updatedJson);

//        }



//        public static List<Teacher> ReadTeachersFromFile()
//        {
//            string usersFolder = CreateUsersFolder();
//            string path = Path.Combine(usersFolder, "Teachers.json");

//            // If the file exists, read the existing JSON data from it
//            List<Teacher> existingList = new List<Teacher>();
//            if (File.Exists(path))
//            {
//                string existingJson = File.ReadAllText(path);
//                existingList = JsonSerializer.Deserialize<List<Teacher>>(existingJson);
//            }

//            return existingList;
//        }

//        public static List<Student> ReadStudentsFromFile()
//        {
//            string usersFolder = CreateUsersFolder();
//            string path = Path.Combine(usersFolder, "Students.json");

//            // If the file exists, read the existing JSON data from it
//            List<Student> existingList = new List<Student>();
//            if (File.Exists(path))
//            {
//                string existingJson = File.ReadAllText(path);
//                existingList = JsonSerializer.Deserialize<List<Student>>(existingJson);
//            }

//            return existingList;
//        }



//        private static string CreateUsersFolder()
//        {
//            //Check If Directory Not Exsist 
//            if (!Directory.Exists("AppData\\Users"))
//            {
//                //Create New Directory (bin/debug....)
//                Directory.CreateDirectory("AppData\\Users");
//            }

//            return "AppData\\Users";

//        }


//    }
//}
