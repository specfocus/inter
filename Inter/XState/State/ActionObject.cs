namespace XState.State
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
        where TAction : BaseActionObject
        where TEvent : Event;

    /// <summary>
    /// Represents the full definition of an action, including its type and execution logic.
    /// </summary>
    public interface ActionObject<TContext, TExpressionEvent, TEvent, TAction>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
        where TAction : BaseActionObject
    {
        /// <summary>
        /// The type of the action.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// The implementation for executing the action.
        /// </summary>
        ActionFunction<TContext, TExpressionEvent, BaseActionObject, TEvent> Exec { get; set; }

        /// <summary>
        /// An internal signature that doesn't exist at runtime, but helps with inference.
        /// </summary>
        void DeprecatedSignature(TContext arg, TExpressionEvent ev, ActionMeta<TContext, TEvent, TAction> meta);
    }
}