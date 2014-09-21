namespace SULS.Trainers
{
    using System;

    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string fName, string lName, int age = 0)
            : base(fName, lName, age)
        {
        }

        public static void DeleteCourse(string name)
        {
            Console.WriteLine("The course has been deleted");
        }
    }
}
