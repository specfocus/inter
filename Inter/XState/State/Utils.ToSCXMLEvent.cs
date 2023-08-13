namespace XState.State
{
    internal static partial class Utils
    {
        public static SCXML.Event<TEvent> ToSCXMLEvent<TEvent>(SCXML.Event<TEvent> eventValue, SCXML.Event<TEvent>? scxmlEvent = null)
            where TEvent : Event
        {
            if (eventValue is string || (eventValue is SCXML.Event<TEvent> && ((SCXML.Event<TEvent>)eventValue).IsSCXMLType))
            {
                return (SCXML.Event<TEvent>)Convert.ChangeType(eventValue, typeof(SCXML.Event<TEvent>));
            }

            var eventObject = ToEventObject((SCXML.Event<TEvent>)eventValue);

            dynamic @event = new SCXML.Event<TEvent>();
            {
                @event.name = eventObject.Type;
                @event.data = eventObject;
                @event.$$type = "scxml";
                @event.type = "external";
                // ...scxmlEvent
            };
            return @event;
        }
    }
}
