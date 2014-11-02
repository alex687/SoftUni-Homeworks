namespace RestaurantManager.Models
{
    using System;

    using Interfaces;

    public class Drink : Recipe, IDrink
    {
        private bool isCarbonated = false;

        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.isCarbonated = isCarbonated;
            this.Unit = MetricUnit.Milliliters;
        }

        public bool IsCarbonated
        {
            get
            {
                return this.isCarbonated;
            }
        }

        public override int Calories
        {
            get
            {
                return base.Calories;
            }

            protected set
            {
                if (value > 100)
                {
                    throw new ArgumentException("Calories cannot be > 100");
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }

            protected set
            {
                if (value > 20)
                {
                    throw new ArgumentException("Time to prepare cannot be > 20");
                }

                base.TimeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var isCarbonatedStr = this.isCarbonated ? "yes" : "no";
            return base.ToString() + "Carbonated: " + isCarbonatedStr + Environment.NewLine;
        }
    }
}
