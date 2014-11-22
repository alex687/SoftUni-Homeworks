using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    using DisplayExecutionTime;

    class Program
    {
        static void CalculateSquareRoot()
        {
            Console.Write("Square root of float:   ");
            Display.ExecutionTime(() =>
            {
                float result = 1000000f;
                for (int i = 0; i < 100000; i++)
                {
                    result = (float)Math.Sqrt(result);
                }
            });

            Console.Write("Square root of double:  ");
            Display.ExecutionTime(() =>
            {
                double result = 1000000.0;
                for (int i = 0; i < 100000; i++)
                {
                    result = Math.Sqrt(result);
                }
            });

            Console.Write("Square root of decimal: ");
            Display.ExecutionTime(() =>
            {
                decimal result = 1000000m;
                for (int i = 0; i < 100000; i++)
                {
                    result = (decimal)Math.Sqrt((double)result);
                }
            });
        }

        static void CalculateNaturalLogarithm()
        {
            Console.Write("Natural logarithm of float:   ");
            Display.ExecutionTime(() =>
            {
                float result = 1000000f;
                for (int i = 0; i < 100000; i++)
                {
                    result = (float)Math.Log(result);
                }
            });

            Console.Write("Natural logarithm of double:  ");
            Display.ExecutionTime(() =>
            {
                double result = 1000000.0;
                for (int i = 0; i < 100000; i++)
                {
                    result = Math.Log(result);
                }
            });

            Console.Write("Natural logarithm of decimal: ");
            Display.ExecutionTime(() =>
            {
                double result = 1000000;
                for (int i = 0; i < 100000; i++)
                {
                    
                    result = Math.Log(result);
                }
            });
        }

        static void CalculateSinus()
        {
            Console.Write("Sinus of float:   ");
            Display.ExecutionTime(() =>
            {
                float result = 1000000f;
                for (int i = 0; i < 100000; i++)
                {
                    result = (float)Math.Sin(result);
                }
            });

            Console.Write("Sinus of double:  ");
            Display.ExecutionTime(() =>
            {
                double result = 1000000.0;
                for (int i = 0; i < 100000; i++)
                {
                    result = Math.Sin(result);
                }
            });

            Console.Write("Sinus of decimal: ");
            Display.ExecutionTime(() =>
            {
                decimal result = 1000000m;
                for (int i = 0; i < 100000; i++)
                {
                    result = (decimal)Math.Sin((double)result);
                }
            });
        }

        static void Main()
        {
            CalculateSquareRoot();
            CalculateNaturalLogarithm();
            CalculateSinus();
        }
    }
}
