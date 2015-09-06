namespace PersonsCollection
{
    public class Person
    {
        public Person(string email, string name, int age, town)
        {
            
        }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public override int GetHashCode()
        {
            return this.Email.GetHashCode();
        }
    }
}
