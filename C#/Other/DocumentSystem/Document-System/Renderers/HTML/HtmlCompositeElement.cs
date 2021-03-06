﻿namespace DocumentSystem.Renderers.HTML
{
    using System.Collections.Generic;
    using System.IO;
    using Structure;

    public class HtmlCompositeElement : IElementRenderer
    {
        protected IList<IElementRenderer> ChildElements;

        public HtmlCompositeElement(IEnumerable<Element> elements)
        {
            this.ChildElements = new List<IElementRenderer>();

            foreach (var element in elements)
            {
                this.ChildElements.Add(HtmlRendererFactory.Create(element));
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
