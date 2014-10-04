using System;
using System.IO;
using DocumentSystem.Utils;

namespace DocumentSystem.Structure
{
    public class TextElement : Element
    {
        public string Text { get; set; }
        public Font Font { get; set; }

        public TextElement(string text, Font font = null)
        {
            this.Text = text;
            this.Font = font;
        }

        public override void RenderText(TextWriter writer)
        {
            writer.Write(this.Text);
        }
    }
}
