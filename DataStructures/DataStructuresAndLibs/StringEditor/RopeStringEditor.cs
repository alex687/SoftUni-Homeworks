namespace StringEditor
{
    using System.Linq;
    using System.Linq.Expressions;

    using Wintellect.PowerCollections;

    class RopeStringEditor : IStringEditor
    {
        private BigList<char> text;

        public RopeStringEditor()
        {
            this.text = new BigList<char>();
        }

        public string Text
        {
            get
            {
                return string.Join("", this.text);
            }
        }

        public void Append(string textForAppend)
        {
            this.text.AddRange(textForAppend);
        }

        public void Insert(int index, string textForInsert)
        {
            this.text.InsertRange(index, textForInsert);
        }

        public void Delete(int startIndex, int count)
        {
            this.text.RemoveRange(startIndex, count);
        }

        public void Replace(int startIndex, int cout, string newValue)
        {
            this.Delete(startIndex, cout);
            this.Insert(startIndex, newValue);
        }
    }
}
