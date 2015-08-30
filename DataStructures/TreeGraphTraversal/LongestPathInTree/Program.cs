namespace LongestPathInTree
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfEdges = int.Parse(Console.ReadLine());

            var tree = new Tree<int>();

            for (int i = 0; i < numberOfEdges; i++)
            {

                string input = Console.ReadLine();
                var nodes = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

                var parrent = nodes[0];
                var child = nodes[1];

                tree.AddNewEdge(parrent, child);
            }

            var root = tree.Root;

            var leafs = tree.Leafs;

            var sums = new int[2];
            sums[0] = int.MinValue;
            sums[1] = int.MinValue;
            foreach (var child in root.Children)
            {
                var sum = Dfs(child, child.Value);
                if (sum > sums[0])
                {
                    sums[1] = sums[0];
                    sums[0] = sum;
                }
                else
                {
                    if (sum > sums[1])
                    {
                        sums[1] = sum;
                    }
                }
            }

            Console.WriteLine(sums[0] + sums[1] + root.Value);
        }

        public static int Dfs(Node<int> node, int sum)
        {
            int? maxSum = null;

            foreach (var child in node.Children)
            {

                var returnedSum = Dfs(child, sum + node.Value) + node.Value;

                if (maxSum == null || returnedSum > maxSum)
                {
                    maxSum = returnedSum;
                }
            }

            if (maxSum != null)
            {
                return maxSum.Value;
            }
            return node.Value;
        }
    }
}
