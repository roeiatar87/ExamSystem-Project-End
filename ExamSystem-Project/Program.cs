

using ExamSystem_Project.Forms;
using ExamSystem_Project.Models;

namespace ExamSystem_Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //  Application.Run(new ExamRunForm2(new Exam(), new User()));

            Application.Run(new MainForm());
        }


    }
}