namespace Student
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Student student = new Student("Peter", "PePo", 15);
            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };
            student.FirstName = "Maria";
            student.Age = 19;
        }
    }
}
