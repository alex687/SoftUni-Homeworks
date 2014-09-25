using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> ExelentMarks = new List<int>()
                {
                    6,5,6,4,6
                };
            List<int> PoorMarks = new List<int>()
            {
                2,3,4,2,5
            };
            
            List<Student> students = new List<Student>()
            {
                new Student("Robert", "De Niro", "284933914", "+3598752156", "robi@mail.bg", ExelentMarks, 50, "Himiq"),
                new Student("Danny", "DeVito", "4982589391", "0254896515", "dani@abv.bg", ExelentMarks, 30, "Himiq"),
                new Student("George", "Clooney", "1234614589", "+3592478435", "george@gmail.bg", PoorMarks, 20, "Fizika"),
                new Student("Dustin", "Hoffman", "812328919845", "+35921478435", "dustin@gmail.bg", PoorMarks, 23, "Matematika"),
            };

            // Problem 4.	Students by Group

            //Problem 5.	Students by First and Last Name
            Console.WriteLine("Problem 5.Students by First and Last Name");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FirstNameBeforeLastName(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 6.	Students by Age
            Console.WriteLine("Problem 6.Students by Age");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.Age(students,18,24));
            Console.WriteLine("-----------------------------------------");

            // Problem 7.	Sort Students
            Console.WriteLine("Problem 7. Sort Students");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.Sort(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 8.	Filter Students by Email Domain
            Console.WriteLine("Problem 8.Filter Students by Email Domain");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.EmailDomainFilter(students, "abv.bg"));
            Console.WriteLine("-----------------------------------------");

            // Problem 9.	Filter Students by Phone
            Console.WriteLine("Problem 9.Filter Students by Phone");
            Console.WriteLine("-----------------------------------------");
            List<string> numberStartsWith = new List<string>()
            {
                "02","+3592", "+359 2"
            };
            Print(Solutions.PhoneFilter(students, numberStartsWith));
            Console.WriteLine("-----------------------------------------");

            // Problem 10.	Excellent Students
            Console.WriteLine("Problem 10.Excellent Students");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FilterExcelentStudents(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 11.	Weak Students
            Console.WriteLine("Problem 11.Weak Students");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FilterWeakStudents(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 12.	Students Enrolled in 2014
            Console.WriteLine("Problem 12.Students Enrolled in 2014");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FilterEntrolled(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 13.	*Students by Groups
            Console.WriteLine("Problem 13.*Students by Groups");
            Console.WriteLine("-----------------------------------------");
             Solutions.GroupStudents(students);
            Console.WriteLine("-----------------------------------------");

        }

        public static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

    }
}
