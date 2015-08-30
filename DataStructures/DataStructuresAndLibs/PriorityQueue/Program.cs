namespace PriorityQueue
{
    using System.Net;

    public class Program
    {
        public static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>();

            queue.Enqueue(80000);
            queue.Enqueue(3);
            queue.Enqueue(500);
            queue.Enqueue(900);
            queue.Enqueue(2);

            queue.Dequeue();


        }
    }
}
