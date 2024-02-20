namespace Colosoft.Progress
{
    public class AggregateProgressWithMessageObserver<TObserver> : AggregateProgressObserver<TObserver>, IProgressWithMessageObserver
        where TObserver : IProgressWithMessageObserver
    {
        public void OnProgressMessageChanged(ProgressMessageChangedEventArgs e)
        {
            lock (this.Observers)
            {
                foreach (var i in this.Observers)
                {
                    i.OnProgressMessageChanged(e);
                }
            }
        }
    }
}
