namespace School
{
    using System;
    using System.Collections.Generic;

    public class Class
    {
        private static ICollection<string> uniqueIds;

        private string uniqueId;
        private ICollection<Teacher> teachers;
        private ICollection<Student> students;
        private string details;

        static Class()
        {
            Class.uniqueIds = new List<string>();
        }

        public Class(string uniqueId, ICollection<Student> students, ICollection<Teacher> teachers)
        {
            this.UniqueId = uniqueId;
            this.Teachers = teachers;
            this.Students = students;
            Class.uniqueIds.Add(uniqueId);
        }

        public string UniqueId
        {
            get
            {
                return this.uniqueId;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("UniqueId", "UniqueId can not be null or empty!");
                }

                if (uniqueIds.Contains(value))
                {
                    throw new ArgumentException("There is another class with this identification!");
                }

                this.uniqueId = value;
            }
        }

        public ICollection<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }

            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Teachers", "Teachers can not be null");
                }

                this.teachers = value;
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
                if (null == value)
                {
                    throw new ArgumentNullException("Students", "Students can not be null");
                }

                this.students = value;
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
