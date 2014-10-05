using System;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlColor : IElementRenrer
    {
        private Color color;

        public HtmlColor( Color color)
        {
            this.color = color;
        }

        public void Render(TextWriter writer)
        {
            writer.Write("#" +
                this.color.RedValue.ToString("X2") +
                this.color.GreenValue.ToString("X2") +
                this.color.BlueValue.ToString("X2"));
        }
    }
}
