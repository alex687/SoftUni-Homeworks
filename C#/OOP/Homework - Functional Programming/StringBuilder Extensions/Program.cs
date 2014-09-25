using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        StringBuilder builder = new StringBuilder();
        builder.Append("soskmlkdgmlalakm|AAAZ|dopkfdpokaaaz");
        builder.RemoveText("AAAZ");

        Console.WriteLine(builder.ToString());
    }
}

