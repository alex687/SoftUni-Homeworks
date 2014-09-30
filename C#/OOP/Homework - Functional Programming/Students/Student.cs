namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        private string groupName;
        private IList<int> marks;
        private string firstName;
        private string facultyNumber;
        private string email;
        private string phone;
        private int age;
        private string lastName;

        public Student(string firstName, string lastName, string facultyNumber, string phoneNumber, string email, IList<int> marks, int age, string groupName, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
            this.Phone = phoneNumber;
            this.Email = email;
            this.Marks = marks;
            this.Age = age;
            this.GroupName = groupName;
            this.GroupNumber = groupNumber;
        }

        public string GroupName
        {
            get
            {
                return this.groupName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("GroupName", "GroupName can not be null or empty!");
                }

                this.groupName = value;
            }
        }

        public IList<int> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Marks", "Marks list can not be null!");
                }

                this.marks = value;
            }
        }

        public int GroupNumber { get; set; }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email", "Email can not be null or empty!");
                }

                this.email = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Phone", "Phone can not be null or empty!");
                }


                this.phone = value;
            }
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FacultyNumber", "Faculty Number can not be null or empty!");
                }

                this.facultyNumber = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age can not be negative!");
                }

                this.age = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "Last Name can not be null or empty!");
                }

                this.lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName", "First Name can not be null or empty!");
                }

                this.firstName = value;
            }
        }


        public override string ToString()
        {
            var properties = this.GetType().GetProperties();
            var propertiesStr = new StringBuilder();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this);
                if (propertyValue is List<int>)
                {
                    var grades = ((List<int>)propertyValue).ToArray();
                    propertyValue = string.Join(",", grades);
                }

                if (propertyValue != null)
                {
                    propertiesStr.Append(property.Name + ": " + propertyValue + "\r\n");
                }
            }

            return propertiesStr.ToString();
        }
    }
}
