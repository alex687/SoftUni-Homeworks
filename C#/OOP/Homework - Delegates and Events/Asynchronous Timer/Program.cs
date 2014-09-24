namespace Asynchronous_Timer
{
    using System;
    using System.Threading;
    using T=Time;
    class Program
    {
        public static void Main()
        {
            var timer = new T.Timer(10, 1000);
            timer.TimeChanged += new T.Timer.TimeChangedEventHandler(Timer_TimeChanged);

            Console.WriteLine("Timer started for 10 ticks at interval 1000 ms.");
            Thread workerThread = new Thread(timer.Run);
            workerThread.Start();

            Console.WriteLine("TEST");
        }

        private static void Timer_TimeChanged(object sender,
            T.TimeChangedEventArgs eventArgs)
        {
            Console.WriteLine("Timer! Ticks left = {0}", eventArgs.Ticks);
        }
    }
}
