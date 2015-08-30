namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private class Sequence
        {
            public Sequence(int[] value, int numberOfTurns)
            {
                this.Value = value;
                this.NumberOfTurns = numberOfTurns;
            }

            public int[] Value { get; set; }

            public int NumberOfTurns { get; set; }

            public override int GetHashCode()
            {
                return string.Join(",", this.Value).GetHashCode();
            }
        }

        private static Queue<Sequence> candidatesQueue = new Queue<Sequence>();
        private static HashSet<int> uniqueSet = new HashSet<int>();
        
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int[] initialSequence = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int reverseFactor = int.Parse(Console.ReadLine());
            candidatesQueue.Enqueue(new Sequence(initialSequence, 0));

            if (!IsSorted(initialSequence))
            {
                while (candidatesQueue.Count > 0)
                {
                    var sequence = candidatesQueue.Dequeue();
                    if (GenerateAllSequences(sequence, reverseFactor))
                    {
                        Console.WriteLine(sequence.NumberOfTurns + 1);
                        return;
                    }
                }

                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static bool GenerateAllSequences(Sequence sequence, int reverseFactor)
        {
            for (int i = 0; i < sequence.Value.Length - reverseFactor + 1; i++)
            {
                var newSequence = new Sequence(ReverseSequence(i, sequence.Value, reverseFactor), sequence.NumberOfTurns + 1);
                if (IsSorted(newSequence.Value))
                {
                    return true;
                }

                if (!uniqueSet.Contains(newSequence.GetHashCode()))
                {
                    uniqueSet.Add(newSequence.GetHashCode());

                    candidatesQueue.Enqueue(newSequence);
                }
            }

            return false;
        }

        private static bool IsSorted(int[] sequence)
        {
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] < sequence[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] ReverseSequence(int start, int[] sequence, int reverseFactor)
        {
            int[] reversed = new int[sequence.Length];
            Array.Copy(sequence, reversed, sequence.Length);
            int[] temp = new int[reverseFactor];
            Array.Copy(sequence, start, temp, 0, reverseFactor);
            Array.Reverse(temp);
            Array.Copy(temp, 0, reversed, start, reverseFactor);

            return reversed;
        }
    }
}