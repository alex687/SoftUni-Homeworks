namespace CountOccurences
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

            var numberOcurrs = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                if (numberOcurrs.ContainsKey(number))
                {
                    numberOcurrs[number]++;
                }
                else
                {
                    numberOcurrs[number] = 1;
                }
            }

            foreach (var numberOcurr in numberOcurrs)
            {
                Console.WriteLine("{0} -> {1} times", numberOcurr.Key, numberOcurr.Value);
            }
        }
    }
}
