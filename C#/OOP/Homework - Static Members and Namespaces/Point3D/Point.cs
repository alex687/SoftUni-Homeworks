namespace Point3D
{
    public class Point
    {
        private static readonly Point PointZero = new Point(0, 0, 0);
        
        public static Point ZeroPoint
        {
            get
            {
                return PointZero;
            }
        }

        public Point(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float X { get; private set; }
        
        public float Y { get; private set; }
        
        public float Z { get; private set; }

        public override string ToString()
        {
            return this.X + "," + this.Y + "," + this.Z;
        }
    }
}
