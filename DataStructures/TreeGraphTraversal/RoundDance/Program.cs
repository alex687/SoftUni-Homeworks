namespace RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int maxDepth = 1;

        public static void Main(string[] args)
        {
            int numberOfEdges = int.Parse(Console.ReadLine());
            int leader = int.Parse(Console.ReadLine());
            var graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                string input = Console.ReadLine();
                var nodes = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

                var firstNode = nodes[0];
                var secondNode = nodes[1];

                AddNodeIntoGraph(graph, firstNode);
                AddNodeIntoGraph(graph, secondNode);

                AddEdge(graph, firstNode, secondNode);
            }

            Dfs(graph, new HashSet<int>(), leader, 1);
        }

        private static void Dfs(Dictionary<int, List<int>> graph, HashSet<int> used, int node, int depth)
        {
            if (used.Contains(node))
            {
                return;
            }

            foreach (var child in graph[node])
            {
                used.Add(node);
                Dfs(graph, used, child, depth + 1);
            }

            if (maxDepth < depth)
            {
                maxDepth = depth;
            }

            return;
        }

        private static void AddNodeIntoGraph(Dictionary<int, List<int>> graph, int node)
        {
            if (!graph.ContainsKey(node))
            {
                graph.Add(node, new List<int>());
            }
        }

        private static void AddEdge(Dictionary<int, List<int>> graph, int firstNode, int secondNode)
        {
            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);
        }
    }
}
