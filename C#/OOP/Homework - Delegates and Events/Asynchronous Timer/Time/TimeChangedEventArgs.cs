namespace Asynchronous_Timer.Time
{
    class TimeChangedEventArgs : System.EventArgs
    {
        public TimeChangedEventArgs(int ticks)
        {
            this.Ticks = ticks;
        }

        public int Ticks { get; set; }
    }
}
