namespace RestaurantManager.Models
{
    using Interfaces;

    public class Dessert : Meal, IDessert
    {
        private bool withSugar = true;

        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
        }
        
        public bool WithSugar
        {
            get
            {
                return this.withSugar;
            }
        }

        public void ToggleSugar()
        {
            this.withSugar = ! this.withSugar;
        }

        public override string ToString()
        {
            if (!this.withSugar)
            {
                return "[NO SUGAR] " + base.ToString();
            }

            return base.ToString();
        }
    }
}
