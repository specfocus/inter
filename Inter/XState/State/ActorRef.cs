namespace XState.State
{
    public class ActorRef<TContext, TEvent> : IObserver<TContext>
    {
        public string Id { get; }
        public Action<TEvent> Send { get; set; }
        public Action Stop { get; set; }
        public Func<object> GetSnapshot { get; set; }
        public Func<object> ToJSON { get; set; }
    }
}
