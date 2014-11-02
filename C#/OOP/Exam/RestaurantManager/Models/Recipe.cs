namespace RestaurantManager.Models
{
    using System;
    using System.Text;

    using Interfaces;

    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private MetricUnit unit;
        private int timeToPrepare;

        protected Recipe(string name)
        {
            this.Name = name;       
        }

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
            : this(name)
        {
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Name is required.");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The Price must be positive.");
                }

                this.price = value;
            }
        }

        public virtual  int Calories
        {
            get
            {
                return this.calories;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The Calories must be positive.");
                }

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }


            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The QuantityPerServing must be positive.");
                }

                this.quantityPerServing = value;
            }
        }

        public MetricUnit Unit
        {
            get
            {
                return this.unit;
            }

            protected set
            {
                this.unit = value;
            }
        }

        public virtual int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The TimeToPrepare must be positive.");
                }

                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("==  " + this.Name + " == $" + this.Price);
            
            var unitStr = "g";
            if (this.Unit == MetricUnit.Milliliters)
            {
                unitStr = "ml";
            }

            str.AppendLine("Per serving: " + this.QuantityPerServing + " " + unitStr + ", " + this.Calories + " kcal");
            
            str.AppendLine("Ready in " + this.TimeToPrepare + " minutes");

            return str.ToString();
        }
    }
}
