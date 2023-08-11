namespace XState.State
{
    internal static partial class Utils
    {
        public static Dictionary<TKey, TValueOutput> MapValues<TKey, TValueInput, TValueOutput>(
                Dictionary<TKey, TValueInput> dictionary,
                Func<TValueInput, TValueOutput> mapFunc)
        {
            return dictionary.ToDictionary(
                kvp => kvp.Key,
                kvp => mapFunc(kvp.Value)
            );
        }
    }
}