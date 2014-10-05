using System;
using System.IO;
using DocumentSystem.Utils;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlTextElement : HtmlElement
    {

        public HtmlTextElement(TextElement element)
        {
            this.Element = (Element)element;
        }

        public override void Render(TextWriter writer)
        {
            var text = (TextElement)this.Element;
            if (text.Font != null)
            {
                writer.Write("<span style='");

                var htmlFont = new HtmlFont(text.Font);
                htmlFont.Render(writer);
                
                writer.Write("'>");
            }

            writer.Write(text.Text.HtmlEncode());
            if (text.Font != null)
            {
                writer.Write("</span>");
            }
        }
    }
}
