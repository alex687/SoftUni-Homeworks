namespace School
{
    using System;

    public class Person
    {
        private string name;
        private string details;

        public Person(string name)
        {
            this.Name = name;
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
    }
}
