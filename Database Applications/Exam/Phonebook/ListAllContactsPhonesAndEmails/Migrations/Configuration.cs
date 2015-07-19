namespace ListAllContactsPhonesAndEmails.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ListAllContactsPhonesAndEmails.Data;
    using ListAllContactsPhonesAndEmails.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookContext context)
        {

            if (context.Contacts.Any())
            {
                return;
            }


            var peter = new Contact() { Company = "Smart Ideas", Position = "CTO", Name = "Peter Ivanov", Site = "http://blog.peter.com", Notes = " Friend from school" };
            
            var peterPhones = new List<Phone>();
            peterPhones.Add(new Phone() { PhoneNumber = "+359 2 22 22 22" });
            peterPhones.Add(new Phone() { PhoneNumber = "+359 88 77 88 99" });

            var peterEmails = new List<Email>();
            peterEmails.Add(new Email() { EmailAddress = "peter@gmail.com" });
            peterEmails.Add(new Email() { EmailAddress = " peter_ivanov@yahoo.com" });
            peter.Phones = peterPhones;
            peter.Emails = peterEmails;

            var maria = new Contact() {Name = "Maria" };
            
            var mariaPhones = new List<Phone>();
            mariaPhones.Add(new Phone() { PhoneNumber = "+359 22 33 44 55" });
            maria.Phones = mariaPhones;


            var angie = new Contact() { Name = "Angie Stanton", Site = "http://angiestanton.com"};
            var angieEmails = new List<Email>();
            angieEmails.Add(new Email() { EmailAddress = "info@angiestanton.com" });
            angie.Emails = angieEmails;

            context.Contacts.Add(peter);
            context.Contacts.Add(maria);
            context.Contacts.Add(angie);

            base.Seed(context);
        }
    }
}
