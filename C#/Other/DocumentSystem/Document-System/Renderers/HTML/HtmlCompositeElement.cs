using System.Collections.Generic;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlCompositeElement : HtmlElement
    {
        protected IList<IElementRenrer> ChildElements { get; set; }

        public HtmlCompositeElement()
        {
            this.ChildElements = new List<IElementRenrer>();
        }

        public HtmlCompositeElement(Element[] elements)
            : this()
        {
            foreach (var element in elements)
            {
                this.ChildElements.Add(HtmlRendererFactory.Create(element));
            }
        }

        public override void Render(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.Render(writer);
            }
        }
    }
}
