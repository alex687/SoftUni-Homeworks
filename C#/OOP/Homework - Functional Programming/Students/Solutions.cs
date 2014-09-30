namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Solutions
    {
        public static IEnumerable<Student> FirstNameBeforeLastName(List<Student> students)
        {
            // return students.Where((s) => s.FirstName.CompareTo(s.LastName) < 0);
            return from s in students
                   where s.FirstName.CompareTo(s.LastName) < 0
                   select s;
        }

        public static IEnumerable<Student> Age(List<Student> students, int fromAge, int to)
        {
            // return students.Where((s) => s.Age >= fromAge && s.Age <= to);
            return from s in students
                   where s.Age >= fromAge
                   where s.Age <= to
                   select s;
        }

        public static IEnumerable<Student> Sort(List<Student> students)
        {
            // return students.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);
            return from s in students
                   orderby s.FirstName
                   orderby s.LastName, s.LastName
                   select s;
        }

        public static IEnumerable<Student> EmailDomainFilter(List<Student> students, string emailDomain)
        {
            // return students.Where(s => s.Email.EndsWith(emailDomain));
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
            // return students.Where(s => s.Marks.Contains(6));
            return from s in students
                   where s.Marks.Contains(6)
                   select new { s.FirstName, s.Marks };
        }

        public static IEnumerable<Student> FilterWeakStudents(List<Student> students)
        {
            // return students.Where(s => s.Marks.Where(m => m == 2).Count() == 2);
            return from s in students
                   where s.Marks.Where(m => m == 2).Count() == 2
                   select s;
        }

        public static IEnumerable<int> FilterEntrolled(List<Student> students)
        {
            return students.Where(s => s.FacultyNumber[6] == '4' && s.FacultyNumber[5] == '1').SelectMany(s => s.Marks);
        }

        public static void GroupStudents(List<Student> students)
        {
            // return students.GroupBy(s=>s.GroupName).Select;
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

        public static void JoinStudentsWithSpecialties(List<Student> students, List<StudentSpecialty> specialties)
        {
            var studentSpecialty = from st in students
                   join sp in specialties
                   on st.FacultyNumber equals sp.FacultyNumber
                   orderby st.FirstName
                   select new
                   {
                       FullName = st.FirstName + " " + st.LastName,
                       FacNum = st.FacultyNumber,
                       Specialty = sp.SpecialtyName
                   };

            foreach (var item in studentSpecialty)
            {
                Console.WriteLine("{0,-20} - {1,-20} - {2}", item.FullName, item.Specialty, item.FacNum);
            }
        }

        public static IEnumerable<Student> GetByGroup(List<Student> students)
        {
            return from s in students
                   where s.GroupNumber == 2
                   select s;
        }
    }
}
