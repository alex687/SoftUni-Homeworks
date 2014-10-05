using System;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers
{
    public class RendererFactory
    {
        private IRenderFactory renderFactory;

        public RendererFactory(IRenderFactory renderFactory)
        {
            this.renderFactory = renderFactory;
        }

        public IElementRenrer Create(Element element)
        {
            if (element is Document)
            {
                return renderFactory.CreateDocumentRender((Document)element);
            }

            if (element is Paragraph)
            {
                return renderFactory.CreateParagraphRender((Paragraph) element);
            }

            if (element is TextElement)
            {
                return renderFactory.CreateTextElementRender((TextElement)element);
            }

            if (element is Hyperlink)
            {
                return renderFactory.CreateHyperlinkRender((Hyperlink)element);
            }

            if (element is Image)
            {
                return renderFactory.CreateImageRender((Image)element);
            }

            if (element is Heading)
            {
                return renderFactory.CreateHeadingRender((Heading)element);
            }

            throw new NotSupportedException("The element -" + element.GetType().Name + " is not supported");
        }
    }
}
