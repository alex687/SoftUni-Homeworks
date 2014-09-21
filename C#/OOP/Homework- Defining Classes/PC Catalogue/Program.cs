namespace PC_Catalogue
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Component> components = new List<Component>();
            components.Add(new Component("HDD", 120));
            components.Add(new Component("RAM", 140));

            Computer firstPc = new Computer("HP", components);

            Computer secondPc = new Computer("DELL");
            secondPc.AddComponent(new Component("CPU", 500));
            secondPc.AddComponent(new Component("GPU", 1000));
            
            List<Computer> computers = new List<Computer>();
            computers.Add(firstPc);
            computers.Add(secondPc);

            computers.Sort();

            foreach (var item in computers)
            {
                item.Print();
                Console.WriteLine();
            }
        }
    }
}
