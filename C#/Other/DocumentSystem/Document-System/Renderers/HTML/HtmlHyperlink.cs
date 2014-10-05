using System;
using System.IO;
using DocumentSystem.Utils;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlHyperlink : HtmlCompositeElement
    {
        public HtmlHyperlink(Hyperlink element)
            : base(element.GetChildElements())
        {
            this.Element = element;
        }

        public override void Render(TextWriter writer)
        {
            var link = (Hyperlink)this.Element;
            writer.Write("<a href='{0}'>", link.Url.HtmlEncode());
            if (this.ChildElements.Count > 0)
            {
                base.Render(writer);
            }
            else
            {
                writer.Write(link.Url.HtmlEncode());
            }
            writer.Write("</a>");
        }

    }
}
