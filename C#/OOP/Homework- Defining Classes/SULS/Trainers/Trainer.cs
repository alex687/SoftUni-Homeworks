namespace SULS.Trainers
{
    using System;

    abstract class Trainer : Person
    {
        public void CreateCourse(string courseName)
        {
            Console.WriteLine("The course has been created");
        }

        public Trainer(string fName, string lName, int age = 0)
            : base(fName, lName, age)
        {
        }
    }
}
