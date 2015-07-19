namespace SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            words.Sort();
            foreach (var word in words)
            {
                Console.Write(word + " ");
            }
        }
    }
}
