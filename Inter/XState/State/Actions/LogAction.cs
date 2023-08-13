namespace XState.State.Actions
{
    public interface ILogAction<TContext, TExpressionEvent, TEvent>
        : IAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
    }

    public class LogAction<TContext, TExpressionEvent, TEvent> : ILogAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
        public ActionType Type => ActionTypes.Log.Value;
    }
}
