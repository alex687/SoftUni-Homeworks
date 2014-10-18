using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("Invalid number! Number must be between 0 and 9");
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No numbers");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }
            return elements[0];
        }

        public static void PrintNumberWithSpaces(object number, int spaces)
        {
            Console.WriteLine("{0," + spaces + "}", number);
        }

        public static void PrintNumberWithFixedPoint(object number, int numberPoint)
        {
            Console.WriteLine("{0:f," + numberPoint + "}", number);

        }

        public static void PrintNumberPercent(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static bool IsHorizontal(double x1, double y1, double x2, double y2)
        {
            return y1 == y2;
        }

        public static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            return (x1 == x2);
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberWithFixedPoint(1.3, 2);
            PrintNumberPercent(0.75);
            PrintNumberWithSpaces(2.30, 8);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia";
            peter.BirthDate = DateTime.Parse("17.03.1992");

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results";
            stella.BirthDate = DateTime.Parse("03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
