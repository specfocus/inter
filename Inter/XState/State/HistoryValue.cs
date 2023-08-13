namespace XState.State
{
    public interface HistoryValue
    {
        Dictionary<string, HistoryValue> States { get; set; }

        StateValue Current { get; set; }
    }
}
