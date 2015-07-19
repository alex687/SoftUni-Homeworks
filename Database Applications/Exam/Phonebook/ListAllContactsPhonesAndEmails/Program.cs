namespace ListAllContactsPhonesAndEmails
{
    using System;
    using System.Data.Entity;

    using ListAllContactsPhonesAndEmails.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new PhonebookContext();

            var contacts = context.Contacts.Include("Emails").Include("Phones");

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Name);
                foreach (var email in contact.Emails)
                {
                    Console.WriteLine("  " + email.EmailAddress);
                }

                foreach (var phone in contact.Phones)
                {
                    Console.WriteLine("  " + phone.PhoneNumber);
                }
            }
        }
    }
}
