using System.Collections.Generic;
using System.Text;
namespace Students
{
    public class Student
    {
        public Student(string firstName, string lastName, string facultyNumber, string phoneNumber, string email, IList<int> marks, int age, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
            this.Phone = phoneNumber;
            this.Email = email;
            this.Marks = marks;
            this.Age = age;
            this.GroupName = groupName;
        }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string FacultyNumber { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public IList<int> Marks { get; set; }

        public int Age { get; set; }

        public string GroupName  { get; set; }

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
