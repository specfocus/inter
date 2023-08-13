namespace XState.State.Actions
{
    public interface ISendAction<TContext, TExpressionEvent, TEvent>
        : IAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
    }

    public class SendAction<TContext, TExpressionEvent, TEvent> : Action<TContext, TExpressionEvent, TEvent>, ISendAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
        public override ActionType Type => ActionTypes.Send.Value;
    }
}
