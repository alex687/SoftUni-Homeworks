using System;
using System.Collections.Generic;
using System.IO;

namespace DocumentSystem.Structure
{
    public class CompositeElement : Element
    {
        protected List<Element> ChildElements { get; set; }

        public CompositeElement()
        {
            this.ChildElements = new List<Element>();
        }

        public CompositeElement(params Element[] elements)
            : this()
        {
            this.Add(elements);
        }

        public CompositeElement Add(params Element[] elements)
        {
            foreach (var element in elements)
            {
                CheckForLoop(this, element);
                element.Parent = this;
                this.ChildElements.Add(element);
            }
            return this;
        }

        public Element[] GetChildElements()
        {
            return this.ChildElements.ToArray();
        }

        private void CheckForLoop(Element parent, Element child)
        {
            while (parent != null)
            {
                if (parent == child)
                {
                    throw new InvalidOperationException("Loops in the document structure are not allowed.");
                }
                parent = parent.Parent;
            }
        }

        public override void RenderText(TextWriter writer)
        {
            foreach (var element in this.ChildElements)
            {
                element.RenderText(writer);
            }
        }
    }
}
