using System.Collections.Generic;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            Student pesho = new Student("Pesho", "201411V21", "very tallented, self-critical");
            Student misho = new Student("Misho", "201411V13");

            // Student gatyo = new Student("Gosho", "201411V13"); // should throw exception
            Student gosho = new Student("Gosho", "201412V13");
            Student katya = new Student("Katya", "201412V19", "likes litterature, expecially indian novels of Karl May");

            Discipline maths = new Discipline("Mathematics", 35, new List<Student>() { pesho, gosho, misho });
            Discipline litterature = new Discipline("Litterature", 15, new List<Student>() { gosho, misho, katya }, "optional");
            Discipline informatics = new Discipline("Informatics",50, new List<Student>() { pesho, gosho, katya, misho },  "main discipline");

            Teacher peshova = new Teacher("Peshova", new List<Discipline>() { litterature });
            Teacher dushkov = new Teacher("Dushkov", new List<Discipline>() { maths, informatics });

            var class201411V = new Class("201411V", new List<Student>() { pesho, misho }, new List<Teacher>() { peshova });

            // below row should throw exception
            // SchoolClass class201412 = new Class("201411V", new List<Student>() { }, new List<Teacher>() { peshova, dushkov });
            var class201412V = new Class("201412V", new List<Student>() { }, new List<Teacher>() { peshova, dushkov });

            School eg = new School(new List<Class>() { class201411V, class201412V });
        }
    }
}
