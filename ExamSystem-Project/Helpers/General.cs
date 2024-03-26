using ExamSystem_Project.ApiRequestors;
using ExamSystem_Project.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem_Project.Helpers
{
    public class General
    {
        public static MainRequestor mainRequestor;
       

        public General()
        {
            mainRequestor = new MainRequestor();
            
        }


    }
}
