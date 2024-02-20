namespace Colosoft.Progress
{
    public interface IProgressObserver
    {
        void OnStart(object userState);

        void OnProgressChanged(ProgressChangedEventArgs e);

        void OnProgressCompleted(ProgressCompletedEventArgs e);
    }
}
