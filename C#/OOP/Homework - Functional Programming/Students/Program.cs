namespace Students
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> exelentMarks = new List<int>()
                {
                    6, 5, 6, 4, 6
                };
            List<int> poorMarks = new List<int>()
            {
                2, 3, 4, 2, 5
            };

            List<Student> students = new List<Student>()
            {
                new Student("Robert", "De Niro", "284933914", "+3598752156", "robi@mail.bg", exelentMarks, 50, "Himiq", 1),
                new Student("Danny", "DeVito", "4982589391", "0254896515", "dani@abv.bg", exelentMarks, 30, "Himiq", 2),
                new Student("George", "Clooney", "1234614589", "+3592478435", "george@gmail.bg", poorMarks, 20, "Fizika", 1),
                new Student("Dustin", "Hoffman", "1234614589", "+35921478435", "dustin@gmail.bg", poorMarks, 23, "Matematika", 2),
            };

            // Problem 4.Students by Group
            Console.WriteLine("Problem 4.	Students by Group");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.GetByGroup(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 5.Students by First and Last Name
            Console.WriteLine("Problem 5.Students by First and Last Name");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FirstNameBeforeLastName(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 6.Students by Age
            Console.WriteLine("Problem 6.Students by Age");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.Age(students, 18, 24));
            Console.WriteLine("-----------------------------------------");

            // Problem 7.Sort Students
            Console.WriteLine("Problem 7. Sort Students");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.Sort(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 8.Filter Students by Email Domain
            Console.WriteLine("Problem 8.Filter Students by Email Domain");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.EmailDomainFilter(students, "abv.bg"));
            Console.WriteLine("-----------------------------------------");

            // Problem 9.Filter Students by Phone
            Console.WriteLine("Problem 9.Filter Students by Phone");
            Console.WriteLine("-----------------------------------------");
            List<string> numberStartsWith = new List<string>()
            {
                "02", "+3592", "+359 2"
            };
            Print(Solutions.PhoneFilter(students, numberStartsWith));
            Console.WriteLine("-----------------------------------------");

            // Problem 10.Excellent Students
            Console.WriteLine("Problem 10.Excellent Students");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FilterExcelentStudents(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 11.Weak Students
            Console.WriteLine("Problem 11.Weak Students");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FilterWeakStudents(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 12.Students Enrolled in 2014
            Console.WriteLine("Problem 12.Students Enrolled in 2014");
            Console.WriteLine("-----------------------------------------");
            Print(Solutions.FilterEntrolled(students));
            Console.WriteLine("-----------------------------------------");

            // Problem 13.*Students by Groups
            Console.WriteLine("Problem 13.*Students by Groups");
            Console.WriteLine("-----------------------------------------");
            Solutions.GroupStudents(students);
            Console.WriteLine("-----------------------------------------");

            // Problem 14.* Students Joined To Specialties
            Console.WriteLine("Problem 14.* Students Joined To Specialties");
            Console.WriteLine("-----------------------------------------");
            var specialties = new List<StudentSpecialty>() 
            { 
                new StudentSpecialty("Web Developer", "284933914"),
                new StudentSpecialty("QA", "4982589391"),
                new StudentSpecialty("Web Developer", "800014"),
                new StudentSpecialty("QA", "850014"),
                new StudentSpecialty("Web Developer", "1234614589"),
            };
            Solutions.JoinStudentsWithSpecialties(students, specialties);
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
