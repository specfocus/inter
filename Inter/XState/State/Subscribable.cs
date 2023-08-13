namespace XState.State
{
    public interface Subscription
    {
        void Unsubscribe();
    }

    public interface InteropObservable<T>
    {
        IObservable<T> ToObservable();
    }

    public interface InteropSubscribable<T>
    {
        IDisposable Subscribe(Observer<T> observer);
    }

    public interface Subscribable<T> : InteropSubscribable<T>
    {
        IDisposable Subscribe(Observer<T> observer);

        IDisposable Subscribe(Action<T> next, Action<Exception> error = null, Action complete = null);
    }
}
