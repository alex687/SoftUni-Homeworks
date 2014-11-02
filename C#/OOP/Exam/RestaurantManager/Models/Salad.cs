namespace RestaurantManager.Models
{
    using System;

    using Interfaces;

    public class Salad : Meal, ISalad
    {
        private bool containsPasta = false;

        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, true)
        {
            this.containsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get
            {
                return this.containsPasta;
            }
        }

        public override void ToggleVegan()
        {
            throw new InvalidOperationException("Salads must be always vegan");
        }

        public override string ToString()
        {
            var containsPastaStr = this.containsPasta ? "yes" : "no";
            return base.ToString() + "Contains pasta: " + containsPastaStr+ Environment.NewLine;
        }
    }
}
