namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var phonebook = new Dictionary<string, string>();
            var isSearchingContacts = false;
            var contactsForSearch = new List<string>();
            while (input != null)
            {
                if (input == "search")
                {
                    isSearchingContacts = true;
                    input = Console.ReadLine();
                    continue;
                }

                if (!isSearchingContacts)
                {
                    PhoneRead(input, phonebook);
                }
                else
                {
                    contactsForSearch.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (var contactName in contactsForSearch)
            {
                if (phonebook.ContainsKey(contactName))
                {
                    Console.WriteLine("{0} -> {1}", contactName, phonebook[contactName]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exists.", contactName);
                }
            }
        }

        private static void PhoneRead(string input, Dictionary<string, string> phonebook)
        {

            string[] contact = input.Trim().Split('-');
            string name = contact[0].Trim();
            string phone = contact[1].Trim();

            if (phonebook.ContainsKey(name))
            {
                phonebook[name] = phone;
            }
            else
            {
                phonebook.Add(name, phone);
            }
        }
    }
}
