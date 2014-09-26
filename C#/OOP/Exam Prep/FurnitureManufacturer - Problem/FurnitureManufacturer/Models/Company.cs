namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Company : ICompany
    {
        private const int NameMinLength = 5;
        private const int RegNumberLength = 10;

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> catalogList;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.catalogList = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty or null");
                }

                if (value.Length < NameMinLength)
                {
                    throw new ArgumentOutOfRangeException(value, "Name cannot be less than " + NameMinLength + " symbols");
                }

                this.name = value;
            }
        }
        
        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            set
            {
                if (value.Length != RegNumberLength)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be " + RegNumberLength + " digits");
                }

                if (!this.IsDigitsOnly(value))
                {
                    throw new ArgumentException("Registration number must contain only digits");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.catalogList; }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Threre is no furniture");
            }

            this.catalogList.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Threre is no furniture");
            }

            this.catalogList.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.catalogList.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format(
                 "{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            var sortedFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);
            foreach (var furniture in sortedFurnitures)
            {
                result.AppendLine(furniture.ToString());
            }

            return result.ToString().Trim();
        }

       private bool IsDigitsOnly(string str)
       {
           return str.All(c => c >= '0' && c <= '9');
       }
    }
}