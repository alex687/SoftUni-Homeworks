namespace DistanceCalculatorSOAPClient
{
    using System;
    using System.Runtime.InteropServices;

    using DistanceCalculator;

    public class Program
    {
        public static void Main()
        {
            int startX = int.Parse(Console.ReadLine());
            int startY = int.Parse(Console.ReadLine());

            int endX = int.Parse(Console.ReadLine());
            int endY = int.Parse(Console.ReadLine());

            DistanceCalculatorClient  distanceCalculator = new DistanceCalculatorClient();

            var startPoint = new Point() { X = startX, Y = startY };
            var endPoint = new Point() { X = endX, Y = endY };
            var distance = distanceCalculator.CalculateDistance(startPoint, endPoint);

           Console.WriteLine(distance);

        }
    }
}
