namespace XState.State
{
    public class MachineOptions<TContext, TEvent>
    {
        public Dictionary<string, Action> Actions { get; set; }
        public Dictionary<string, Func<bool>> Guards { get; set; }
        public Dictionary<string, Func<TContext, object>> Services { get; set; }
        public Dictionary<string, Action<TContext>> Activities { get; set; }
        public Dictionary<string, int> Delays { get; set; }
        // Add other properties as needed
    }
}
