namespace Student
{
    public class PropertyChangedEventArgs<T> : System.EventArgs
    {
        public PropertyChangedEventArgs(string name, T oldV, T newV)
        {
            this.PropertyName = name;
            this.OldValue = oldV;
            this.NewValue = newV;
        }

        public string PropertyName { get; private set; }

        public T OldValue { get; private set; }

        public T NewValue {get; private set;}
    }
}
