﻿namespace DocumentSystem.Renderers.HTML
{
    using System.IO;
    using Structure;

    public class HtmlParagraph : HtmlCompositeElement
    {
        private Paragraph element;

        public HtmlParagraph(Paragraph element)
            : base(element.GetChildElements())
        {
            this.element = element;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
            writer.Write("<p>");
            base.Render(writer);
            writer.WriteLine("</p>");
        }
    }
}
