using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joro
{
    class Program
    {
        static void Main(string[] args)
        {
            string leap = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            float plays = 0;
            if (leap[0] == 't')
            {
                plays += 3;

            }

            plays += (float)(p * 0.5);
            plays += h;
            plays += (52 - h) * 2 / 3;
            Console.WriteLine(Math.Round(plays));
        }
    }
}
