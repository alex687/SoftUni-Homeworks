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
            Console.WriteLine(tree.Count);
           
            tree.Remove(2);
            tree.Remove(5);
            tree.Remove(8);
            Console.WriteLine(tree);
            tree.Remove(11);
            tree.Remove(200);
            tree.Remove(120);
            tree.Remove(600);
            tree.Remove(3);
            Console.WriteLine(tree);
            Console.WriteLine(tree.Count);

            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(60);
            tree.Insert(1);
            tree.Insert(500);
            tree.Insert(2);
            Console.WriteLine(tree);
            Console.WriteLine(tree.Count);

            var newTree = new BinaryTree<int>();
            newTree.Insert(10);
            newTree.Insert(20);
            newTree.Insert(30);
            newTree.Insert(60);
            newTree.Insert(1);
            newTree.Insert(500);
            newTree.Insert(2);
            Console.WriteLine(newTree);
            Console.WriteLine(newTree.Count);
            Console.WriteLine(tree.Equals(newTree));


            foreach (var value in tree)
            {
                Console.WriteLine(value);
            }

            BinaryTree<int> r = null;
            Console.WriteLine(tree.Equals(r));
            int a = 5; 
            Console.WriteLine(a.Equals(null));

        }
    }
}
