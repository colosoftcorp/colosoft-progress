namespace Colosoft.Progress
{
    public interface IProgressWithMessageObserver : IProgressObserver
    {
        void OnProgressMessageChanged(ProgressMessageChangedEventArgs e);
    }
}
