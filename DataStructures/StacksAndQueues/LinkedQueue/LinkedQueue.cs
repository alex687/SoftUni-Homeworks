namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> head;

        private QueueNode<T> tail;

        public LinkedQueue()
        {
            this.Count = 0;
        }

        public int Count { get;  private set; }

        public void Enqueue( T value)
        {
            if (this.head == null)
            {
                this.head = new QueueNode<T>(value);
                this.tail = this.head;
            }
            else
            {
                var node = new QueueNode<T>(value, null,this.tail);
                this.tail.NextNode = node;
                
                this.tail = node;
            }
            this.Count++;
        }

        public void Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            this.head = this.head.NextNode;
            this.Count--;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.Value;
        }
    }
}
