using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportContactsJson
{
    using System.IO;

    using ListAllContactsPhonesAndEmails.Data;
    using ListAllContactsPhonesAndEmails.Models;

    using Newtonsoft.Json;

    public class Program
    {
        public static void Main(string[] args)
        {
            var json = File.ReadAllText("../../contacts.json");
            var contactsDto = JsonConvert.DeserializeObject<List<ContactDTO>>(json);
            var context = new PhonebookContext();

            foreach (var contactDto in contactsDto)
            {
                try
                {
                    var contact = new Contact();
                    if (contactDto.Name != null)
                    {
                        contact.Name = contactDto.Name;
                    }
                    else
                    {
                        contact.Name = contactDto.FirstName + " " + contactDto.LastName;
                    }

                    if (string.IsNullOrWhiteSpace(contact.Name))
                    {
                        throw new Exception("Name is required");
                    }

                    contact.Notes = contactDto.Notes;
                    contact.Position = contactDto.Position;
                    contact.Company = contactDto.Company;
                    contact.Site = contactDto.Site;

                    var emails = new List<Email>();
                    foreach (var email in contactDto.Emails)
                    {
                        emails.Add(new Email() { EmailAddress = email });
                    }


                    var phones = new List<Phone>();
                    foreach (var phone in contactDto.Phones)
                    {
                        phones.Add(new Phone() { PhoneNumber = phone });
                    }

                    contact.Phones = phones;
                    contact.Emails = emails;

                    context.Contacts.Add(contact);
                    context.SaveChanges();
                    Console.WriteLine("Contact {0} imported", contact.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
