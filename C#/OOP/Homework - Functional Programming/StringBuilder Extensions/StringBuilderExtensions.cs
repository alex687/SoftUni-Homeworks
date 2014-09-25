using System;
using System.Collections.Generic;
using System.Text;

public static class Extensions
{
    public static string Substring(this StringBuilder str, int startIndex, int length)
    {
        return str.ToString().Substring(startIndex, length);
    }

    public static void AppendAll<T>(this StringBuilder str, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            str.Append(item.ToString());
        }
    }

    public static void RemoveText(this StringBuilder str, string text)
    {
        string oldValue = str.ToString();
        int occurance = oldValue.IndexOf(text, StringComparison.OrdinalIgnoreCase);
        while (occurance > -1)
        {
            oldValue = oldValue.Remove(occurance, text.Length);
            occurance = oldValue.IndexOf(text, StringComparison.OrdinalIgnoreCase);
        }
        str.Clear();
        str.Append(oldValue);
    }
}


