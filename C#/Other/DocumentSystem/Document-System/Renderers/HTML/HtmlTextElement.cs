namespace DocumentSystem.Renderers.HTML
{
    using System.IO;
    using Utils;
    using Structure;

    public class HtmlTextElement : IElementRenderer
    {
        private TextElement element;

        public HtmlTextElement(TextElement element)
        {
            this.element = element;
        }

        public void Render(TextWriter writer)
        {
            if (this.element.Font != null)
            {
                writer.Write("<span style='");

                var htmlFont = new HtmlFont(this.element.Font);
                htmlFont.Render(writer);
                
                writer.Write("'>");
            }

            writer.Write(this.element.Text.HtmlEncode());
            if (this.element.Font != null)
            {
                writer.Write("</span>");
            }
        }
    }
}
