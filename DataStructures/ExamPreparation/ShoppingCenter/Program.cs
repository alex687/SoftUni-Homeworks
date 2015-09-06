namespace ShoppingCenter
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var center = new ShoppingCenter();

            int commands = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commands; i++)
            {
                string command = Console.ReadLine();
                string commandResult = center.ProcessCommand(command);
                Console.WriteLine(commandResult);
            }
        }
    }
}
