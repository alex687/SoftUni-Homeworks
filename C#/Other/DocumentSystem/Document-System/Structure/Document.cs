using System;
using System.IO;
using DocumentSystem.Utils;

namespace DocumentSystem.Structure
{
    public class Document : CompositeElement
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public override void RenderText(TextWriter writer)
        {
            if (this.Title != null)
            {
                writer.WriteLine("Title: {0}", this.Title);
            }
            if (this.Author != null)
            {
                writer.WriteLine("Author: {0}", this.Author);
            }
            base.RenderText(writer);
        }
    }
}
