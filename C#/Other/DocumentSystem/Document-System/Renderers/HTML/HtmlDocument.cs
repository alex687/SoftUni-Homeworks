using System;
using System.IO;
using DocumentSystem.Utils;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlDocument : HtmlCompositeElement
    {

        public HtmlDocument(Document element)
            : base(element.GetChildElements())
        {
            this.Element = element;
        }


        public override void RenderHtml(TextWriter writer)
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            var doc = (Document) this.Element;
            if (doc.Title != null)
            {
                writer.WriteLine("<title>{0}</title>",
                    doc.Title.HtmlEncode());
            }
            if (doc.Author != null)
            {
                writer.WriteLine("<meta name='author' content='{0}' />",
                    doc.Author.HtmlEncode());
            }
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            base.RenderHtml(writer);
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

    }
}
