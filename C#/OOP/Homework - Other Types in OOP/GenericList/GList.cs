namespace GenericList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    [Version("2.11")]
    public class GList<T> : IList<T>, ICollection<T>, IEnumerable, IEnumerable<T> where T : IComparable<T>
    {
        private T[] elements;
        private int initialSize;

        public GList(int initialSize)
        {
            this.initialSize = initialSize;
            this.elements = new T[initialSize];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);

                return this.elements[index];
            }

            set
            {
                this.CheckIndex(index);

                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Resize();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            this.CheckIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.Count--;
        }

        public int IndexOf(T element)
        {
            return this.FindIndexElement(element);
        }

        public bool Contains(T element)
        {
            if (this.FindIndexElement(element) != -1)
            {
                return true;
            }

            return false;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("There are no elements");
            }

            T min = this.FindByCriteria((e1, e2) =>
            {
                return e1.CompareTo(e2) > 0;
            });
            return min;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("There are no elements");
            }

            T max = this.FindByCriteria((e1, e) =>
            {
                return e1.CompareTo(e) < 0;
            });
            return max;
        }

        public void Insert(int index, T element)
        {
            this.CheckIndex(index);

            if (this.elements.Length == this.Count)
            {
                this.Resize();
            }

            if (index + 1 == this.Count)
            {
                this.Add(element);
                return;
            }

            T[] newArrayElements = new T[this.elements.Length];
            for (int i = 0; i < index; i++)
            {
                newArrayElements[i] = this.elements[i];
            }

            newArrayElements[index] = element;
            for (int i = index; i < this.Count; i++)
            {
                newArrayElements[i + 1] = this.elements[i];
            }

            this.Count++;
            this.elements = newArrayElements;
        }

        public override string ToString()
        {
            StringBuilder elementsStr = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                elementsStr.Append(this.elements[i] + ",");
            }

            return "{" + elementsStr.ToString() + "}";
        }

         void ICollection<T>.Clear()
        {
            this.Clear();
        }

        public void CopyTo(T[] array, int index)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.Insert(index, array[i]);
            }
        }

        public bool Remove(T item)
        {
            T[] newElements = new T[this.elements.Length];
            bool occurs = false;
            int newCounter = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].Equals(item))
                {
                    occurs = true;
                }
                else
                {
                    newElements[newCounter] = this.elements[i];
                    newCounter++;
                }
            }

            this.elements = newElements;
            this.Count = newCounter;

            return occurs;
        }

        public IEnumerator<T> GetEnumerator()
        {
            IEnumerator<T> enumerator = new GListEmum(this);

            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator enumerator = new GListEmum(this);

            return enumerator;
        }

        private void Resize()
        {
            T[] newArray = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }

        private void Clear()
        {
            this.elements = new T[this.initialSize];
        }

        private int FindIndexElement(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        private T FindByCriteria(Func<T, T, bool> criteria)
        {
            T element = this.elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (criteria(element, this.elements[i]))
                {
                    element = this.elements[i];
                }
            }

            return element;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid array index");
            }
        }

        private class GListEmum : IEnumerator, IEnumerator<T>
        {
            private GList<T> list;
            private int position = -1;

            public GListEmum(GList<T> list)
            {
                this.list = list;
            }

            public object Current
            {
                get
                {
                    return this.list[this.position];
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return (T)this.Current;
                }
            }

            public bool MoveNext()
            {
                this.position++;
                return this.position < this.list.Count;
            }

            public void Reset()
            {
                this.position = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
