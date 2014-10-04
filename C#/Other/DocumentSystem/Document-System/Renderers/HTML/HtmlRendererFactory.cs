using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Renderers.HTML;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers
{
    public static class HtmlRendererFactory
    {
        public static HtmlElement Create(Element element)
        {
            if (element is Document)
            {
                return new HtmlDocument((Document)element);
            }

            if (element is Paragraph)
            {
                return new HtmlParagraph((Paragraph)element);
            }

            if (element is TextElement)
            {
                return new HtmlTextElement((TextElement)element);
            }

            if (element is Hyperlink)
            {
                return new HtmlHyperlink((Hyperlink)element);
            }

            if (element is Image)
            {
                return new HtmlImage((Image)element);
            }

            if (element is Heading)
            {
                return new HtmlHeading((Heading) element);
            }
            throw new Exception();
        }
    }
}
