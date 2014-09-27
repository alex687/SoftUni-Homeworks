namespace Minesweeper.Game.Components
{
    using System;
    using System.Collections.Generic;

    internal class Board
    {
        private readonly char[,] boardHiddenBombs;
        private readonly char[,] boardNotHiddenBombs;

        public Board(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException("Rows and Cols must be grated than 0");
            }

            this.Rows = rows;
            this.Cols = cols;

            this.boardHiddenBombs = this.CreateBoard(this.Rows, this.Cols);
            this.boardNotHiddenBombs = this.CreateBoardNotHiddenBombs(this.Rows, this.Cols);
        }

        public int Rows { get; private set; }
       
        public int Cols { get; private set; }

        public void PrintBoard()
        {
            this.Print(this.boardHiddenBombs);
        }

        public void PrintBoardWithBombs()
        {
            this.Print(this.boardNotHiddenBombs);
        }

        public bool IsCellOpened(int row, int col)
        {
            if (this.boardHiddenBombs[row, col] == '-')
            {
                return true;
            }

            return false;
        }

        public bool DoesHitBomb(int row, int col)
        {
            if (this.boardNotHiddenBombs[row, col] == '*')
            {
                return true;
            }

            return false;
        }

        public void AddNumberNearBombs(int row, int col)
        {
            char bombsNear = char.Parse(this.BombsNear(row, col).ToString());
            this.boardNotHiddenBombs[row, col] = bombsNear;
            this.boardHiddenBombs[row, col] = bombsNear;
        }

        private void Print(char[,] boardToPrint)
        {
            Console.Write("\n   ");
            for (int i = 0; i < this.Cols; i++)
            {
                Console.Write(" {0}", i);
            }

            Console.WriteLine();

            Console.WriteLine("   ---------------------");
            for (int i = 0; i < this.Rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < this.Cols; j++)
                {
                    Console.Write(string.Format("{0} ", boardToPrint[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private char[,] CreateBoard(int rows, int cols)
        {
            var newBoard = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newBoard[i, j] = '?';
                }
            }

            return newBoard;
        }

        private int BombsNear(int row, int col)
        {
            int numberOfNearBombs = 0;

            if (row - 1 >= 0)
            {
                if (this.boardNotHiddenBombs[row - 1, col] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            if (row + 1 < this.Rows)
            {
                if (this.boardNotHiddenBombs[row + 1, col] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            if (col - 1 >= 0)
            {
                if (this.boardNotHiddenBombs[row, col - 1] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            if (col + 1 < this.Cols)
            {
                if (this.boardNotHiddenBombs[row, col + 1] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (this.boardNotHiddenBombs[row - 1, col - 1] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < this.Cols))
            {
                if (this.boardNotHiddenBombs[row - 1, col + 1] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            if ((row + 1 < this.Rows) && (col - 1 >= 0))
            {
                if (this.boardNotHiddenBombs[row + 1, col - 1] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            if ((row + 1 < this.Rows) && (col + 1 < this.Cols))
            {
                if (this.boardNotHiddenBombs[row + 1, col + 1] == '*')
                {
                    numberOfNearBombs++;
                }
            }

            return numberOfNearBombs;
        }

        private char[,] CreateBoardNotHiddenBombs(int rows, int cols)
        {
            char[,] bombs = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bombs[i, j] = '-';
                }
            }

            List<int> bombPositions = new List<int>();
            Random random = new Random();
            while (bombPositions.Count < 15)
            {
                int randomPosition = random.Next(50);
                if (!bombPositions.Contains(randomPosition))
                {
                    bombPositions.Add(randomPosition);
                }
            }

            foreach (int position in bombPositions)
            {
                int col = position / cols;
                int row = position % cols;
                if (row == 0 && position != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                bombs[col, row - 1] = '*';
            }

            return bombs;
        }
    }
}
