namespace LaptopShop
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Laptop lenovo = new Laptop("HP 250 G2", 649);
            Console.WriteLine(lenovo);

            Console.WriteLine();

            var battery = new Battery(4.5, "Li-Ion, 4-cells, 2550 mAh");
            Laptop siemens = new Laptop(
                           "Lenovo",
                           "Lenovo Yoga 2 Pro", 
                           2259,
                           "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
                           "Intel HD Graphics 4400",
                           "8 GB",
                           "128GB SSD",
                           "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",
                           battery);

            Console.WriteLine(siemens);
        }
    }
}
