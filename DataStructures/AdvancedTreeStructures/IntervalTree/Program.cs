namespace IntervalTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new IntervalTree<int, int>();
            tree.AddInterval(1, 5, 2);
        }
    }
}
