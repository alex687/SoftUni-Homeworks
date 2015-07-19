namespace LinkedStack
{
    using System;
    using System.Collections.Generic;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public LinkedStack()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T value)
        {
            var newNode = new Node<T>(value, this.firstNode);
            this.firstNode = newNode;

            this.Count++;
        }

        public void Pop()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException();
            }

            this.firstNode = this.firstNode.NextNode;

            this.Count--;
        }

        public T Peek()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException();
            }

            return this.firstNode.Value;
        }

        public T[] ToArray()
        {
            var array = new List<T>(this.Count);

            var node = this.firstNode;
            if (node != null)
            {
                while (node.NextNode != null)
                {
                    array.Add(node.Value);
                    node = node.NextNode;
                }
                array.Add(node.Value);
            }

            return array.ToArray();
        }
    }
}
