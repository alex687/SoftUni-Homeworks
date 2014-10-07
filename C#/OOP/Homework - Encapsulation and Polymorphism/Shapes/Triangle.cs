namespace Shapes
{
    using System;

    public class Triangle : BasicShape
    {
        public float SideA { get; private set; }

        public float SideB { get; private set; }

        public Triangle(float sideA, float sideB, float sideC, float heightC)
        {
            this.Width = sideC;
            this.Height = heightC;
            this.SideA = sideA;
            this.SideB = sideB;

            if (!this.IsTriangleValid())
            {
                throw new ArgumentException("Invalid triangle");
            }

            if (heightC <= 0)
            {
                throw new ArgumentException("Invalid height");
            }
        }

        public override float CalculateArea()
        {
            float area = (this.Width * this.Height) / 2;

            return area;
        }

        public override float CalculatePerimeter()
        {
            float perimeter = this.SideA + this.SideB + this.Width;

            return perimeter;
        }

        private bool IsTriangleValid()
        {
            // Triangle valudation formulla
            return (this.SideA + this.SideB > this.Width && this.SideB + this.Width > this.SideA &&
                this.Width + this.SideA > this.SideB);
        }
    }
}
