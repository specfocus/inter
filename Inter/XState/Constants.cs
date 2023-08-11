using System.Collections.Generic;

public class ActivityMap
{
    // Define your ActivityMap properties here
}

public class Types
{
    // Define your DefaultGuardType enum here
}

public static class Constants
{
    public const string STATE_DELIMITER = ".";
    public static readonly ActivityMap EMPTY_ACTIVITY_MAP = new ActivityMap();
    public static readonly Types.DefaultGuardType DEFAULT_GUARD_TYPE = Types.DefaultGuardType.xstate_guard;
    public const string TARGETLESS_KEY = "";
}
