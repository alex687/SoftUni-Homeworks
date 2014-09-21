namespace Point3D
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Point top = new Point(1, 100, 1);
            Console.WriteLine(top);

            Point zero = Point.ZeroPoint;
            Console.WriteLine(zero);

            Point thirth = new Point(1, 1, 200);
            Console.WriteLine(thirth);
            Console.WriteLine();

            Console.WriteLine("-------------Old Path----------");
            var path = new Path(top);
            path.Add(zero);
            path.Add(thirth);
            Print(path.Points);

            PathStorage.Save("path.txt", path);

            Console.WriteLine();
            var newPath = PathStorage.Load("path.txt");
            Console.WriteLine("--------New Path----------------");
            Print(newPath.Points);
        }

        public static void Print(IEnumerable<Point> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
