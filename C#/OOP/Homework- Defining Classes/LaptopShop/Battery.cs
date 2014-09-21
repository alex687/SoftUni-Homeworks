namespace LaptopShop
{
    using System;

    public class Battery
    {
        public Battery(double life)
        {
            if (life < 0)
            {
                throw new ArgumentException("Battery life lower than 0");
            }
        
            this.Life = life;
        }

        public Battery(double life, string name)
            : this(life)
        {
            this.Name = name;
        }

        public double Life { get; private set; }
       
        public string Name { get; private set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name + " " + this.Life + " hours";
            }

            return this.Life.ToString() + " hours";
        }
    }
}
