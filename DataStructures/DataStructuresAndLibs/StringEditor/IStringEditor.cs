namespace StringEditor
{
    public interface IStringEditor
    {
        string Text { get; }

        void Append(string textForAppend);

        void Insert(int index, string textForInsert);

        void Delete(int startIndex, int count);

        void Replace(int startIndex, int cout, string newValue);
    }
}
