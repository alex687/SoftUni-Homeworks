namespace DocumentSystem.Structure
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CompositeElement : Element
    {
        public CompositeElement()
        {
            this.ChildElements = new List<Element>();
        }

        public CompositeElement(params Element[] elements)
            : this()
        {
            this.Add(elements);
        }

        protected List<Element> ChildElements { get; set; }

        public CompositeElement Add(params Element[] elements)
        {
            foreach (var element in elements)
            {
                this.CheckForLoop(this, element);
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
    }
}
