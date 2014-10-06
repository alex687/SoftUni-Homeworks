namespace DocumentSystem.Renderers.HTML
{
    using System.IO;
    using Structure;
    using Utils;

    public class HtmlHeading : IElementRenderer
    {
        private Heading element;

        public HtmlHeading(Heading element)
        {
            this.element = element;
        }

        public void Render(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine(
                "<h{0}>{1}</h{0}>",
                this.element.HeadingSize,
                this.element.Text.HtmlEncode());
        }
    }
}
