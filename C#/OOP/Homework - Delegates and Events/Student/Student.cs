namespace Student
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        
        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Student(string firstName, string lastName, int age)
            : this(firstName, lastName)
        {
            this.age = age;
        }

        public delegate void PropertyChangedEventHandler<T>(object sender, PropertyChangedEventArgs<T> eventArgs);

        public event PropertyChangedEventHandler<dynamic> PropertyChanged;

        
        public string FirstName 
        {
            get
            {
                return this.firstName;
            }

            set
            {
                var oldValue = this.firstName;
                this.firstName = value;
                this.OnPropertyChange<string>("FirstName", oldValue, value);
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
                var oldValue = this.lastName;
                this.lastName = value;
                this.OnPropertyChange<string>("LastName", oldValue, value);
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
                var oldValue = this.age;
                this.age = value;
                this.OnPropertyChange<int>("Age", oldValue, value);
            }
        }

        protected void OnPropertyChange<T>(string propName, T oldValue, T newValue)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChangedEventArgs<dynamic> args = new PropertyChangedEventArgs<dynamic>(propName, oldValue, newValue);
                this.PropertyChanged(this, args);
            }
        }
    }
}
