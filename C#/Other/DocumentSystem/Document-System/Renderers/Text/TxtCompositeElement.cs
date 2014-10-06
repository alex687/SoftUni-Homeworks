namespace DocumentSystem.Renderers.Text
{
    using System.Collections.Generic;
    using System.IO;
    using Structure;

    public class TxtCompositeElement : IElementRenderer
    {
        protected IList<IElementRenderer> ChildElements;

        public TxtCompositeElement(IEnumerable<Element> elements)
        {
            this.ChildElements = new List<IElementRenderer>();

            foreach (var element in elements)
            {
                this.ChildElements.Add(TxtRendererFactory.Create(element));
            }
        }

        public virtual void Render(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.Render(writer);
            }
        }
    }
}
