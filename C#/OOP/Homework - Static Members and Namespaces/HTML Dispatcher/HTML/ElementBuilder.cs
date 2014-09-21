namespace HTML
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ElementBuilder
    {
        private string name;
        private List<Attribute> attributes;
        private string content = string.Empty;
        private int numberReps = 1;
        private bool closingTag = false;

        public ElementBuilder(string name, bool closingTag = false)
        {
            this.name = name;
            this.attributes = new List<Attribute>();
            this.closingTag = closingTag;
        }

        public static ElementBuilder operator *(ElementBuilder element, int n)
        {
            return element.Multiply(n);
        }

        public void AddAttribute(string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Ivalid atribute name or value");
            }

            this.attributes.Add(new Attribute(name, value));
        }

        public void AddContent(string content)
        {
            this.content = content;
        }

        public ElementBuilder Multiply(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("Multiply number must be bigger than 0");
            }

            this.numberReps = n;
            return this;
        }

        public override string ToString()
        {
            StringBuilder code = new StringBuilder();
            for (int i = 0; i < this.numberReps; i++)
            {
                code.Append("<" + this.name);
                foreach (var attribute in this.attributes)
                {
                    code.Append(" " + attribute.Name + "=\"" + attribute.Value + "\"");
                }

                code.Append(">" + this.content);
                if (this.closingTag)
                {
                    code.Append("</" + this.name + ">");
                }
            }

            return code.ToString();
        }

        private struct Attribute
        {
            public Attribute(string name, string value)
                : this()
            {
                this.Name = name;
                this.Value = value;
            }

            public string Name { get; private set; }

            public string Value { get; private set; }
        }
    }
}