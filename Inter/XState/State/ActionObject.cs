namespace XState.State
{
    public interface ActionObject<TContext, TExpressionEvent, TEvent, TAction>
        where TExpressionEvent : EventObject
        where TEvent : EventObject
        where TAction : BaseActionObject
    {
        string Type { get; }
    }
}