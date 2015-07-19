namespace DistanceCalculatorSoap
{
    using System;

    public class DistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(Point startPoint, Point endPoint)
        {
            return Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Y - endPoint.Y, 2));
        }
    }
}
