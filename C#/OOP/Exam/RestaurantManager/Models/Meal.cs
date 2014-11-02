namespace RestaurantManager.Models
{
    using System.Text;

    using Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        private bool isVegan = false;

        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan = false)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.Unit = MetricUnit.Grams;
            this.isVegan = isVegan;
        }

        public bool IsVegan
        {
            get
            {
                return this.isVegan;             
            }
        }

        public virtual void ToggleVegan()
        {
            this.isVegan = ! this.isVegan;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            
            if (this.IsVegan)
            {
                str.Append("[VEGAN] ");
            }

            str.Append(base.ToString());

            return str.ToString();
        }
    }
}
