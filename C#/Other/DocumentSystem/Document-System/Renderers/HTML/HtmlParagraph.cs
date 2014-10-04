using System;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlParagraph : HtmlCompositeElement
    {
        public HtmlParagraph(Paragraph element)
            : base(element.GetChildElements())
        {
            this.Element = (Element)element;
        }

        public override void RenderHtml(TextWriter writer)
        {
            writer.WriteLine();
            writer.Write("<p>");
            base.RenderHtml(writer);
            writer.WriteLine("</p>");
        }

    }
}
