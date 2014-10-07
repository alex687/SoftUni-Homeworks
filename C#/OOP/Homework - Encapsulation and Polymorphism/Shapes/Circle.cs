namespace Shapes
{
    using System;

    public class Circle : IShape
    {
        public Circle(float radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius must be > 0");
            }

            this.Radius = radius;
        }

        public float Radius { get; private set; }

        public float CalculateArea()
        {
            float area = (float)(Math.PI * (this.Radius * this.Radius));

            return area;
        }

        public float CalculatePerimeter()
        {
            float perimeter = (float)Math.PI * this.Radius * 2;

            return perimeter;
        }
    }
}
