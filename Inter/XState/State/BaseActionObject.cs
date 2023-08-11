using XState.Dynamic;
using static XState.State.SCXML;

namespace XState.State
{
    public class BaseActionObject : Record
    {
        public BaseActionObject(string type) => Type = type;

        public string Type { get; }
    }
}
