namespace Sorting
{
    using System;
    using System.Linq;
    using DisplayExecutionTime;

    class Program
    {
        public static int[] GenerateRandomArray()
        {
            Random randomGenerator = new Random();
            int[] array = new int[100];
            for (int count = 0; count < 100; count++)
            {
                array[count] = randomGenerator.Next(count, 1000000);
            }

            return array;
        }

        static void Main(string[] args)
        {
            var randArray = GenerateRandomArray();
            var randArraySorted = GenerateRandomArray().OrderBy((a) => a).ToArray();
            var randArrayReversed = GenerateRandomArray().OrderByDescending((a) => a).ToArray();


            Console.WriteLine("Selection Sort");
            Display.ExecutionTime(() =>
            {
                SelectionSort.Sort(randArray);
                SelectionSort.Sort(randArraySorted);
                SelectionSort.Sort(randArrayReversed);
            });


            Console.WriteLine("Insertion Sort");

            Display.ExecutionTime(() =>
            {
                InsertionSort.Sort(randArray);
                InsertionSort.Sort(randArraySorted);
                InsertionSort.Sort(randArrayReversed);
            });

            Console.WriteLine("QuickSort");

            Display.ExecutionTime(() =>
            {
                QuickSort.Sort(randArray, 0, randArray.Length - 1);
                QuickSort.Sort(randArraySorted, 0, randArraySorted.Length - 1);
                QuickSort.Sort(randArrayReversed, 0, randArrayReversed.Length - 1);
            });


        }
    }
}
