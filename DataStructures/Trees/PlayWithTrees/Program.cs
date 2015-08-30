namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());


            var nodes = new Dictionary<int, Tree>();
            while (nodes.Count < nodesCount)
            {
                string input = Console.ReadLine();
                var numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
                var parrentNodeValue = numbers[0];
                var childNodeValue = numbers[1];


                CreateKeyIfNotExists(nodes, parrentNodeValue);
                CreateKeyIfNotExists(nodes, childNodeValue);

                var parrentNode = nodes[parrentNodeValue];
                var childNode = nodes[childNodeValue];
                parrentNode.Children.Add(childNode);
                childNode.Parent = parrentNode;
            }
            var pathsSum = int.Parse(Console.ReadLine());
            var subtreesSum = int.Parse(Console.ReadLine());

            var rootNode = nodes.Where(n => n.Value.Parent == null);
            if (rootNode.Count() != 1)
            {
                throw new InvalidOperationException("Invalid Tree.");
            }

            Tree resultTree = rootNode.First().Value;

            Console.WriteLine("Root Node: {0}", resultTree.FindRootNode());
            Console.WriteLine("Leaf Nodes: {0}",
                string.Join(", ", resultTree.FindLeafNodes()));
            Console.WriteLine("Middle Nodes: {0}",
                string.Join(", ", resultTree.FindMiddleNodes()));
            Console.WriteLine("Longest Path: {0}",
                string.Join(" -> ", resultTree.FindLongestPath()));

            IList<IList<int>> pathsWithValue = resultTree.FindPathsWithSum(pathsSum);
            Console.WriteLine("Paths With Value {0}:", pathsSum);
            foreach (var path in pathsWithValue)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }

            IList<Tree> subtreesWithValue = resultTree.FindSubtreesWithSum(subtreesSum);
            Console.WriteLine("Subtrees With Value {0}:", subtreesSum);
            foreach (var tree in subtreesWithValue)
            {
                Console.WriteLine(tree);
            }
        }

        private static void CreateKeyIfNotExists(Dictionary<int, Tree> nodes, int nodeValue)
        {
            if (!nodes.ContainsKey(nodeValue))
            {
                nodes.Add(nodeValue, new Tree(nodeValue));
            }

            return;
        }
    }
}
