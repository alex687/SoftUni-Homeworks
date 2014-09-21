namespace SULS.Students
{
    using System;

    abstract class Student : Person
    {
        private double avgGrade;

        public string Number { get; set; }
        public double AvgGrade 
        {
            get
            {
                return this.avgGrade;
            }
            set
            {
                if (value > 6D)
                {
                    throw new ArgumentException("Invalid Averege Grade");
                }
                this.avgGrade = value;
            }
        }

        public Student(string fName, string lName, double avgGrade, string number, int age = 0)
            :base(fName, lName, age)
        {
            this.Number = number;
            this.AvgGrade = avgGrade;
        }

    }
}
