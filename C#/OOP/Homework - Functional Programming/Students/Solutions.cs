using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public static class Solutions
    {
        public static IEnumerable<Student> FirstNameBeforeLastName(List<Student> students)
        {
            //return students.Where((s) => s.FirstName.CompareTo(s.LastName) < 0);
            return from s in students
                   where s.FirstName.CompareTo(s.LastName) < 0
                   select s;
        }

        public static IEnumerable<Student> Age(List<Student> students, int fromAge, int to)
        {
            //return students.Where((s) => s.Age >= fromAge && s.Age <= to);
            return from s in students
                   where s.Age >= fromAge
                   where s.Age <= to
                   select s;
        }

        public static IEnumerable<Student> Sort(List<Student> students)
        {
            //   return students.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);
            return from s in students
                   orderby s.FirstName
                   orderby s.LastName, s.LastName
                   select s;
        }

        public static IEnumerable<Student> EmailDomainFilter(List<Student> students, string emailDomain)
        {
            //return students.Where(s => s.Email.EndsWith(emailDomain));
            return from s in students
                   where s.Email.EndsWith(emailDomain)
                   select s;
        }

        public static IEnumerable<Student> PhoneFilter(List<Student> students, List<string> numberStartsWith)
        {
            /* return students.Where(s =>
             {
                 foreach (var item in numberStartsWith)
                 {
                     if (s.Phone.StartsWith(item))
                     {
                         return true;
                     }
                 }
                 return false;
             });*/
            return from s in students
                   from num in numberStartsWith
                   where s.Phone.StartsWith(num)
                   select s;
        }

        public static IEnumerable<dynamic> FilterExcelentStudents(List<Student> students)
        {
            //return students.Where(s => s.Marks.Contains(6));
            return from s in students
                   where s.Marks.Contains(6)
                   select new { s.FirstName, s.Marks };
        }

        public static IEnumerable<Student> FilterWeakStudents(List<Student> students)
        {
            //return students.Where(s => s.Marks.Where(m => m == 2).Count() == 2);
            return from s in students
                   where s.Marks.Where(m => m == 2).Count() == 2
                   select s;
        }

        public static IEnumerable<int> FilterEntrolled(List<Student> students)
        {
            return students.Where(s => s.FacultyNumber[6] == '4' && s.FacultyNumber[5] == '1').SelectMany(s => s.Marks);
        }


        internal static void GroupStudents(List<Student> students)
        {
            //return students.GroupBy(s=>s.GroupName).Select;
            var grouped = from s in students
                          group s by s.GroupName into g
                          select new
                          {
                              Key = g.Key,
                              Value = g.ToList()
                          };

            foreach (var item in grouped)
            {
                Console.WriteLine("-------------" + item.Key + "---------");
                foreach (var student in item.Value)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
