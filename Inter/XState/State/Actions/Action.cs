namespace XState.State.Actions
{
    public interface IAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
        ActionType Type { get; }
    }

    public class Action<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
        ActionType Type { get; }
    }

    public class Actions<TContext, TExpressionEvent, TEvent> : List<Action<TContext, TExpressionEvent, TEvent>>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
    }
}
