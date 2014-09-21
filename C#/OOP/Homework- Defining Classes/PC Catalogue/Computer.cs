namespace PC_Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer : IComparable<Computer>
    {
        private List<Component> components;
        
        public Computer(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
            this.Price = 0;
        }

        public Computer(string name, List<Component> components)
            : this(name)
        {
            this.components = components;
            this.Price = components.Sum(component => component.Price);
        }

        public string Name { get; private set; }
        
        public double Price { get; private set; }
        
        public Component[] Components
        {
            get
            {
                return this.components.ToArray();
            }
        }

        public void Print()
        {
            Console.WriteLine(this.Name);
            foreach (var component in this.components)
            {
                Console.WriteLine("{0},{1}", component.Name, component.Price);
            }

            Console.WriteLine("Total:{0}", this.Price);
        }

        public void AddComponent(Component component)
        {
            this.components.Add(component);
            this.Price += component.Price;
        }

        public int CompareTo(Computer other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
