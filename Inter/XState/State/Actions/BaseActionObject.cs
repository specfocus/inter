using XState.Dynamic;
using static XState.State.SCXML;

namespace XState.State.Actions
{
    public class BaseActionObject : Record, IAction<object, Event, Event>
    {
        public BaseActionObject(ActionType type) => Type = type;

        public ActionType Type { get; }
    }
}
