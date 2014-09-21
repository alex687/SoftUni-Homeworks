namespace SULS.Students
{
    using System;

    class DropoutStudent : Student
    {
        public string Reason { get; set; }

        public DropoutStudent(string fName, string lName, string number, double avgGrade, string reason, int age = 0)
            : base(fName, lName, avgGrade, number, age)
        {
            this.Reason = reason;
        }

        public void Reaply()
        {
            Console.WriteLine(this.FirstName+ " "+ this.LastName +" "+ this.Number );
            Console.WriteLine(this.Reason);
        }
    }
}
