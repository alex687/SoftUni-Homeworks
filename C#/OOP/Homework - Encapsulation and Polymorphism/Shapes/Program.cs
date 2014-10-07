namespace Shapes
{
    using System;

    public class Program
    {
         public static void Main(string[] args)
        {
            var shapes = new IShape[]
            {
                new Triangle(3f, 4f, 5f, 3f), 
                new Triangle(1f, 2.5f, 3f, 2f),
                new Rectangle(2.5f, 4f), 
                new Circle(1f)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name + ": ");
                Console.WriteLine(" Area: {0:f2}", shape.CalculateArea());
                Console.WriteLine(" Perimeter: {0:f2}", shape.CalculatePerimeter());
                Console.WriteLine();
            }
        }
    }
}
