namespace ProductsInPriceRange
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int productsNumber = int.Parse(Console.ReadLine());
            var productsOrderedByPrice = new OrderedMultiDictionary<float, string>(true);

            for (int i = 0; i < productsNumber; i++)
            {
                string name = Console.ReadLine();
                float price = float.Parse(Console.ReadLine());

                if (!productsOrderedByPrice.ContainsKey(price))
                {
                    productsOrderedByPrice.Add(price, name);
                }
                else
                {
                    productsOrderedByPrice[price].Add(name);
                }
            }

            var startPrice = float.Parse(Console.ReadLine());
            var endPrice = float.Parse(Console.ReadLine());

            var range = productsOrderedByPrice.Range(startPrice, true, endPrice, true).Take(20);

            foreach (var keyValuePair in range)
            {
                Console.WriteLine("{0} -> {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
