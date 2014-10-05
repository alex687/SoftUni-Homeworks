using System;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlFont : IElementRenrer
    {
        private Font font;

        public HtmlFont(Font font)
        {
            this.font = font;
        }

        public void Render(TextWriter writer)
        {
            if (this.font.Name != null)
            {
                writer.Write("font-family:{0};", this.font.Name);
            }
            if (this.font.Size != null)
            {
                writer.Write("font-size:{0}pt;", this.font.Size);
            }
            if (this.font.Color != null)
            {
                writer.Write("color:");
                
                var htmlColor = new HtmlColor(this.font.Color);
                htmlColor.Render(writer);

                writer.Write(";");
            }
            if ((this.font.Style & FontStyle.Bold) != 0)
            {
                writer.Write("font-weight:bold;");
            }
            if ((this.font.Style & FontStyle.Italic) != 0)
            {
                writer.Write("font-style:italic;");
            }
        }
    }
}
