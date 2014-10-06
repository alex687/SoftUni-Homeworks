namespace DocumentSystem.Renderers.Text
{
    using System.IO;
    using Structure;

    public class TxtImage : IElementRenderer
    {
        public Image element;

        public TxtImage(Image element)
        {
            this.element = element;
        }

        public void Render(TextWriter writer)
        {
             writer.WriteLine();
            writer.WriteLine("[image]");
        }
    }
}
