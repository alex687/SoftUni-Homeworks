using System;
using System.IO;
using DocumentSystem.Renderers;

namespace DocumentSystem.Structure
{
    public abstract class Element : ITextRenderer
    {
        public abstract void RenderText(TextWriter writer);

        public Element Parent { get; set; }

        public string AsText
        {
            get
            {
                StringWriter writer = new StringWriter();
                this.RenderText(writer);
                return writer.ToString();
            }
        }

        public override string ToString()
        {
            return this.AsText;
        }
    }
}
