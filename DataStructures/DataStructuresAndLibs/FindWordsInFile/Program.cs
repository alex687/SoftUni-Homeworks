namespace FindWordsInFile
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var wordOccurs = new Dictionary<string, int>();

            for (int i = 0; i < rows; i++)
            {
                var lineText = Console.ReadLine();
                var words = lineText.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (wordOccurs.ContainsKey(word))
                    {
                        wordOccurs[word]++;
                    }
                    else
                    {
                        wordOccurs.Add(word, 1);
                    }
                }
            }

            int numberOfWordsForFind = int.Parse(Console.ReadLine());
            List<string> wordsForFind = new List<string>();
            for (int i = 0; i < numberOfWordsForFind; i++)
            {
                string word = Console.ReadLine();
                wordsForFind.Add(word);
            }

            foreach (var word in wordsForFind)
            {
                int occurances = 0;

                if (wordOccurs.ContainsKey(word))
                {
                    occurances = wordOccurs[word];
                }

                Console.WriteLine("{0} -> {1}", word, occurances);
            }
        }
    }
}
