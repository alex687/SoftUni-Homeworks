using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers
{
    public interface IRenderFactory
    {
        IElementRenrer CreateDocumentRender(Document element);
        
        IElementRenrer CreateParagraphRender(Paragraph element);
        
        IElementRenrer CreateTextElementRender(TextElement element);
        
        IElementRenrer CreateHyperlinkRender(Hyperlink element);
        
        IElementRenrer CreateImageRender(Image element);
    
        IElementRenrer CreateHeadingRender(Heading element);
    }
}
