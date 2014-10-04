using System;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlColor : IHtmlRenderer
    {
        private Color color;

        public HtmlColor( Color color)
        {
            this.color = color;
        }

        public void RenderHtml(TextWriter writer)
        {
            writer.Write("#" +
                this.color.RedValue.ToString("X2") +
                this.color.GreenValue.ToString("X2") +
                this.color.BlueValue.ToString("X2"));
        }
    }
}
