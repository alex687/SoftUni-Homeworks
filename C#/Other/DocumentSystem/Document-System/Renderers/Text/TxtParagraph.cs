namespace DocumentSystem.Renderers.Text
{
    using System.IO;

    public class TxtParagraph : TxtCompositeElement
    {
        private Structure.Paragraph element;

        public TxtParagraph(Structure.Paragraph element)
            : base(element.GetChildElements())
        {
            this.element = element;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
            base.Render(writer);
            writer.WriteLine();
        }
    }
}
