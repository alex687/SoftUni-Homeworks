namespace RestaurantManager.Models
{
    using System;

    using Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        private MainCourseType type;

        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.type = type;
        }
 
        public MainCourseType Type
        {
            get
            {
                return this.type;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Type: " + this.type.ToString()+ Environment.NewLine;
        }
    }
}
