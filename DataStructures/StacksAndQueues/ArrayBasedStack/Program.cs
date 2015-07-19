namespace ArrayBasedStack
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new ArrayStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            stack.Pop();
            var array = stack.ToArray();
            Console.WriteLine(stack.Peek());
        }
    }
}
