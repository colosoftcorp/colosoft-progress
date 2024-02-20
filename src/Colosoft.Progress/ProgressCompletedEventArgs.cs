namespace Colosoft.Progress
{
    public class ProgressCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        public ProgressCompletedEventArgs(System.Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {
        }
    }
}
