using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Tree.BinaryTrees.RedBlack;

namespace Custom_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(200);
            tree.Insert(120);
            tree.Insert(600);
            Console.WriteLine(tree);   

            /*tree.Insert(5);
            tree.Insert(3);
            tree.Insert(10);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(100);
            tree.Insert(9);*/
        }
    }
}
