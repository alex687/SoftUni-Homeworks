namespace Customer
{
    using System;

    public class Payment
    {
        private int price;
        private string productName;

        public Payment(string productName, int price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product name cannot be null or empty");
                }

                this.productName = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be < 0");
                }

                this.price = value;
            }
        }

        public object Clone()
        {
            Payment newPayment = this.MemberwiseClone() as Payment;

            return newPayment;
        }
    }
}
