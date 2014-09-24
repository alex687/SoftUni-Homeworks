namespace Asynchronous_Timer.Time
{
    using System.Threading;

    public class Timer
    {
        private int tickCount;
        private int interval;

        public Timer(int tickCount, int interval)
        {
            this.tickCount = tickCount;
            this.interval = interval;
        }

        public delegate void TimeChangedEventHandler(object sender, TimeChangedEventArgs eventArgs);

        public event TimeChangedEventHandler TimeChanged;

        public void Run()
        {
            int tick = this.tickCount;
            while (tick > 0)
            {
                Thread.Sleep(this.interval);
                tick--;
                this.OnTimeChanged(tick);
            }
        }

        protected void OnTimeChanged(int tick)
        {
            if (this.TimeChanged != null)
            {
                TimeChangedEventArgs args = new TimeChangedEventArgs(tick);
                this.TimeChanged(this, args);
            }
        }
    }
}
