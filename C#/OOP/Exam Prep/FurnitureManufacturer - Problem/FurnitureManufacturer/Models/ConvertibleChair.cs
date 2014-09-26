namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class ConvertibleChair : Chair, IFurniture, IConvertibleChair, IChair
    {
        private const decimal ConvertHeight = 0.10M;

        private readonly decimal normalHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.normalHeight = height;
            this.IsConverted = false;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.IsConverted = false;
                this.Height = this.normalHeight;
            }
            else
            {
                this.IsConverted = true;
                this.Height = ConvertHeight;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
