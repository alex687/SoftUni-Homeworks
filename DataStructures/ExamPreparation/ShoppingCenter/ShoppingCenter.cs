namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class ShoppingCenter : Product
    {
        private readonly Dictionary<string, OrderedBag<Product>> productsByName;

        private readonly Dictionary<string, OrderedBag<Product>> productsByProducer;

        private readonly Dictionary<string, OrderedBag<Product>> productsByNameProducer;

        private readonly OrderedDictionary<decimal, OrderedBag<Product>> productsByPrice;

        public ShoppingCenter()
        {
            this.productsByPrice = new OrderedDictionary<decimal, OrderedBag<Product>>();
            this.productsByNameProducer = new Dictionary<string, OrderedBag<Product>>();
            this.productsByName = new Dictionary<string, OrderedBag<Product>>();
            this.productsByProducer = new Dictionary<string, OrderedBag<Product>>();
        }

        public string AddProduct(string name, decimal price, string producer)
        {
                var newProduct = new Product() { Name = name, Price = price, Producer = producer };
            this.productsByName.AppendValueToKey(name, newProduct);
            this.productsByProducer.AppendValueToKey(producer, newProduct);
            this.productsByPrice.AppendValueToKey(price, newProduct);
            this.productsByNameProducer.AppendValueToKey(name + producer, newProduct);

            return "Product added";
        }

        public string DeleteProducts(string producer)
        {
            OrderedBag<Product> productsToDelete;
            this.productsByProducer.TryGetValue(producer, out productsToDelete);

            if (productsToDelete != null)
            {
                foreach (var product in productsToDelete)
                {
                    this.productsByName[product.Name].Remove(product);
                    this.productsByNameProducer.Remove(product.Name + product.Producer);
                    this.productsByPrice[product.Price].Remove(product);
                }

                this.productsByProducer.Remove(producer);

                return productsToDelete.Count + " products deleted";
            }

            return "No products found";
        }


        public string DeleteProducts(string name, string producer)
        {
            OrderedBag<Product> productsToDelete;
            this.productsByNameProducer.TryGetValue(name + producer, out productsToDelete);

            if (productsToDelete != null)
            {
                foreach (var product in productsToDelete)
                {
                    this.productsByName[product.Name].Remove(product);
                    this.productsByProducer.Remove(product.Producer);
                    this.productsByPrice[product.Price].Remove(product);
                }

                this.productsByNameProducer.Remove(name + producer);

                return productsToDelete.Count + " products deleted";
            }

            return "No products found";
        }

        public string FindProductsByName(string name)
        {
            OrderedBag<Product> products;
            this.productsByName.TryGetValue(name, out products);

            return this.PrintProducts(products);
        }


        public string FindProductsByProducer(string producer)
        {
            OrderedBag<Product> products;
            this.productsByProducer.TryGetValue(producer, out products);

            return this.PrintProducts(products);
        }


        public string FindProductsByPriceRange(decimal startPrice, decimal endPrice)
        {
            return
                this.PrintProducts(
                    this.productsByPrice.Range(startPrice, true, endPrice, true).SelectMany(result => result.Value));
        }

        private string PrintProducts(IEnumerable<Product> products)
        {
            if (products != null && products.Any())
            {
                var sortedProducts = products.OrderBy(p => p);
                return string.Join(Environment.NewLine, sortedProducts);
            }

            return "No products found";
        }

        public string ProcessCommand(string commandLine)
        {
            int spaceIndex = commandLine.IndexOf(' ');
            if (spaceIndex == -1)
            {
                return "Invalid command";
            }

            string command = commandLine.Substring(0, spaceIndex);
            string paramsStr = commandLine.Substring(spaceIndex + 1);
            string[] cmdParams = paramsStr.Split(';');
            switch (command)
            {
                case "AddProduct":
                    return this.AddProduct(cmdParams[0], decimal.Parse(cmdParams[1]), cmdParams[2]);
                case "DeleteProducts":
                    if (cmdParams.Length == 1) return this.DeleteProducts(cmdParams[0]);
                    else return this.DeleteProducts(cmdParams[0], cmdParams[1]);
                case "FindProductsByName":
                    return this.FindProductsByName(cmdParams[0]);
                case "FindProductsByProducer":
                    return this.FindProductsByProducer(cmdParams[0]);
                case "FindProductsByPriceRange":
                    return this.FindProductsByPriceRange(decimal.Parse(cmdParams[0]), decimal.Parse(cmdParams[1]));
                default:
                    return "Invalid command";
            }
        }
    }
}
