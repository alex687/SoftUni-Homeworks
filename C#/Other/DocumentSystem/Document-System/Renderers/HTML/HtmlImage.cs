namespace DocumentSystem.Renderers.HTML
{
    using System;
    using System.IO;
    using Structure;

    public class HtmlImage : IElementRenderer
    {
        public Image element;

        public HtmlImage(Image element)
        {
            this.element = element;
        }

        public void Render(TextWriter writer)
        {
            writer.Write(
                "<img src='data:{0};base64, {1}'/>",
                this.element.Type.ContentType,
                Convert.ToBase64String(this.element.Data));
        }
    }
}
