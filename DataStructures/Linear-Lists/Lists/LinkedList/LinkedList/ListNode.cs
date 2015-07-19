namespace LinkedList.LinkedList
{
    using System.Collections.Generic;

    public sealed class ListNode<T>
    {
        private LinkedList<T> parent;
        private ListNode<T> next;
        private T item;

        public ListNode(LinkedList<T> parent, T item)
        {
            this.parent = parent;
            this.item = item;
        }

        public T Value
        {
            get { return this.item; }
            set { this.item = value; }
        }

        public ListNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }
}
