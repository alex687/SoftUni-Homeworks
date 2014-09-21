namespace Point3D
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point> points;

        public Path()
        {
            this.points = new List<Point>();
        }

        public Path(IEnumerable<Point> points)
            : this()
        {
            this.Add(points);
        }

        public Path(Point point)
            : this()
        {
            this.points.Add(point);
        }
       
        public Point[] Points
        {
            get
            {
                return this.points.ToArray();
            }
        }

        public void Add(Point newPoint)
        {
            this.points.Add(newPoint);
        }

        public void Add(IEnumerable<Point> points)
        {
            this.points.AddRange(points);
        }
    }
}
