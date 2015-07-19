namespace LinkedQueue.Console
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var queue = new LinkedQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            queue.Dequeue();


            Console.WriteLine(queue.Peek());
        }
    }
}
