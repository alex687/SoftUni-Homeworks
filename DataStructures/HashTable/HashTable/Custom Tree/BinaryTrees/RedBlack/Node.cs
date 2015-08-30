namespace Custom_Tree.BinaryTrees.RedBlack
{
    using System;

    class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public Node<T> Parent;

        public Node<T> LeftLink { get; set; }

        public Node<T> RightLink { get; set; }

        public NodeColor Color { get; set; }

        public Node<T> Uncle
        {
            get
            {
                if (this.Parent.Parent == null)
                    return null;

                if (WhichSideAmIOn() == NodeSide.Left)
                {
                    return this.Parent.Parent.RightLink;
                }
                else
                    return this.Parent.Parent.LeftLink;
            }
        }

        public NodeSide WhichSideAmIOn()
        {
            if (this.Parent == null)
            {
                return NodeSide.None;
            }

            if (this.Parent.LeftLink == this)
            {
                return NodeSide.Left;
            }

            if (this.Parent.RightLink == this)
            {
                return NodeSide.Right;
            }

            throw new Exception("Impossible - there can be only two sides. You must not be a child of your parent.");
        }
    }
}
