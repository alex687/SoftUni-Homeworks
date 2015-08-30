namespace LongestPathInTree
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class Tree<T>
    {
        private readonly Dictionary<T, Node<T>> nodes;

        private Node<T> root;

        public Tree()
        {
            this.nodes = new Dictionary<T, Node<T>>();
        }

        public Node<T> Root
        {
            get
            {
                if (this.root == null)
                {
                    foreach (var node in this.nodes)
                    {
                        if (node.Value.Parrent == null)
                        {
                            this.root = node.Value;
                            break;
                        }
                    }
                }

                return this.root;
            }
        }

        public List<Node<T>> Leafs
        {
            get
            {
               // return this.nodes.Where(n => n.Value.Parrent != null && n.Value.Children.Count == 1 &&n.Value.Children[0].Value.Equals(n.Value.Parrent.Value)).Select(n => n.Value).ToList();
                return this.nodes.Where(n => n.Value.Children.Count == 0).Select(n => n.Value).ToList();
            }
        }

        public void AddNewEdge(T parrent, T child)
        {
            if (!this.nodes.ContainsKey(parrent))
            {
                this.nodes.Add(parrent, new Node<T>(parrent));
            }

            if (!this.nodes.ContainsKey(child))
            {
                this.nodes.Add(child, new Node<T>(child));
            }

            this.nodes[parrent].Children.Add(this.nodes[child]);
           // this.nodes[child].Children.Add(this.nodes[parrent]);
            this.nodes[child].Parrent = this.nodes[parrent];
        }
    }
}
