namespace StudentSystem.ConsoleClient
{
    using System;

    using StudentSystem.Data;
    using StudentSystem.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            var studentDb = new StudentSystemDbContext();

            var student = new Student()
                              {
                                  FirstName = "Pro",
                                  MiddleName = "Super",
                                  LastName = "Pro",
                                  //RegistrationDate = DateTom
                              };
            studentDb.Students.Add(student);
            studentDb.SaveChanges();

            var students = studentDb.Students;

            foreach (var student1 in students)
            {
                Console.WriteLine(student1.FirstName + " " + student1.LastName);
            }
        }
    }
}
