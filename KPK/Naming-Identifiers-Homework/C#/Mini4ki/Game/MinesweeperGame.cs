namespace Minesweeper.Game
{
    using System;
    using System.Collections.Generic;
    using Components;

    public enum GameEnding
    {
        Won, BombHit, NotOver
    }

    public class MinesweeperGame
    {
        private const int ChampionsListSize = 6;
        private readonly int targetPoints;

        private Board board;
        private List<Player> champions;

        public MinesweeperGame(int rows, int cols, int targetPoints)
        {
            this.board = new Board(rows, cols);
            this.champions = new List<Player>();
            this.Points = 0;
            this.targetPoints = targetPoints;
        }

        public int Points { get; private set; }

        public GameEnding Move(int row, int col)
        {
            if (!this.board.DoesHitBomb(row, col))
            {
                if (!this.board.IsCellOpened(row, col))
                {
                    this.board.AddNumberNearBombs(row, col);
                    this.Points++;
                }

                if (this.targetPoints == this.Points)
                {
                    return GameEnding.Won;
                }
                else
                {
                    this.board.PrintBoard();
                    
                    return GameEnding.NotOver;
                }
            }
            return GameEnding.BombHit;
        }

        public void PrintBoard()
        {
            this.board.PrintBoard();
        }

        public void Ranking()
        {
            this.champions.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
            this.champions.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));

            Console.WriteLine("\nTo4KI:");
            if (this.champions.Count > 0)
            {
                for (int i = 0; i < this.champions.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, this.champions[i].Name, this.champions[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        public void Restart()
        {
            this.board = new Board(this.board.Rows, this.board.Cols);
            this.Points = 0;
        }


        public void TryAddingPlayerToChampions(string name, int points)
        {
            Player newPlayer = new Player(name, this.Points);

            if (this.champions.Count < MinesweeperGame.ChampionsListSize)
            {
                this.champions.Add(newPlayer);
            }
            else
            {
                for (int i = 0; i < this.champions.Count; i++)
                {
                    if (this.champions[i].Points < newPlayer.Points)
                    {
                        this.champions.Insert(i, newPlayer);
                        this.champions.RemoveAt(this.champions.Count - 1);
                        break;
                    }
                }
            }
        }

        public void PrintBoardWithBombs()
        {
            this.board.PrintBoardWithBombs();
        }
    }
}
