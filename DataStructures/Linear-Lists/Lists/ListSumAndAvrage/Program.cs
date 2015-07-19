namespace ListSumAndAvrage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers =
                input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.Parse(i))
                    .ToList();

            var sum = numbers.Sum();
            var average = 0D;
            if (numbers.Count > 0)
            {
                average = numbers.Average();
            }

            Console.WriteLine("Sum={0}; Average={1}", sum, average);
        }
    }
}
