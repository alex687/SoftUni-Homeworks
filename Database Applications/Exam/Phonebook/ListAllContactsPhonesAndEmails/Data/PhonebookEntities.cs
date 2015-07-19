namespace ListAllContactsPhonesAndEmails.Data
{
    using System.Data.Entity;

    using ListAllContactsPhonesAndEmails.Migrations;
    using ListAllContactsPhonesAndEmails.Models;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            :base("Phonebook")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());
  
        }

        public IDbSet<Contact> Contacts { get; set; }
        
        public IDbSet<Email> Emails { get; set; }

        public IDbSet<Phone> Phones { get; set; }

    }
}
