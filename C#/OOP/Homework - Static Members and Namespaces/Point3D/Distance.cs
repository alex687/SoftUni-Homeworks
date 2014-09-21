namespace Point3D
{
    using System;

    public static class Distance
    {
        public static double TwoPoints(Point a, Point b)
        {
            float deltaX = b.X - a.X;
            float deltaY = b.Y - a.Y;
            float deltaZ = b.Z - a.Z;

            double distance = Math.Sqrt((deltaX * deltaX) +
                (deltaY * deltaY) +
                (deltaZ * deltaZ));
            return distance;
        }
    }
}
