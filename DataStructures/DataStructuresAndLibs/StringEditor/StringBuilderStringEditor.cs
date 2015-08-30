namespace StringEditor
{
    using System.Text;

    public class StringBuilderStringEditor : IStringEditor
    {
        private readonly StringBuilder text;

        public StringBuilderStringEditor()
        {
            this.text = new StringBuilder();
        }

        public string Text
        {
            get
            {
                return this.text.ToString();
            }
        }

        public void Append(string textForAppend)
        {
            this.text.Append(textForAppend);
        }

        public void Insert(int index, string textForInsert)
        {
            this.text.Insert(index, textForInsert);
        }

        public void Delete(int startIndex, int count)
        {
            this.text.Remove(startIndex, count);
        }

        public void Replace(int startIndex, int cout, string newValue)
        {
            this.Delete(startIndex, cout);
            this.Insert(startIndex, newValue);
        }

    }
}
