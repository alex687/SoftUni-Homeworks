namespace DocumentSystem.Renderers.Text
{
    using System.IO;
    using Structure;

    public class TxtDocument : TxtCompositeElement
    {
        private Document element;

        public TxtDocument(Structure.Document element)
            : base(element.GetChildElements())
        {
            this.element = element;
        }

        public override void Render(TextWriter writer)
        {
             if (this.element.Title != null)
            {
                writer.WriteLine("Title: {0}", this.element.Title);
            }

            if (this.element.Author != null)
            {
                writer.WriteLine("Author: {0}", this.element.Author);
            }

            base.Render(writer);
        }
    }
}
