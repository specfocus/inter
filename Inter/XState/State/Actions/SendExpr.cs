namespace XState.State.Actions
{
    public interface SCXMLEventMeta<TEvent>
        where TEvent : Event
    {
        SCXML.Event<TEvent> Event { get; set; }
    }

    public delegate T ExprWithMeta<TContext, TEvent, T>(TContext context, TEvent @event, SCXMLEventMeta<TEvent> meta)
        where TContext : class
        where TEvent : Event;

    public class SendExpr<TContext, TEvent, TSentEvent>
        where TContext : class
        where TEvent : Event
        where TSentEvent : Event
    {
    }
}
