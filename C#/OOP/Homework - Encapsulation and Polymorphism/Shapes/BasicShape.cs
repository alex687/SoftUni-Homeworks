namespace Shapes
{
    public abstract class BasicShape : IShape
    {
        public float Width { get; protected set; }

        public float Height { get; protected set; }

        public abstract float CalculateArea();

        public abstract float CalculatePerimeter();
    }
}
