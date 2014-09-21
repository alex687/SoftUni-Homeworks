namespace PC_Catalogue
{
    using System;
    
    public class Component
    {
        public Component(string name, double price, string details = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Empty name");
            }

            if (price < 0)
            {
                throw new ArgumentException("Invalid price");
            }

            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public string Name { get; private set; }

        public double Price { get; private set; }
        
        public string Details { get; private set; }
    }
}
