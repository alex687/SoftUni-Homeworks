namespace ImportContactsJson
{
    using System.Collections.Generic;

    public class ContactDTO
    {
        public ContactDTO()
        {
            this.Emails = new List<string>();
            
            this.Phones = new List<string>();
        }

        public string Name { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public virtual ICollection<string> Emails { get; set; }

        public virtual ICollection<string> Phones { get; set; }

        public string Site { get; set; }

        public string Notes { get; set; } 
    }
}