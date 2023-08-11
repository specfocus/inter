using XState.Extensions;

namespace XState.State
{
    internal class DefaultGuardType
    {
        public DefaultGuardType(string value) { Value = value; }

        public string Value { get; private set; }


        public static DefaultGuardType xstate_guard = new DefaultGuardType("xstate.guard");

        public override bool Equals(object? obj)
        {
            if (base.Equals(obj)) {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() == typeof(string))
            {
                return obj.Equals(Value);
            }
            
            if (obj.GetType() == typeof(DefaultGuardType)) {
                return obj.GetFieldValue<string>("Value")?.Equals(Value) ?? false;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString() => Value;
    }
}
