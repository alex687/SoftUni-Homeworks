namespace LinkedList.LinkedList
{
    #region

    using System.Collections;
    using System.Collections.Generic;

    #endregion

    public class LinkedList<T> : IEnumerable<T>
    {
        private int count;

        private ListNode<T> last;

        private ListNode<T> first;

        public LinkedList()
        {
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T First
        {
            get
            {
                return this.first.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> item = this.first;
            for (int i = 0; i <= this.count; i++)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            if (this.last == null)
            {
                this.first = new ListNode<T>(this, item);
                this.last = this.first;
                return;
            }

            this.last.Next = new ListNode<T>(this, item);
            this.last = this.last.Next;
            this.count++;
        }

        public int FirstIndexOf(T item)
        {
            ListNode<T> newNode = this.first;
            int index = 0;
            while (true)
            {
                if (newNode.Value.Equals(item))
                {
                    break;
                }

                index++;
                newNode = newNode.Next;
                if (newNode == null)
                {
                    index = -1;
                    break;
                }
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            ListNode<T> newNode = this.first;
            int lastIndex = -1;
            int index = 0;
            while (true)
            {
                if (newNode.Value.Equals(item))
                {
                    lastIndex = index;
                }

                index++;
                newNode = newNode.Next;
                if (newNode == null)
                {
                    break;
                }
            }

            return lastIndex;
        }

        public void Remove(int index)
        {
            ListNode<T> temp = this.first;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }

            temp.Next = temp.Next.Next;
            this.count--;
        }
    }
}