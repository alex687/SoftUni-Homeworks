namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private IList<IRecipe> recipies;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.recipies = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Name is required.");
                }

                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Location is required.");
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get
            {
                return new List<IRecipe>(this.recipies);
            }
        }

        public void AddRecipe(IRecipe recipe)
        {
            this.recipies.Add(recipe);
        }

        public void RemoveRecipe(Interfaces.IRecipe recipe)
        {
            this.recipies.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("***** " + this.name + " - " + this.location + " *****");
            if (this.recipies.Count == 0)
            {
                str.AppendLine("No recipes... yet");
            }
            else
            {
                var categories = new Dictionary<string, List<IRecipe>>();

                categories.Add("DRINKS", this.recipies.Where(r => r is Drink).OrderBy(r => r.Name).ToList());
                categories.Add("SALADS", this.recipies.Where(r => r is Salad).OrderBy(r => r.Name).ToList());
                categories.Add("MAIN COURSES", this.recipies.Where(r => r is MainCourse).OrderBy(r => r.Name).ToList());
                categories.Add("DESSERTS", this.recipies.Where(r => r is Dessert).OrderBy(r => r.Name).ToList());

                foreach (var category in categories)
                {
                    if (category.Value.Count > 0)
                    {
                        str.AppendLine("~~~~~ " + category.Key + " ~~~~~");
                        foreach (var recipy in category.Value)
                        {
                            str.Append(recipy);
                        }
                    }
                }
            }

            return str.ToString().Trim();
        }
    }
}
