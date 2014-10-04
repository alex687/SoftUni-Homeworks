using System;
using System.IO;
using DocumentSystem.Utils;

namespace DocumentSystem.Structure
{
    public class Hyperlink : CompositeElement
    {
        public string Url { get; set; }

        public Hyperlink(string url)
        {
            this.Url = url;
        }

        public Hyperlink(string url, string text)
        {
            this.Url = url;
            this.Add(new TextElement(text));
        }

        public override void RenderText(TextWriter writer)
        {
            writer.Write("[url={0}]", this.Url);
            base.RenderText(writer);
            writer.Write("[/url]");
        }
    }
}
