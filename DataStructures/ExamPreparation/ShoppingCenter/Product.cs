namespace ShoppingCenter
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            if (string.Compare(this.Name, other.Name, StringComparison.Ordinal) == 0)
            {
                if (string.Compare(this.Producer, other.Producer, StringComparison.Ordinal) == 0)
                {
                    return decimal.Compare(this.Price, other.Price);
                }
                else
                {
                    return string.Compare(this.Producer, other.Producer, StringComparison.Ordinal);

                }
            }
            else
            {
                return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            }
        }


        public override string ToString()
        {
            return String.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }
}
