namespace SequenceNM
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    public class Program
    {
        public static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            var queue = new Queue<Item>();
            queue.Enqueue(new Item(start, null));
            while (queue.Count != 0)
            {
                var currentItem = queue.Dequeue();

                if (currentItem.Value < end || (currentItem.Value < 0 && end < 0 && currentItem.Value > end))
                {
                    queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
                    queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
                    queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
                }
                else if (currentItem.Value == end)
                {
                    PrintSequence(currentItem);
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("(No solution)");
            }
        }

        private static void PrintSequence(Item item)
        {
            var stack = new Stack<int>();

            while (item.PreviousItem != null)
            {
                stack.Push(item.Value);
                item = item.PreviousItem;

                if (item.PreviousItem == null)
                {
                    stack.Push(item.Value);
                }
            }

            Console.WriteLine(string.Join(" -> ", stack));
        }

        private class Item
        {
            public Item(int value, Item previousItem)
            {
                this.Value = value;
                this.PreviousItem = previousItem;
            }

            public int Value { get; private set; }

            public Item PreviousItem { get; private set; }
        }
    }
}
