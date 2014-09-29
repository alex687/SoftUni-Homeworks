using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Students
{
    public class Student
    {
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

        public string FirstName { get; private set; }
        
        public string LastName { get; private set; }

        public string FacultyNumber { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public IList<int> Marks { get; private set; }

        public int Age { get; private set; }

        public string GroupName { get; private set; }

        public int GroupNumber { get; private set; }

        public override string ToString()
        {
            var properties = this.GetType().GetProperties();
            StringBuilder propertiesStr = new StringBuilder();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this);
                if (propertyValue is List<int>)
                {
                    propertiesStr.Append((property.Name + ": " + string.Join(",", ((List<int>)propertyValue).ToArray()) + "\r\n"));
                }
                else
                if (propertyValue != null)
                {
                    propertiesStr.Append(property.Name + ": " + property.GetValue(this) + "\r\n");
                }
            }

            return propertiesStr.ToString();
        }
    }
}
