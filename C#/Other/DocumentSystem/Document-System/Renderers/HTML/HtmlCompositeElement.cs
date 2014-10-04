using System.Collections.Generic;
using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public class HtmlCompositeElement : HtmlElement
    {
        protected IList<HtmlElement> ChildElements { get; set; }

        public HtmlCompositeElement()
        {
            this.ChildElements = new List<HtmlElement>();
        }

        public HtmlCompositeElement(Element[] elements)
            : this()
        {
            foreach (var element in elements)
            {
                this.ChildElements.Add(HtmlRendererFactory.Create(element));
            }
        }

        public override void RenderHtml(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderHtml(writer);
            }
        }
    }
}
