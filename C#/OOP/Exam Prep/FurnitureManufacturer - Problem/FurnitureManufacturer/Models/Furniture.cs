namespace FurnitureManufacturer.Models
{
    using System;
   
    using Interfaces;

   public class Furniture : IFurniture
   {
       private const int ModelMinLength = 3;
       private const decimal PriceMin = 0M;
       private const decimal HeightMin = 0M;

        private string model;
        private MaterialType material;
        private decimal price;
        private decimal height;

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.material = materialType;
            this.height = height;
        }

        public string Model
        {
            get 
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model is empty");
                }

                if (value.Length < ModelMinLength)
                {
                    throw new ArgumentOutOfRangeException("Model must be at least " + ModelMinLength + " characters long");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get 
            {
                return this.material.ToString();
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= PriceMin)
                {
                    throw new ArgumentException("Price cannot be " + PriceMin + " or less");
                }

                this.price = value;
             }
        }

        public decimal Height
        {
            get 
            {
                return this.height;
            }

            set
            {
                if (value <= 0M)
                {
                    throw new ArgumentException("Height cannot be " + HeightMin + " or less");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
           return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
