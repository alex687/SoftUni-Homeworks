using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = new StringBuilder();
        builder.Append("soskmlkdgmlalakm|AAAZ|dopkfdpokaaaz");
        builder.RemoveText("AAAZ");

        Console.WriteLine(builder.ToString());
    }
}
