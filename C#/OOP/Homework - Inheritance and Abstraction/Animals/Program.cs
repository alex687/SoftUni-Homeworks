namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var jaba = new Frog("baba jaba", 1, Genders.Female);
            var kekerica = new Frog("kekerica", 3, Genders.Female);

            var sharo = new Dog("sharo", 3, Genders.Male);
            var sara = new Dog("sara", 2, Genders.Female);
            var oldy = new Dog("oldy", 12, Genders.Male);

            var puhi = new Kitten("puhi", 2);
            var tommy = new Tomcat("tommy", 4);
            var mouseKiller = new Cat("mousy", 5, Genders.Male);

            var animals = new List<Animal>()
            {
                jaba, 
                kekerica,
                sharo,
                sara,
                puhi,
                tommy,
                mouseKiller,
                oldy
            };
            
            var avredgeAgeOfKinds = from a in animals
                                    group a by a.GetType().Name into g
                                    select new { GroupName = g.Key, AverageAge = g.ToList().Average(an => an.Age) };
            foreach (var animal in avredgeAgeOfKinds)
            {
                Console.WriteLine("{0} - average age: {1:N2}", animal.GroupName, animal.AverageAge);
            }
        }
    }
}
