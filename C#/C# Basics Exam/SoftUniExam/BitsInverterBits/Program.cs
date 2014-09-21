using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsInverterBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            //);
            Console.WriteLine(Math.Floor((double)11/8));
            int steps = 0;
            int count = 0;
            int currentNumber = 0;
            int totalSteps = n * 8;
            while (steps < n * 8)
            {
                if (steps < (currentNumber + 1) * 8)
                {
                    int mask = 1;
                    Console.WriteLine("REsult=" + (numbers[currentNumber] & (mask << totalSteps-steps)));
                    Console.WriteLine(Convert.ToString(numbers[currentNumber],2));
                    Console.WriteLine(Convert.ToString(mask << totalSteps-steps, 2));

                    if ((numbers[currentNumber] & (mask << totalSteps-steps)) > 0)
                    {
                        Console.WriteLine(numbers[currentNumber]+ "@@@@");
                        count++;
                        steps = count * step;
                        numbers[currentNumber] = numbers[currentNumber] ^ (mask << steps);
                        Console.WriteLine(numbers[currentNumber]);
                    }
                    if ((numbers[currentNumber] & (mask << totalSteps-steps)) == 0)
                    {
                        Console.WriteLine(numbers[currentNumber] + " " + count + " " + steps);
                        count++;
                        steps = count * step;
                    }
                }
                else
                {
                    currentNumber++;
                }
            }
        }
    }
}
