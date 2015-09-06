using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private readonly Dictionary<string, Person> peopleByEmail;
    private readonly Dictionary<string, SortedSet<Person>> peopleByEmailDomain;
    private readonly Dictionary<string, SortedSet<Person>> peopleByNameAndTown;
    private readonly OrderedDictionary<int, SortedSet<Person>> peopleByAge;
    private readonly OrderedDictionary<int, Dictionary<string, SortedSet<Person>>> peopleByAgeTown;


    public PersonCollection()
    {
        this.peopleByEmail = new Dictionary<string, Person>();
        this.peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        this.peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
        
        this.peopleByAge = new OrderedDictionary<int, SortedSet<Person>> ();
        this.peopleByAgeTown = new OrderedDictionary<int, Dictionary<string, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        var person = new Person(email, name, age, town);
        try
        {
            this.peopleByEmail.Add(email, person);

            var domain = email.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries).Last();
            this.peopleByEmailDomain.AppendValueToKey(domain, person);

            this.peopleByNameAndTown.AppendValueToKey(name + town, person);
            this.peopleByAge.AppendValueToKey(age, person);


            this.peopleByAgeTown.EnsureKeyExists(age);
            this.peopleByAgeTown[age].AppendValueToKey(town, person);

            return true;
        }
        catch (ArgumentException e)
        {
            return false;
        }
    }

    public int Count
    {
        get
        {
            return this.peopleByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExists = this.peopleByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        if (person != null)
        {
            this.peopleByEmail.Remove(email);

            var domain = email.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries).Last();
            this.peopleByEmailDomain[domain].Remove(person);

            this.peopleByNameAndTown[person.Name + person.Town].Remove(person);

            this.peopleByAge[person.Age].Remove(person);
            this.peopleByAgeTown[person.Age][person.Town].Remove(person);

            return true;
        }

        return false;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (this.peopleByEmailDomain.ContainsKey(emailDomain))
        {
            return this.peopleByEmailDomain[emailDomain];
        }

        return new List<Person>();
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        if (this.peopleByNameAndTown.ContainsKey(name + town))
        {
            return this.peopleByNameAndTown[name + town];
        }

        return new List<Person>();
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        return this.peopleByAge.Range(startAge, true, endAge, true).SelectMany(personsByAge => personsByAge.Value);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        return this.peopleByAgeTown.Range(startAge, true, endAge, true).Where(result => result.Value.ContainsKey(town)).SelectMany(result => result.Value[town]);
    }
}
