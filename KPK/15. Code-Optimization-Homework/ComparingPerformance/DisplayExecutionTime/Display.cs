namespace DisplayExecutionTime
{
    using System;
    using System.Diagnostics;

    public class Display
    {
        public static void ExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
