namespace XState.State
{
    public interface IHistoryValue
    {
        Dictionary<string, IHistoryValue> States { get; }

        StateValue Current { get; }
    }

    public class HistoryValue : IHistoryValue
    {
        public Dictionary<string, IHistoryValue> States { get; set; }

        public StateValue Current { get; set; }
    }
}
