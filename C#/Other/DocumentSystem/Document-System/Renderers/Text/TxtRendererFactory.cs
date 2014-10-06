namespace DocumentSystem.Renderers.Text
{
    using Structure;

    public class TxtRendererFactory : IRenderFactory
    {
        private static readonly RendererFactory Factory;

        static TxtRendererFactory()
        {
            TxtRendererFactory.Factory = new RendererFactory(new TxtRendererFactory());
        }

        public static IElementRenderer Create(Element element)
        {
            return Factory.Create(element);
        }

        public IElementRenderer CreateDocumentRender(Structure.Document element)
        {
            return new TxtDocument((Structure.Document)element);
        }

        public IElementRenderer CreateParagraphRender(Structure.Paragraph element)
        {
            return new TxtParagraph((Structure.Paragraph)element);
        }

        public IElementRenderer CreateTextElementRender(TextElement element)
        {
            return new TxtTextElement((TextElement)element);
        }

        public IElementRenderer CreateHyperlinkRender(Hyperlink element)
        {
            return new TxtHyperlink((Hyperlink)element);
        }

        public IElementRenderer CreateImageRender(Image element)
        {
            return new TxtImage((Image)element);
        }

        public IElementRenderer CreateHeadingRender(Heading element)
        {
            return new TxtHeading((Heading)element);
        }
    }
}
