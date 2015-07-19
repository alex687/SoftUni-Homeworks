namespace DistanceInLabyrinth
{
    using System.Runtime.CompilerServices;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] input = 
            {
                {"0", "0", "0", "x", "0", "x"},
                {"0", "x", "0", "x", "0", "x"},
                {"0", "*", "x", "0", "x", "0"},
                {"0", "x", "0", "0", "0", "0"},
                {"0", "0", "0", "x", "x", "0"},
                {"0", "0", "0", "x", "0", "x"},
            };


            var l = new Labyrinth(input);
            l.CalculateDistances();

            l.ConsolePrint();
        }
    }
}
