namespace DocumentSystem.Structure
{
    using System.IO;

    public class Paragraph : CompositeElement
    {
        public Paragraph()
            : base()
        {
        }

        public Paragraph(string text, Font font = null)
            : this()
        {
            this.Add(new TextElement(text, font));
        }
    }
}
