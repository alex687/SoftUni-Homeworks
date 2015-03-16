namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            var studentDb = new StudentSystemData();

            var newResource = new Resource { Link = "www.abv.bg", Name = "Email", Type = ResourceType.Other };
            studentDb.Resources.Add(newResource);

            Student student = new Student
            {
                FirstName = "Ta Pepelqqq",
                LastName = "Ne vyrvi",
                Birthday = new DateTime(1825, 02, 02),
                PhoneNumber = "123469899"
            };
            studentDb.Students.Add(student);

            Course course = new Course { Description = "Za Strugari", Name = "Strug mania", Price = 1.1M, EndDate = new DateTime(2016, 12, 1), StartDate = DateTime.Now };
            course.Resources.Add(newResource);
            studentDb.Courses.Add(course);

            studentDb.SaveChanges();

            var studentsHomeworks = GetStudentsWithHomeworks(studentDb);
            foreach (var studentHomeworks in studentsHomeworks)
            {
                Console.WriteLine(studentHomeworks.FirstName + " " + studentHomeworks.LastName);

                var homeworks = studentHomeworks.Homeworks;
                foreach (var homework in homeworks)
                {
                    Console.WriteLine(" " + homework.CourseName + "-" + homework.SentOn.Date);
                }

                Console.WriteLine();
            }


            var coursesWithResources = GetCoursesWithResources(studentDb);
            foreach (var courseWithResources in coursesWithResources)
            {
                Console.WriteLine(courseWithResources.Name);

                var resources = courseWithResources.Resources;
                foreach (var resource in resources)
                {
                    Console.WriteLine(" " + resource.Name + "-" + resource.Link);
                }

                Console.WriteLine();
            }
        }

        private static IEnumerable<dynamic> GetStudentsWithHomeworks(StudentSystemData studentDb)
        {
            var studentsHomeworks =
                studentDb.Students.All()
                    .Select(
                        s =>
                        new
                            {
                                s.FirstName,
                                s.LastName,
                               Homeworks = s.Homeworks.Select(h => new { CourseName = h.Course.Name, h.SentOn })
                            });


            return studentsHomeworks.ToList();
        }

        private static List<Course> GetCoursesWithResources(StudentSystemData studentDb)
        {
            var coursesResources = studentDb.Courses.All().Include(s => s.Resources);

            return coursesResources.ToList();
        }
    }
}
