namespace XState.State.Actions
{
    public interface IStopAction<TContext, TExpressionEvent, TEvent>
        : IAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
    }

    public class StopAction<TContext, TExpressionEvent, TEvent> : IStopAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
        public ActionType Type => ActionTypes.Stop.Value;
    }
}
