namespace XState.State
{
    public class BaseActions<TContext, TExpressionEvent, TAction, TEvent>
        : SingleOrArray<BaseAction<TContext, TExpressionEvent, TAction, TEvent>>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : EventObject
        where TAction : BaseActionObject
    { }
}
