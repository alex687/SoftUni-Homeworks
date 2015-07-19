namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReverseList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;
        private int capacity;
        private int count;
        private T[] array;

        public ReverseList()
        {
            this.array = new T[DefaultCapacity];
            this.capacity = DefaultCapacity;
        }

        public ReverseList(int capacity)
        {
            this.array = new T[capacity];
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int Count
        {
            get { return this.count; }
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }

                return this.array[this.capacity + index - this.Count];
            }

            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }

                this.array[this.capacity + index - this.Count] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count >= this.capacity)
            {
                this.Expand();
            }

            this.array[(this.capacity - this.Count) - 1] = item;
            this.count++;
        }

        public void Remove(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new InvalidOperationException("Invalid index.");
            }

            T[] newArray = new T[this.capacity];
            for (int i = 0; i < index; i++)
            {
                newArray[this.capacity - i - 1] = this.array[this.capacity - i - 1];
            }

            for (int i = index + 1; i < this.Count; i++)
            {
                newArray[this.capacity - i] = this.array[this.capacity - i - 1];
            }

            this.count--;
            this.array = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Expand()
        {
            var newCapacity = this.capacity * 2;
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[newCapacity - i - 1] = this.array[this.capacity - i - 1];
            }

            this.capacity = newCapacity;
            this.array = newArray;
        }
    }
}
