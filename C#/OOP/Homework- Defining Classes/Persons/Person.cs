namespace Persons
{
    using System;
    using System.Linq;

    public class Person
    {
        private string name;
        private int age;
        private string email;
        private string p1;
        private int p2;
        
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, int age)
            : this(name, age, null)
        {
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
                    throw new ArgumentNullException("Name must not be empty");
                }

                this.name = value;
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
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("The age must be between 1 and 100");
                }

                this.age = value;
            }
        }

        public string Email 
        {
            get
            {
                return this.email;
            }

            set
            {
                if (value != null && !value.Contains('@'))
                {
                    throw new ArgumentException("Invalid email");
                }

                this.email = value;
            }
        }

        public override string ToString()
        {
            return "{Name:" + this.Name + " Age:" + this.Age + "}";
        }
    }
}
