namespace XState.State
{
    public class StateNode<TContext, TEvent, TStateSchema, TTypestate, TResolvedTypesMeta>
    {
        public string Id { get; set; }

        // Define StateNode class
        public List<string> NextEvents { get; }
    }
}
