namespace SULS
{
    using System;
    using System.Text;
    
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Person(string firstName, string lastName, int age)
            : this(firstName, lastName)
        {
            this.Age = age;
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
                    throw new ArgumentNullException();
                }
            
                this.firstName = value;
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
                    throw new ArgumentNullException();
                }

                this.lastName = value;
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
                if (value < 0 || value > 150)
                {
                    throw new ArgumentNullException("Invalid Age;");
                }
            
                this.age = value;
            }
        }

        public override string ToString()
        {
            var properties = this.GetType().GetProperties();
            StringBuilder propertiesStr = new StringBuilder();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this);
                if (propertyValue != null)
                {
                    propertiesStr.Append(property.Name + ": " + property.GetValue(this) + "\r\n");
                }
            }

            return propertiesStr.ToString();
        }
    }
}