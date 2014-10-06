namespace DocumentSystem.Renderers.HTML
{
    using DocumentSystem.Structure;

    public class HtmlRendererFactory : IRenderFactory
    {
        private static readonly RendererFactory Factory;

        static HtmlRendererFactory()
        {
            HtmlRendererFactory.Factory = new RendererFactory(new HtmlRendererFactory());
        }

        public static IElementRenderer Create(Element element)
        {
            return Factory.Create(element);
        }

        public IElementRenderer CreateDocumentRender(Document element)
        {
            return new HtmlDocument((Document)element);
        }

        public IElementRenderer CreateParagraphRender(Paragraph element)
        {
            return new HtmlParagraph((Paragraph)element);
        }

        public IElementRenderer CreateTextElementRender(TextElement element)
        {
            return new HtmlTextElement((TextElement)element);
        }

        public IElementRenderer CreateHyperlinkRender(Hyperlink element)
        {
            return new HtmlHyperlink((Hyperlink)element);
        }

        public IElementRenderer CreateImageRender(Image element)
        {
            return new HtmlImage((Image)element);
        }

        public IElementRenderer CreateHeadingRender(Heading element)
        {
            return new HtmlHeading((Heading)element);
        }
    }
}
