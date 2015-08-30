namespace FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            var hasParent = new Dictionary<int, bool>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                string input = Console.ReadLine();
                var numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
                
                var parrent = numbers[0];
                var child = numbers[1];

                if (hasParent.ContainsKey(child))
                {
                    hasParent[child] = true;
                }
                else
                {
                    hasParent.Add(child, true);
                }

                if (!hasParent.ContainsKey(parrent))
                {
                    hasParent.Add(parrent, false);
                }
            }

            int? root = null;
            foreach (var nodeHasParrent in hasParent)
            {
                if (nodeHasParrent.Value == false)
                {
                    if (root != null)
                    {
                        Console.WriteLine("Multiple root nodes!");
                        return;
                    }

                    root = nodeHasParrent.Key;
                }
            }

            if (root != null)
            {
                Console.WriteLine(root);
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }
    }
}
