namespace DistanceInLabyrinth
{
    using System;
    using System.Text;

    public class Labyrinth
    {
        protected readonly string START = "*";

        private int startCellY;
        private int startCellX;

        private string[,] matrix;

        public Labyrinth(string[,] labyrinthStr)
        {
            this.matrix = labyrinthStr;
            this.FindStartSellCordinates(labyrinthStr);
        }

        public int StartCellX
        {
            get
            {
                return this.startCellX;
            }

        }

        public int StartCellY
        {
            get
            {
                return this.startCellY;
            }
        }

        private void FindStartSellCordinates(string[,] labyrinthStr)
        {
            for (int i = 0; i < labyrinthStr.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinthStr.GetLength(1); j++)
                {

                    if (labyrinthStr[i, j] == this.START)
                    {
                        this.startCellX = i;
                        this.startCellY = j;
                    }
                }
            }
        }

        public virtual void ConsolePrint()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

        }

        public void CalculateDistances()
        {
            this.matrix[this.StartCellX, this.StartCellY] = "0";

            this.Dfs(this.matrix, this.StartCellX, this.StartCellY, 0);   
        }

        private void Dfs(string[,] matrix, int y, int x, int step)
        {
            if (int.Parse(matrix[y, x]) < step && matrix[y, x] != "0")
            {
                return;;
            }

            matrix[y, x] = step.ToString();
            step++;
            if (y + 1 < matrix.GetLength(0)  && matrix[y + 1 , x] != "x")
            {
                this.Dfs(matrix, y + 1, x, step);
            }

            if (y - 1 >= 0 && matrix[y - 1, x] != "x")
            {
                this.Dfs(matrix, y - 1, x, step);
            }

            if (x + 1 < matrix.GetLength(1) && matrix[y, x + 1] != "x")
            {
                this.Dfs(matrix, y, x + 1, step);
            }

            if (x - 1 >= 0 && matrix[y , x - 1] != "x")
            { 
                this.Dfs(matrix, y, x - 1, step);
            }
        }
    }
}
