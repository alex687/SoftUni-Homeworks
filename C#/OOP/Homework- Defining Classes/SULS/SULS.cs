namespace SULS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Students;
    using Trainers;

    public class SULS
    {
        public static void Main(string[] args)
        {

            Trainer nakov = new SeniorTrainer("Svetlin", "Nakov");
            Student mashina = new GraduateStudent("Boiko", "Borisov", "80002341", 6.00, 34);
            Student bot = new DropoutStudent("Bot", "Student", "400235678", 2.33, "Bot e");

            CurrentStudent letec = new OnlineStudent("Letec", "Letqsht", "50006541", 3.45, "OOP");
            CurrentStudent rita = new OnlineStudent("Rita", "Topka", "50002389", 4.45, "OOP");
            CurrentStudent batkata = new OnsiteStudent("Liubo", "Penev", "50009841", 5.85, "OOP",5);

            List<Person> persons = new List<Person>() { nakov, mashina, bot, letec, rita, batkata};
            persons.Where(p => p is CurrentStudent).OrderBy(p => ((Student)p).AvgGrade).ToList().ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
