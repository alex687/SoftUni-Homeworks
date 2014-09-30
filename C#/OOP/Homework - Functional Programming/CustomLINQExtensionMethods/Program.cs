namespace CustomLINQExtensionMethods
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 4, 6, 0, 345, 6 };
            var newlist = list.Repeat(2);
            foreach (var item in newlist)
            {
                Console.WriteLine(item);
            }
        }
    }
}
