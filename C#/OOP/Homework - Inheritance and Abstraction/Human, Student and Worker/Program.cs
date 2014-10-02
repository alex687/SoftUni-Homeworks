namespace HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var pesho = new Student("pesho", "petrov", "20144567");
            var gosho = new Student("gosho", "georgiev", "20141730");
            var misho = new Student("misho", "mishev", "20142589");
            var ganka = new Student("ganka", "gancheva", "20146547");
            var sanya = new Student("sanya", "mincheva", "20145285");
            var ivan = new Student("ivan", "ivanov", "20145687");
            var dimitar = new Student("dimitar", "dimitrov", "20143698");
            var damyan = new Student("damyan", "damyanov", "20149634");
            var mihail = new Student("mihail", "petrov", "20147415");

            var doncho = new Student("doncho", "donchev", "20145612");

            var students = new List<Student>()
            {
                pesho,
                gosho,
                misho,
                ganka,
                sanya,
                ivan,
                dimitar, 
                damyan,
                mihail,
                doncho
            };

            Console.WriteLine("Sorted Students:");
            var sortedStudents = students.OrderBy(st => st.FacultyNumber);
            foreach (var stud in sortedStudents)
            {
                Console.WriteLine("{0} {1} - {2}", stud.FirstName, stud.LastName, stud.FacultyNumber);
            }

            var kosta = new Worker("kosta", "kostadinov", 282m, 8f);
            var sancho = new Worker("sancho", "pansa", 382m, 6.5f);
            var penka = new Worker("penka", "kostadinova", 243m, 4.75f);
            var dimitrichka = new Worker("dimitrichka", "doynova", 152m, 2.75f);
            var darina = new Worker("darina", "stamatova", 182m, 5.5f);
            var zlatomir = new Worker("zlatomir", "zlatev", 242m, 7.5f);
            var petar = new Worker("petar", "donchev", 482m, 6f);
            var pencho = new Worker("pencho", "kubadinski", 578m, 9f);
            var marko = new Worker("marko", "totev", 439m, 8f);
            var kostadin = new Worker("kostadin", "haralambov", 658m, 9f);

           var workers = new List<Worker>()
            {
                kosta,
                sancho,
                penka,
                dimitrichka,
                darina,
                zlatomir,
                petar,
                pencho,
                marko,
                kostadin
            };

            Console.WriteLine("\nSorted Workers: ");
            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour(5));
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0} {1} - {2:N2}", worker.FirstName, worker.LastName, worker.MoneyPerHour(5));
            }

            Console.WriteLine("\nSorted Humans: ");
            var humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            var sortedHumans = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
            foreach (var human in sortedHumans)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }
    }
}
