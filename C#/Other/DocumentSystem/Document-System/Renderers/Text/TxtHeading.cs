namespace DocumentSystem.Renderers.Text
{
    using System.IO;
    using Structure;

    public class TxtHeading : IElementRenderer
    {
        private Heading element;

        public TxtHeading(Heading element)
        {
            this.element = element;
        }

        public void Render(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine(this.element.Text.ToUpper());
        }
    }
}
