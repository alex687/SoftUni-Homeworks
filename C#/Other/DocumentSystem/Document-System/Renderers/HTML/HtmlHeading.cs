using System;
using System.IO;
using DocumentSystem.Structure;
using DocumentSystem.Utils;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlHeading : HtmlElement
    {

        public HtmlHeading(Heading element)
        {
            this.Element = (Element) element;
        }

        public override void RenderHtml(TextWriter writer)
        {
            var heading = (Heading)this.Element;
            writer.WriteLine();
            writer.WriteLine("<h{0}>{1}</h{0}>",
                heading.HeadingSize, heading.Text.HtmlEncode());
        }
    }
}
