namespace DocumentSystem.Renderers
{
    using Structure;

    public interface IRenderFactory
    {
        IElementRenderer CreateDocumentRender(Document element);
        
        IElementRenderer CreateParagraphRender(Paragraph element);
        
        IElementRenderer CreateTextElementRender(TextElement element);
        
        IElementRenderer CreateHyperlinkRender(Hyperlink element);
        
        IElementRenderer CreateImageRender(Image element);
    
        IElementRenderer CreateHeadingRender(Heading element);
    }
}
