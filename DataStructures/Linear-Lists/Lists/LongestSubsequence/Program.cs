namespace LongestSubsequence
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

            var previous = numbers[0];
            var occurs = 1;
            var maxOccurs = occurs;
            var maxOccuredDigit = previous;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == previous)
                {
                    occurs++;
                }
                else
                {
                    if (occurs > maxOccurs)
                    {
                        maxOccurs = occurs;
                        maxOccuredDigit = previous;
                        occurs = 1;
                    }
                }

                previous = numbers[i];
            }

            if (occurs > maxOccurs)
            {
                maxOccurs = occurs;
                maxOccuredDigit = previous;
            }

            for (int i = 0; i < maxOccurs; i++)
            {
                Console.Write(maxOccuredDigit + " ");
            }
        }
    }
}
