using System;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlImage : HtmlElement
    {
        public HtmlImage(Image element)
        {
            this.Element = element;
        }

        public override void RenderHtml(TextWriter writer)
        {
            var image = (Image) this.Element;
            writer.Write("<img src='data:{0};base64, {1}'/>",
                image.Type.ContentType, Convert.ToBase64String(image.Data));
        }
    }
}
