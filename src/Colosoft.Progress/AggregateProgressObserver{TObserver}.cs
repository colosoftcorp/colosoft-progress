using System.Collections.Generic;

namespace Colosoft.Progress
{
    public class AggregateProgressObserver<TObserver>
        : IProgressObserver
        where TObserver : IProgressObserver
    {
        protected Queue<TObserver> Observers { get; } = new Queue<TObserver>();

        public AggregateProgressObserver<TObserver> Add(TObserver observer)
        {
            if (observer != null)
            {
                lock (this.Observers)
                {
                    this.Observers.Enqueue(observer);
                }
            }

            return this;
        }

        public AggregateProgressObserver<TObserver> Remove(TObserver observer)
        {
            if (observer != null)
            {
                lock (this.Observers)
                {
                    var aux = new Queue<TObserver>();

                    while (this.Observers.Count > 0)
                    {
                        var i = this.Observers.Dequeue();
                        if (!object.ReferenceEquals(i, observer))
                        {
                            aux.Enqueue(i);
                        }
                    }

                    while (aux.Count > 0)
                    {
                        this.Observers.Enqueue(aux.Dequeue());
                    }
                }
            }

            return this;
        }

        public void OnProgressChanged(Progress.ProgressChangedEventArgs e)
        {
            lock (this.Observers)
            {
                foreach (var i in this.Observers)
                {
                    i.OnProgressChanged(e);
                }
            }
        }

        public void OnProgressCompleted(Progress.ProgressCompletedEventArgs e)
        {
            lock (this.Observers)
            {
                foreach (var i in this.Observers)
                {
                    i.OnProgressCompleted(e);
                }
            }
        }

        public void OnStart(object userState)
        {
            lock (this.Observers)
            {
                foreach (var i in this.Observers)
                {
                    i.OnStart(userState);
                }
            }
        }
    }
}
