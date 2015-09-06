namespace AATree
{
    using System;
    using System.Collections.Generic;

    public class AaTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node root;

        public Node Root
        {
            get
            {
                return this.root;
            }
        }

        public bool Add(TKey key, TValue value)
        {
            if (this.root == null)
            {
                this.root = new Node(key, value);
            }

            return this.Insert(new Node(key, value), ref this.root);
        }

        public void Remove(TKey key)
        {
            this.Delete(key, ref this.root);
        }

        public Node Find(TKey key)
        {
            Node node = this.root;
            Stack<Node> stack = new Stack<Node>();
            while (stack.Count != 0 || node != null)
            {
                if (node != null)
                {
                    if (node.Value.Equals(key))
                    {
                        return node;
                    }

                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    node = node.Right;
                }
            }

            return null;
        }

        private bool Insert(Node node, ref Node parrent)
        {
            if (parrent == null)
            {
                parrent = node;
                return true;
            }

            int compare = parrent.Key.CompareTo(node.Key);
            var isInserted = false;
            if (compare < 0)
            {
                isInserted = this.TryAttachNodeToParrent(parrent, node);
                if (!isInserted)
                {
                    isInserted = this.Insert(node, ref parrent.Left);
                }
            }
            else if (compare > 0)
            {
                isInserted = this.TryAttachNodeToParrent(parrent, node);
                if (!isInserted)
                {
                    isInserted = this.Insert(node, ref parrent.Right);
                }
            }
            else
            {
                isInserted = false;
            }

            if (parrent.Left != null)
            {
                this.Skew(ref parrent);
            }

            if (parrent.Right != null && parrent.Right.Right != null)
            {
                this.Split(ref parrent);
            }

            return isInserted;
        }

        private bool TryAttachNodeToParrent(Node parrent, Node node)
        {
            int compare = parrent.Key.CompareTo(node.Key);

            if (parrent.Right == null && compare > 0)
            {
                node.Parrent = parrent;
                parrent.Right = node;
                return true;
            }

            if (parrent.Left == null && compare < 0)
            {
                node.Parrent = parrent;
                parrent.Left = node;
                return true;
            }

            return false;
        }

        private Node Delete(TKey key, ref Node rootToDeleteFrom)
        {
            if (null == rootToDeleteFrom)
            {
                return rootToDeleteFrom;
            }
            else if (key.CompareTo(rootToDeleteFrom.Key) > 0)
            {
                rootToDeleteFrom.Right = this.Delete(key, ref rootToDeleteFrom.Right);
            }
            else if (key.CompareTo(rootToDeleteFrom.Key) < 0)
            {
                rootToDeleteFrom.Left = this.Delete(key, ref rootToDeleteFrom.Left);
            }
            else
            {
                if (rootToDeleteFrom.Left == null && rootToDeleteFrom.Right == null)
                {
                    return null;
                }
                else if (null == rootToDeleteFrom.Left)
                {
                    var l = rootToDeleteFrom.Right; // successor of rootToDeleteFrom when left child is null
                    rootToDeleteFrom.Right = this.Delete(l.Key, ref rootToDeleteFrom.Right);
                    rootToDeleteFrom.Value = l.Value;
                }
                else
                {
                    var l = rootToDeleteFrom.Parrent;
                    rootToDeleteFrom.Left = this.Delete(l.Key, ref rootToDeleteFrom.Left);
                    rootToDeleteFrom.Value = l.Value;
                }
            }

            this.DecreaseLevel(ref rootToDeleteFrom);
            this.Skew(ref rootToDeleteFrom);
            this.Skew(ref rootToDeleteFrom.Right);
            if (null != rootToDeleteFrom.Right)
            {
                this.Skew(ref rootToDeleteFrom.Right.Right);
            }

            this.Split(ref rootToDeleteFrom);
            this.Split(ref rootToDeleteFrom.Right);
            return rootToDeleteFrom;
        }

        private Node DecreaseLevel(ref Node rootToRemoveLinksFor)
        {
            int shouldBe = Math.Min(rootToRemoveLinksFor.Left.Level, rootToRemoveLinksFor.Right.Level) + 1;
            if (shouldBe.CompareTo(rootToRemoveLinksFor.Level) < 0)
            {
                rootToRemoveLinksFor.Level = shouldBe;
                if (shouldBe.CompareTo(rootToRemoveLinksFor.Right.Level) < 0)
                {
                    rootToRemoveLinksFor.Right.Level = shouldBe;
                }
            }

            return rootToRemoveLinksFor;
        }

        private void Skew(ref Node node)
        {
            if (node.Level == node.Left.Level)
            {
                Node left = node.Left;

                node.Left = left.Right;
                if (left.Right != null)
                {
                    left.Right.Parrent = node.Left;
                }

                left.Right = node;
                node.Parrent = left.Right;

                node = left;
            }
        }

        private void Split(ref Node node)
        {
            if (node.Level == node.Right.Right.Level)
            {
                Node right = node.Right;

                node.Right = right.Left;
                if (right.Left != null)
                {
                    right.Left.Parrent = node.Right;
                }

                right.Left = node;
                node.Parrent = right.Left;

                node = right;
                node.Level++;
            }
        }

        public class Node
        {
            internal Node Left;

            internal Node Right;

            internal Node Parrent;

            public Node(TKey key, TValue value)
            {
                this.Value = value;
                this.Key = key;
            }

            public Node LeftChild
            {
                get
                {
                    return this.Left;
                }
            }

            public Node RightChild
            {
                get
                {
                    return this.Right;
                }
            }

            public Node ParrentNode
            {
                get
                {
                    return this.Parrent;
                }
            }

            public TKey Key { get; internal set; }

            public TValue Value { get; internal set; }

            internal int Level { get; set; }
        }
    }
}
