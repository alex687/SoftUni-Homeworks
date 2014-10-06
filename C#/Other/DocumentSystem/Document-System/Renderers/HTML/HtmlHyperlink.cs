namespace DocumentSystem.Renderers.HTML
{
    using System.IO;
    using Utils;
    using Structure;

    public class HtmlHyperlink : HtmlCompositeElement
    {
        private Hyperlink element;

        public HtmlHyperlink(Hyperlink element)
            : base(element.GetChildElements())
        {
            this.element = element;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write("<a href='{0}'>", this.element.Url.HtmlEncode());
            if (this.ChildElements.Count > 0)
            {
                base.Render(writer);
            }
            else
            {
                writer.Write(this.element.Url.HtmlEncode());
            }

            writer.Write("</a>");
        }
    }
}
