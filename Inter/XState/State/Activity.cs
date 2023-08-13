using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XState.State.Actions;

namespace XState.State
{
    public interface Activity<TContext, TEvent> where TContext : class where TEvent : Event
    {
        public string Id { get; }

        public string Type { get; }
    }

    public class ActivityDefinition<TContext, TEvent> : ActionObject<TContext, TEvent, TEvent, BaseActionObject>, Activity<TContext, TEvent>
        where TContext : class where TEvent : Event
    {
        public string Id { get; set; }

        public string Type { get; set; }
    }
}
