namespace Square_Root
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                double sqrt = Math.Sqrt(number);
                if (double.IsNaN(sqrt))
                {
                    throw new ArgumentException();
                }

                Console.WriteLine(sqrt);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Invalid number");

            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
