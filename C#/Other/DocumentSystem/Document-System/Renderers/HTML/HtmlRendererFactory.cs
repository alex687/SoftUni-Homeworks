using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlRendererFactory : IRenderFactory
    {
        private static readonly RendererFactory Factory;

        static HtmlRendererFactory()
        {
            HtmlRendererFactory.Factory = new RendererFactory(new HtmlRendererFactory());
        }

        public static IElementRenrer Create(Element element)
        {
            return Factory.Create(element);
        }

        public IElementRenrer CreateDocumentRender(Document element)
        {
            return new HtmlDocument((Document)element);
        }

        public IElementRenrer CreateParagraphRender(Paragraph element)
        {
            return new HtmlParagraph((Paragraph)element);
        }

        public IElementRenrer CreateTextElementRender(TextElement element)
        {
            return new HtmlTextElement((TextElement)element);
        }

        public IElementRenrer CreateHyperlinkRender(Hyperlink element)
        {
            return new HtmlHyperlink((Hyperlink)element);
        }

        public IElementRenrer CreateImageRender(Image element)
        {
            return new HtmlImage((Image)element);
        }

        public IElementRenrer CreateHeadingRender(Heading element)
        {
            return new HtmlHeading((Heading)element);
        }
    }
}
