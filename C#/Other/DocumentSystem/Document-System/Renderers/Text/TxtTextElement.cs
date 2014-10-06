namespace DocumentSystem.Renderers.Text
{
    using System.IO;
    using Structure;

    public class TxtTextElement : IElementRenderer
    {
        private TextElement element;

        public TxtTextElement(TextElement element)
        {
            this.element = element;
        }

        public void Render(TextWriter writer)
        {
            writer.Write(this.element.Text);
        }
    }
}
