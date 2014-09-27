namespace Minesweeper
{
    using System;

    using Game;

    public class GameMinesweeper
    {
        private const int GameRows = 5;
        private const int GameCows = 10;
        private const int PointsForWinningGame = 35;

        private static void Main()
        {
            var game = new MinesweeperGame(GameRows, GameCows, PointsForWinningGame);
            int row = 0, col = 0;
            string command = string.Empty;

            Console.WriteLine(
                "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");

            game.PrintBoard();
            do
            {
                Console.Write("Command: ");
                command = Console.ReadLine().Trim();
                Console.WriteLine(command);
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row < 5 && col < 10)
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        game.Ranking();
                        break;
                    case "restart":
                        game.Restart();
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        Move(game, row, col);
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        public static void Move(MinesweeperGame game, int row, int col)
        {
            var result = game.Move(row, col);
            if (result == GameEnding.Won)
            {
                game.Ranking();
                Console.WriteLine("\nBRAVOOOS! Otvri " + PointsForWinningGame + " kletki bez kapka kryv.");
                game.PrintBoardWithBombs();
                Console.WriteLine("Daj si imeto, batka: ");

                game.TryAddingPlayerToChampions(Console.ReadLine(), game.Points);

                game.Ranking();

                game.Restart();
            }

            if (result == GameEnding.BombHit)
            {
                game.PrintBoardWithBombs();
                Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", game.Points);
                game.TryAddingPlayerToChampions(Console.ReadLine(), game.Points);

                game.Ranking();

                game.Restart();
            }

        }
  
    }
}