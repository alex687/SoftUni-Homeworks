namespace BitArray
{
    using System;

    public class Program
    {
       public static void Main(string[] args)
        {
            BitArray test = new BitArray(66);
            test[7] = 1;
            Console.WriteLine(test[65]);

            Console.WriteLine(test);
        }
    }
}
