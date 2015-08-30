namespace LongestPathInTree
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node(T value)
        {
            this.Children = new List<Node<T>>();
            this.Value = value;
        }

        public T Value { get; set; }

        public List<Node<T>> Children { get; private set; }

        public Node<T> Parrent { get; set; }
    }
}
