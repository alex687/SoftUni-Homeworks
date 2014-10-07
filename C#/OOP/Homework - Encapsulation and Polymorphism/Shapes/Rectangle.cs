namespace Shapes
{
    using System;

    public class Rectangle : BasicShape
    {
        public Rectangle(float width, float height)
        {
            if (height <= 0 || width <=0)
            {
                throw new ArgumentException("Invalid rectangle");
            }

            this.Width = width;
            this.Height = height;
        }

        public override float CalculateArea()
        {
            float area = this.Width*this.Height;

            return area;
        }

        public override float CalculatePerimeter()
        {
            float perimeter = (this.Width + this.Height)*2;

            return perimeter;
        }
    }
}
