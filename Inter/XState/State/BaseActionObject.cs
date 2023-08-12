using XState.Dynamic;
namespace XState.State
{
    public class BaseActionObject : Record
    {
        public BaseActionObject(string type) => Type = type;

        public string Type { get; }
    }
}
