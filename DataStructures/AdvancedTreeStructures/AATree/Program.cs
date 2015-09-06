using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AATree
{
    using System.Runtime.CompilerServices;

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AaTree<int, string>();
            Console.WriteLine("The AA tree created.");
            var nums = new[] { -5, 20, 14, 11, 8, -3, 111, 7, 100, -55 };
            for (int i = 0; i < nums.Length; i++)
            {
                tree.Add(nums[i], "value");
            }
        }

    }
}
