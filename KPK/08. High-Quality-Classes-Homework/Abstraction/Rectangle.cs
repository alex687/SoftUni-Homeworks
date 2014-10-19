using System;

namespace Abstraction
{
    class Rectangle
    {
        public Rectangle()
            : this(0, 0)
        {
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        
        public double Width { get; set; }

        public double Height { get; set; }
        
        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
