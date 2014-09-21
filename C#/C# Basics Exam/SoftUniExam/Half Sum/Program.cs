using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Half_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            int[] set = new int[n*2];
            for (int i = 0; i < n*2; i++)
            {
                set[i] = int.Parse(Console.ReadLine());
            }

            int firstSum = 0;
            for (int i = 0; i < n; i++)
            {
                firstSum += set[i];
            }

            int secondSum = 0;
            for (int i = n; i < n*2; i++)
            {
                secondSum += set[i];

            }

            if (firstSum == secondSum)
            {
                Console.WriteLine("Yes, sum=" + firstSum);
            }

            else
            {
                int diff = firstSum - secondSum;
                if (diff < 0)
                {
                    diff = diff * -1;
                }
                Console.WriteLine("No, diff="+diff);
            }

        }
    }
}
