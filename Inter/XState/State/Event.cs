namespace XState.State
{
    /**
     * The full definition of an event, with a string `type`.
     */
    public interface Event
    {
        /**
         * The type of event that is sent.
         */
        String Type { get; }
    }
}
