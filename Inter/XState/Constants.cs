namespace XState
{
    internal static class Constants
    {
        public const string STATE_DELIMITER = ".";
        public static readonly ActivityMap EMPTY_ACTIVITY_MAP = new ActivityMap();
        public static readonly DefaultGuardType DEFAULT_GUARD_TYPE = DefaultGuardType.xstate_guard;
        public const string TARGETLESS_KEY = "";
    }
}
