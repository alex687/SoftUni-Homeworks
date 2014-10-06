namespace DocumentSystem.Renderers.Text
{
    using System.IO;
    using Structure;

    public class TxtHyperlink : TxtCompositeElement
    {
        private Hyperlink element;

        public TxtHyperlink(Hyperlink element)
            : base(element.GetChildElements())
        {
            this.element = element;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write("[url={0}]", this.element.Url);
            base.Render(writer);
            writer.Write("[/url]");
        }
    }
}
