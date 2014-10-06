namespace DocumentSystem.Renderers.HTML
{
    using System.IO;
    using Utils;
    using Structure;

    public class HtmlDocument : HtmlCompositeElement
    {
        private Document element;

        public HtmlDocument(Document element)
            : base(element.GetChildElements())
        {
            this.element = element;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            if (this.element.Title != null)
            {
                writer.WriteLine(
                    "<title>{0}</title>",
                    this.element.Title.HtmlEncode());
            }

            if (this.element.Author != null)
            {
                writer.WriteLine(
                    "<meta name='author' content='{0}' />",
                    this.element.Author.HtmlEncode());
            }

            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            base.Render(writer);
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }
    }
}
