using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GList<int> list = new GList<int>(5);
            list.Add(200);
            list.Add(2);
            list.Add(5);
            list.Add(8);
            list.Add(10);
            list.Insert(4, 100);
            list.Remove(200);

            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            Console.WriteLine(list);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
