namespace EnterNumbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int start = 1;
            int end = 100;

            for (int i = 0; i < 10; i++)
            {
                start = ReadNumber(start, end);
            }
        }
        
        public static int ReadNumber(int start, int end)
        {
            int number = start+1;

            try
            {
                do
                {
                    if (!(start < number && number < end))
                    {
                        Console.WriteLine("Your number is not in range {0} - {1} !", start, end);
                    }

                    Console.Write("Enter number {0} < your number < {1}: ", start, end);
                    number = int.Parse(Console.ReadLine());
                } while (!(start < number && number < end));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number");
                return ReadNumber(start, end);
            }

            return number;
        }
    }
}
