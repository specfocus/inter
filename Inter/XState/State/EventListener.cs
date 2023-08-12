namespace XState.State
{
    public delegate void EventListener<TEvent>(Event @event) where TEvent : Event;
}
