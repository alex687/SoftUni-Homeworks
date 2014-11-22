namespace ComparePerfArithmeticPrimitiveValues
{
    using System;
    using DisplayExecutionTime;

    class Program
    {
       static void Add()
        {
            Console.Write("Addition of int:     ");
            Display.ExecutionTime(() =>
            {
                int sum = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    sum += 100;
                }
            });

            Console.Write("Addition of long:    ");
            Display.ExecutionTime(() =>
            {
                long sum = 0L;
                for (int i = 0; i < 1000000; i++)
                {
                    sum += 100L;
                }
            });

            Console.Write("Addition of float:   ");
            Display.ExecutionTime(() =>
            {
                float sum = 0f;
                for (int i = 0; i < 1000000; i++)
                {
                    sum += 100f;
                }
            });

            Console.Write("Addition of double:  ");
            Display.ExecutionTime(() =>
            {
                double sum = 0.0;
                for (int i = 0; i < 1000000; i++)
                {
                    sum += 100.0;
                }
            });

            Console.Write("Addition of decimal: ");
            Display.ExecutionTime(() =>
            {
                decimal sum = 0m;
                for (int i = 0; i < 1000000; i++)
                {
                    sum += 100m;
                }
            });
        }

        static void Subtract()
        {
            Console.Write("Subtraction of int:     ");
            Display.ExecutionTime(() =>
            {
                int result = 1000000000;
                for (int i = 0; i < 1000000; i++)
                {
                    result -= 100;
                }
            });

            Console.Write("Subtraction of long:    ");
            Display.ExecutionTime(() =>
            {
                long result = 1000000000L;
                for (int i = 0; i < 1000000; i++)
                {
                    result -= 100L;
                }
            });

            Console.Write("Subtraction of float:   ");
            Display.ExecutionTime(() =>
            {
                float result = 1000000000f;
                for (int i = 0; i < 1000000; i++)
                {
                    result -= 100f;
                }
            });

            Console.Write("Subtraction of double:  ");
            Display.ExecutionTime(() =>
            {
                double result = 1000000000.0;
                for (int i = 0; i < 1000000; i++)
                {
                    result -= 100.0;
                }
            });

            Console.Write("Subtraction of decimal: ");
            Display.ExecutionTime(() =>
            {
                decimal result = 1000000000m;
                for (int i = 0; i < 1000000; i++)
                {
                    result -= 100m;
                }
            });
        }

        static void Increment()
        {
            Console.Write("Increment of int:     ");
            Display.ExecutionTime(() =>
            {
                int value = 1;
                for (int i = 0; i < 1000000; i++)
                {
                    value++;
                }
            });

            Console.Write("Increment of long:    ");
            Display.ExecutionTime(() =>
            {
                long value = 1L;
                for (int i = 0; i < 1000000; i++)
                {
                    value++;
                }
            });

            Console.Write("Increment of float:   ");
            Display.ExecutionTime(() =>
            {
                float value = 1f;
                for (int i = 0; i < 1000000; i++)
                {
                    value++;
                }
            });

            Console.Write("Increment of double:  ");
            Display.ExecutionTime(() =>
            {
                double value = 1.0;
                for (int i = 0; i < 1000000; i++)
                {
                    value++;
                }
            });

            Console.Write("Increment of decimal: ");
            Display.ExecutionTime(() =>
            {
                decimal value = 1m;
                for (int i = 0; i < 1000000; i++)
                {
                    value++;
                }
            });
        }

        static void Multiply()
        {
            Console.Write("Multiplication of int:     ");
            Display.ExecutionTime(() =>
            {
                int product = 1;
                for (int i = 0; i < 1000000; i++)
                {
                    product *= 1;
                }
            });

            Console.Write("Multiplication of long:    ");
            Display.ExecutionTime(() =>
            {
                long product = 1L;
                for (int i = 0; i < 1000000; i++)
                {
                    product *= 1L;
                }
            });

            Console.Write("Multiplication of float:   ");
            Display.ExecutionTime(() =>
            {
                float product = 1f;
                for (int i = 0; i < 1000000; i++)
                {
                    product *= 1f;
                }
            });

            Console.Write("Multiplication of double:  ");
            Display.ExecutionTime(() =>
            {
                double product = 1.0;
                for (int i = 0; i < 1000000; i++)
                {
                    product *= 1.0;
                }
            });

            Console.Write("Multiplication of decimal: ");
            Display.ExecutionTime(() =>
            {
                decimal product = 1m;
                for (int i = 0; i < 1000000; i++)
                {
                    product *= 1m;
                }
            });
        }

        static void Divide()
        {
            Console.Write("Division of int:     ");
            Display.ExecutionTime(() =>
            {
                int result = 1000;
                for (int i = 0; i < 1000000; i++)
                {
                    result /= 1;
                }
            });

            Console.Write("Division of long:    ");
            Display.ExecutionTime(() =>
            {
                long result = 1000L;
                for (int i = 0; i < 1000000; i++)
                {
                    result /= 1L;
                }
            });

            Console.Write("Division of float:   ");
            Display.ExecutionTime(() =>
            {
                float result = 1000f;
                for (int i = 0; i < 1000000; i++)
                {
                    result /= 1f;
                }
            });

            Console.Write("Division of double:  ");
            Display.ExecutionTime(() =>
            {
                double result = 1000.0;
                for (int i = 0; i < 1000000; i++)
                {
                    result /= 1.0;
                }
            });

            Console.Write("Division of decimal: ");
            Display.ExecutionTime(() =>
            {
                decimal result = 1000m;
                for (int i = 0; i < 1000000; i++)
                {
                    result /= 1m;
                }
            });
        }

        public static void Main()
        {
            Add();
            Console.WriteLine();

            Subtract();
            Console.WriteLine();

            Increment();
            Console.WriteLine();

            Multiply();
            Console.WriteLine();

            Divide();
            Console.WriteLine();
        }
    }
}
