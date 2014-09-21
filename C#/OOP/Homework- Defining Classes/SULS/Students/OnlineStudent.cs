using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS.Students
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string fName, string lName, string number, double avgGrade, string curCourse, int age = 0)
            : base(fName, lName, number, avgGrade, curCourse, age)
        {
        }
    }
}
