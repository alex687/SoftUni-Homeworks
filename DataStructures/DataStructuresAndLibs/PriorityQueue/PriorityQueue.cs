namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;

        private List<T> heap;

        public PriorityQueue(int capacity = DefaultCapacity)
        {
            this.heap = new List<T>(capacity);
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.heap.Add(item);

            var index = this.Count - 1;

            while (this.heap[index].CompareTo(this.heap[this.GetParrentIndex(index)]) > 0 && index >= 0)
            {
                this.SwapNodes(index, this.GetParrentIndex(index));
                index = this.GetParrentIndex(index);
            }
        }


        public T Dequeue()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var dequeuedElement = this.heap[0];
            this.SwapNodes(0, this.Count - 1);
            this.heap.RemoveAt(this.Count - 1);

            int parrentId = 0;
            while (this.GetFirstChildId(parrentId) < this.Count && !this.CheckIfTheParrentHasMorePriority(parrentId))
            {
                int firstChildId = this.GetFirstChildId(parrentId);
                int secondChildId = this.GetSecondChildId(parrentId);

                if (secondChildId < this.Count)
                {
                    var firstChild = this.heap[firstChildId];
                    var secondChild = this.heap[secondChildId];

                    this.SwapNodes(parrentId, firstChild.CompareTo(secondChild) > 0 ? firstChildId : secondChildId);
                    parrentId = firstChild.CompareTo(secondChild) > 0 ? firstChildId : secondChildId;
                }
                else if (firstChildId < this.Count)
                {
                    this.SwapNodes(parrentId, firstChildId);
                    parrentId = firstChildId;
                }
            }

            return dequeuedElement;
        }

        private bool CheckIfTheParrentHasMorePriority(int parrentId)
        {
            int secondChildId = this.GetSecondChildId(parrentId);
            int firstChildId = this.GetFirstChildId(parrentId);

            T parrentElement = this.heap[parrentId];

            if (secondChildId >= this.Count)
            {
                return parrentElement.CompareTo(this.heap[firstChildId]) > 0;
            }

            return parrentElement.CompareTo(this.heap[firstChildId]) > 0 && parrentElement.CompareTo(this.heap[secondChildId]) > 0;
        }

        private int GetFirstChildId(int parrentId)
        {
            return ((parrentId + 1) * 2) - 1;
        }

        private int GetSecondChildId(int parrentId)
        {
            return (parrentId + 1) * 2;
        }

        private void SwapNodes(int firstNodeIndex, int secondNodeIndex)
        {
            var oldValue = this.heap[firstNodeIndex];
            this.heap[firstNodeIndex] = this.heap[secondNodeIndex];
            this.heap[secondNodeIndex] = oldValue;
        }

        private int GetParrentIndex(int childIndex)
        {
            var parrentIndex = (int)Math.Floor(((double)childIndex - 1) / 2);

            if (parrentIndex < 0)
            {
                return 0;
            }

            return parrentIndex;
        }

        private void BalanceTheHeap()
        {
        }
    }
}
