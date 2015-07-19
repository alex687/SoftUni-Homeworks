namespace LinkedQueue
{
    internal class QueueNode<T>
    {
        public QueueNode(T value, QueueNode<T> nextNode = null, QueueNode<T> prevNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
            this.PrevNode = prevNode;
        }

        public QueueNode<T> NextNode { get;  set; }

        public QueueNode<T> PrevNode { get;  set; }

        public T Value { get; set; }
    }
}
