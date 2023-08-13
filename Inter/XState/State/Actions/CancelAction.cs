using static XState.State.SCXML;

namespace XState.State.Actions
{
    public interface ICancelAction<TContext, TExpressionEvent, TEvent>
        : IAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
        string SendId { get; }
    }

    public class CancelAction<TContext, TExpressionEvent, TEvent> : ICancelAction<TContext, TExpressionEvent, TEvent>
        where TContext : class
        where TExpressionEvent : Event
        where TEvent : Event
    {
        public ActionType Type => ActionTypes.Cancel.Value;

        public string SendId { get; set; }
    }
}
