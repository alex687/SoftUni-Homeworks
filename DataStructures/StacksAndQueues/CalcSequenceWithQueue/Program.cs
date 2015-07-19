namespace CalcSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            var sequence = new Queue<int>();
            sequence.Enqueue(startNum);

            var peakNumber = sequence.Peek();
            for (int i = 0; i < 16; i++)
            {
                sequence.Enqueue(peakNumber + 1);
                sequence.Enqueue((2 * peakNumber) + 1);
                sequence.Enqueue(peakNumber + 2);

                peakNumber = sequence.Dequeue();
                Console.Write(peakNumber + " ");
            }
        }
    }
}
