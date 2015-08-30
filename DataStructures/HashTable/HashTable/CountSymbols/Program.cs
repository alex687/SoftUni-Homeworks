namespace CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            foreach (var symbol in input)
            {
                if (symbols.ContainsKey(symbol))
                {
                    symbols[symbol] = symbols[symbol] + 1;
                }
                else
                {
                    symbols.Add(symbol, 1);
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine(symbol.Key + ": " + symbol.Value + " time/s");
            }
        }
    }
}
