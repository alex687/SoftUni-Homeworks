namespace School
{
    using System;
    using System.Collections.Generic;

    public class Discipline : NamebleAndDetailsEntity
    {
        private int numberOfLectures = 0;
        private ICollection<Student> students;

        public Discipline(string name, int numberOfLectures, IList<Student> students)
            : base(name)
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
    }
}
