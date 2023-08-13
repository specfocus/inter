namespace XState.State.Actions
{
    public delegate int DelayExpr<TContext, TEvent>(TContext context, TEvent @event, SCXMLEventMeta<TEvent> meta)
        where TContext : class
        where TEvent : Event;
}
