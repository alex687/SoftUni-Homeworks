namespace ArrayBasedStack
{
    using System;
    using System.Linq;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 3;

        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.Count = 0;
            this.Capacity = capacity;
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Expand();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[this.Count - 1];
        }

        public void Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Count--;
        }

        public T[] ToArray()
        {
            return this.elements.Take(this.Count).Reverse().ToArray();
        }

        private void Expand()
        {
            var newCapacity = this.Capacity * 2;

            T[] newArray = new T[newCapacity];
            this.elements.CopyTo(newArray, 0);

            this.Capacity = newCapacity;
            this.elements = newArray;
        }
    }
}
