namespace School
{
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var pesho = new Student("Pesho", "201411V21", "very tallented, self-critical");
            var misho = new Student("Misho", "201411V13");

            // Student gatyo = new Student("Gosho", "201411V13"); // should throw exception
            var gosho = new Student("Gosho", "201412V13");
            var katya = new Student("Katya", "201412V19", "likes litterature, expecially indian novels of Karl May");

            var maths = new Discipline("Mathematics", 35, new List<Student>() { pesho, gosho, misho });
            var litterature = new Discipline("Litterature", 15, new List<Student>() { gosho, misho, katya }, "optional");
            var informatics = new Discipline("Informatics", 50, new List<Student>() { pesho, gosho, katya, misho }, "main discipline");

            var peshova = new Teacher("Peshova", new List<Discipline>() { litterature });
            var dushkov = new Teacher("Dushkov", new List<Discipline>() { maths, informatics });

            var class201411V = new Class("201411V", new List<Student>() { pesho, misho }, new List<Teacher>() { peshova });

            // below row should throw exception
            // SchoolClass class201412 = new Class("201411V", new List<Student>() { }, new List<Teacher>() { peshova, dushkov });
            var class201412V = new Class("201412V", new List<Student>() { }, new List<Teacher>() { peshova, dushkov });

            var eg = new School(new List<Class>() { class201411V, class201412V });
        }
    }
}
