namespace LaptopShop
{
    public abstract class SellItem
    {
        public string Manufacturer { get; protected set; }

        public string Model { get; protected set; }

        public double Price { get; protected set; }
    }
}
