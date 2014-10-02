namespace School
{
    using System;
    using System.Collections.Generic;

    public class Student : Person
    {
        private static IList<string> takenClassNumbers = new List<string>();
        private string classNumber;

        public Student(string name, string classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public Student(string name, string classNumber, string details)
            : this(name, classNumber)
        {
            this.Details = details;
        }

        public string ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            set
            {
                if (Student.takenClassNumbers.Contains(value))
                {
                    throw new ArgumentException("Id already exists");
                }

                this.classNumber = value;
                takenClassNumbers.Add(value);
            }
        }
    }
}
