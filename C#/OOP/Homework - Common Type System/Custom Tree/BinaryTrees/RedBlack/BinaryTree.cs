namespace Custom_Tree.BinaryTrees.RedBlack
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T> root;
        private int count = 0;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Insert(T value)
        {
            if (this.root == null)
            {
                this.root = new Node<T> { Value = value, Color = NodeColor.Black, Parent = null };
            }
            else
            {
                this.InsetNewNode(this.root, value);
                this.Rebalance();
            }
            this.count++;
        }

        public void Remove(T value)
        {
            
        }

        public override string ToString()
        {
            var elements = new List<T>();
            ElementsToList(this.root, elements);
            return "{ " + string.Join(",", elements) + " }";
        }

        private void ElementsToList(Node<T> node, List<T> elements)
        {
            if (node == null)
            {
                return;
            }

            this.ElementsToList(node.LeftLink, elements);
            elements.Add(node.Value);
            this.ElementsToList(node.RightLink, elements);
        }

        private void InsetNewNode(Node<T> node, T value)
        {
            if (node.Value.CompareTo(value) < 0)
            {
                if (node.RightLink == null)
                {
                    node.RightLink = new Node<T> { Value = value, Parent = node, Color = NodeColor.Red };
                }
                else
                {
                    this.InsetNewNode(node.RightLink, value);
                }
            }

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftLink == null)
                {
                    node.LeftLink = new Node<T> { Value = value, Parent = node, Color = NodeColor.Red };
                }
                else
                {
                    this.InsetNewNode(node.LeftLink, value);
                }
            }
        }

        private void Rebalance()
        {
            Node<T> node = this.root;
            var stack = new Stack<Node<T>>();
            while (stack.Count != 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.LeftLink;
                }
                else
                {
                    node = stack.Pop();
                    if (node.Parent != null)
                    {
                        this.Rebalance(node);
                    }

                    node = node.RightLink;
                }
            }
        }

        private void Rebalance(Node<T> node)
        {
            if (node.Parent.Color == NodeColor.Red)
            {
                if (node.Uncle != null)
                {
                    this.ParentRedRebalancing(node);
                }
                else
                {
                    // if my parent and I are on the same side, 
                    if (node.WhichSideAmIOn() == node.Parent.WhichSideAmIOn())
                    {
                        this.TwoRedNodesOnSameSideRebalancing(node);
                    }
                    else
                    {
                        this.TwoRedNodesOndiffrentSidesRebalancing(node);
                    }
                }
            }
        }

        private void ParentRedRebalancing(Node<T> node)
        {
            // my parent + uncle needs to be black
            node.Parent.Color = NodeColor.Black;
            node.Uncle.Color = NodeColor.Black;
        }

        // The rule of two red nodes to the same side
        // if the nodes of the tree are stacked in one direction and the two stacked nodes are red
        // the middle node comes up to the parent and the top node becomes the left or right hand child.
        private void TwoRedNodesOnSameSideRebalancing(Node<T> node)
        {
            Node<T> parent = node.Parent;
            Node<T> grandParent = parent.Parent;
            Node<T> greatGrandParent = grandParent.Parent;
            NodeSide grandParentSide = grandParent.WhichSideAmIOn();

            // set my great, grand parent, to point at my parent
            if (greatGrandParent != null)
            {
                if (grandParentSide == NodeSide.Left)
                {
                    greatGrandParent.LeftLink = parent;
                }
                else
                {
                    greatGrandParent.RightLink = parent;
                }
            }

            NodeSide nodeSide = node.WhichSideAmIOn();
            if (nodeSide == NodeSide.Left)
            {
                // set my parents right to my grandParent
                parent.RightLink = grandParent;
                grandParent.LeftLink = null;
            }
            else if (nodeSide == NodeSide.Right)
            {
                // set my parents right to my grandParent
                parent.LeftLink = grandParent;
                grandParent.RightLink = null;
            }

            // reset the parent, update the root
            parent.Parent = greatGrandParent;
            if (greatGrandParent == null)
            {
                this.root = parent;
            }

            grandParent.Parent = parent;
            parent.Color = NodeColor.Black;
            grandParent.Color = NodeColor.Red;
        }

        // The rule of two red nodes on different sides
        // if the nodes of a tree are both red and one goes to the left, but the other goes to the right
        // then the middle node becomes the parent and the top node becomes the left or right child
        private void TwoRedNodesOndiffrentSidesRebalancing(Node<T> node)
        {
            Node<T> parent = node.Parent;
            Node<T> grandParent = parent.Parent;
            Node<T> greatGrandParent = grandParent.Parent;

            if (grandParent != null)
            {
                var grandParentNodeSide = grandParent.WhichSideAmIOn();

                // replace the reference to my grand parent with me
                if (grandParentNodeSide == NodeSide.Left)
                {
                    greatGrandParent.LeftLink = node;
                }
                else if (grandParentNodeSide == NodeSide.Right)
                {
                    greatGrandParent.RightLink = node;
                }
            }

            // put my parent and my grand parent on the
            // correct side of me.
            NodeSide nodeNodeSide = node.WhichSideAmIOn();
            NodeSide parentSide = parent.WhichSideAmIOn();
            if (nodeNodeSide == NodeSide.Left)
            {
                node.LeftLink = grandParent;
                node.RightLink = parent;
                // I was the child of parent, wipe this refernce
                parent.LeftLink = null;
            }
            else
            {
                node.LeftLink = parent;
                node.RightLink = grandParent;
                // i was the child of parent, wipe this reference
                parent.RightLink = null;
            }

            parent.Parent = node;
            grandParent.Parent = node;

            // parent was the child of grandparent, wipe this reference
            if (parentSide == NodeSide.Left)
            {
                grandParent.LeftLink = null;
            }

            if (parentSide == NodeSide.Right)
            {
                grandParent.RightLink = null;
            }

            // reset my parent and root
            node.Parent = greatGrandParent;
            if (greatGrandParent == null)
            {
                this.root = node;
            }

            // swap colors
            node.Color = NodeColor.Black;
            grandParent.Color = NodeColor.Red;
        }
    }
}
