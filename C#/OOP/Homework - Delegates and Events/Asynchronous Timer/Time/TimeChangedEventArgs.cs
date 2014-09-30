namespace Asynchronous_Timer.Time
{
    public class TimeChangedEventArgs : System.EventArgs
    {
        public TimeChangedEventArgs(int ticks)
        {
            this.Ticks = ticks;
        }

        public int Ticks { get; set; }
    }
}
