namespace RideTheHorse
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            matrix[startRow, startCol] = 1;

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(startRow, startCol));
            while (queue.Count > 0)
            {
                var cordinates = queue.Dequeue();
                var row = cordinates.Item1;
                var col = cordinates.Item2;
                var newDepth = matrix[row, col] + 1;

                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row - 1, col - 2, newDepth);
                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row - 2, col - 1, newDepth);

                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row - 1, col + 2, newDepth);
                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row - 2, col + 1, newDepth);


                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row + 1, col - 2, newDepth);
                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row + 2, col - 1, newDepth);

                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row + 1, col + 2, newDepth);
                EnqueueCordinatesIfInMatrixAndNotVisited(matrix, queue, row + 2, col + 1, newDepth);
            }



            for (int i = 0; i < rows; i++)
            {
                    Console.WriteLine(string.Format("{0} ", matrix[i, cols / 2]));
            }
        }

        private static void EnqueueCordinatesIfInMatrixAndNotVisited(int[,] matrix,  Queue<Tuple<int, int>> queue, int row, int col, int depth)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] == 0)
            {
                queue.Enqueue(new Tuple<int, int>(row, col));
                matrix[row, col] = depth;
            }
        }
    }
}
