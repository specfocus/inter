using System.Text.RegularExpressions;

namespace XState.State
{
    internal static partial class Utils
    {
        [GeneratedRegex("^(done|error)\\.")]
        private static partial Regex BuiltInEventRegex();

        public static bool IsBuiltInEvent(string eventType)
        {
            return BuiltInEventRegex().IsMatch(eventType);
        }
    }
}
