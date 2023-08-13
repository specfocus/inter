namespace XState.State.Actions
{
    /// <summary>
    /// Represents the signature of an action function.
    /// </summary>
    public delegate void ActionFunction<TContext, TExpressionEvent, TAction, TEvent>(
        TContext arg,
        TExpressionEvent ev,
        ActionMeta<TContext, TEvent, TAction> meta
    )
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
        where TAction : BaseActionObject;
}
