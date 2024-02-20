namespace Colosoft.Progress
{
    public class ProgressChangedEventArgs : System.ComponentModel.ProgressChangedEventArgs
    {
        public long Total { get; }

        public long Processed { get; }

        public ProgressChangedEventArgs(long total, long processed)
            : this(total, processed, null)
        {
        }

        public ProgressChangedEventArgs(long total, long processed, object userState)
            : base((int)(processed * 100f / (total == 0 ? 1 : total)), userState)
        {
            this.Total = total;
            this.Processed = processed;
        }
    }
}
