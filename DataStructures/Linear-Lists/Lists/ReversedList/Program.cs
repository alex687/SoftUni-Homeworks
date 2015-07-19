namespace ReversedList
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new ReverseList<int>();
            
            list.Add(8);
      
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);

           // Console.WriteLine(list[4]);
            list.Remove(4);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
