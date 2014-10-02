namespace School
{
    using System;
    using System.Collections.Generic;

    public class Discipline
    {
        private int numberOfLectures = 0;
        private ICollection<Student> students;
        private string name;
        private string details;

        public Discipline(string name, int numberOfLectures, IList<Student> students)
        {
            this.NumberOfLectures = numberOfLectures;
            this.Students = students;
        }

        public Discipline(string name, int numberOfLectures, IList<Student> students, string details)
            : this(name, numberOfLectures, students)
        {
            this.Details = details;
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid number of lectures");
                }

                this.numberOfLectures = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("Students cannot be null or 0");
                }

                this.students = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Empty name");
                }

                this.name = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Empty details");
                }

                this.details = value;
            }
        }
    }
}
