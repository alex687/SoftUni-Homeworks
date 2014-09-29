using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLINQExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() {1, 2, 4, 6, 0, 345, 6};
            var newlist =  list.Repeat(2);
            foreach (var item in newlist)
            {
                Console.WriteLine(item);
            }
        }
    }
}
