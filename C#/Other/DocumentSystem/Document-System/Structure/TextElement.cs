namespace DocumentSystem.Structure
{
    using System.IO;

    public class TextElement : Element
    {
        public TextElement(string text, Font font = null)
        {
            this.Text = text;
            this.Font = font;
        }

        public string Text { get; set; }

        public Font Font { get; set; }
    }
}
