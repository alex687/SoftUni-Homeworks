namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class Table : Furniture, IFurniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get 
            {
                return this.length;
            }

            set
            {
                this.length = value;
            }
        }

        public decimal Width
        {
            get 
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public decimal Area
        {
            get 
            {
                return this.length * this.width;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
        }
    }
}
