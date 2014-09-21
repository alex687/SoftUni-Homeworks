namespace Point3D
{
    using System;
    using System.IO;
    
    public static class PathStorage
    {
        public static Path Load(string file)
        {
            StreamReader reader = new StreamReader(file);
            Path path = new Path();
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] cordinates = line.Split(new char[] { ',' });
                    if (cordinates.Length != 3)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    Point newPoint = new Point(
                                               float.Parse(cordinates[0]),
                                               float.Parse(cordinates[1]),
                                               float.Parse(cordinates[2]));
                    path.Add(newPoint);

                    line = reader.ReadLine();
                }
            }

            return path;
        }

        public static void Save(string file, Path patSave)
        {
            StreamWriter writer = new StreamWriter(file);
            var points = patSave.Points;
            using (writer)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    writer.WriteLine(points[i]);
                }
            }
        }
    }
}
