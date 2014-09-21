namespace LaptopShop
{
    using System;
    using System.Text;

    public class Laptop : SellItem
    {
        public Laptop(string model, double price)
        {
            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentNullException("Empty String");
            }

            if (price < 0)
            {
                throw new ArgumentException("Price lower than 0");
            }

            this.Model = model;
            this.Price = price;
        }

        public Laptop(string man, string model, double price, string cpu, string gpu, string ram, string hdd, string screen, Battery battery)
            : this(model, price)
        {
            if (string.IsNullOrEmpty(cpu) || string.IsNullOrEmpty(gpu) || string.IsNullOrEmpty(man)
                || string.IsNullOrEmpty(hdd) || string.IsNullOrEmpty(ram))
            {
                throw new ArgumentNullException("Empty String");
            }

            this.Manufacturer = man;
            this.Battery = battery;
            this.Processor = cpu;
            this.GraphicsCard = gpu;
            this.Screen = screen;
            this.RAM = ram;
            this.HDD = hdd;
        }

        public string Processor { get; private set; }
        
        public string GraphicsCard { get; private set; }
        
        public string RAM { get; private set; }
        
        public string HDD { get; private set; }
        
        public string Screen { get; private set; }

        public Battery Battery { get; private set; }

        public override string ToString()
        {
            var properties = this.GetType().GetProperties();
            StringBuilder propertiesStr = new StringBuilder();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this);
                if (propertyValue != null)
                {
                    propertiesStr.Append(property.Name + ": " + property.GetValue(this) + "\r\n");
                }
            }

            return propertiesStr.ToString();
        }
    }
}
