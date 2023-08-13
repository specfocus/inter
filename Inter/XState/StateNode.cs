using XState.Actions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XState
{
    public interface IStateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta>
        where TContext : class
        where TStateSchema : IStateSchema<TContext>
        where TEvent : Event
        where TTypestate : Typestate<TContext>
        where TServiceMap : ServiceMap
        where TResolvedTypesMeta : TypegenDisabled
    {
        // The relative key of the state node, which represents its location in the overall state value.
        string Key { get; }

        // The unique ID of the state node.
        string Id { get; }

        // The machine"s own version.
        string Version { get; }

        // The type of this state node.
        string Type { get; }

        // The string path from the root machine node to this node.
        List<string> Path { get; }

        // The initial state node key.
        string Initial { get; }

        // The child state nodes.
        List<StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta>> States { get; }

        // The type of history on this state node.
        public string History { get; set; }

        // The action(s) to be executed upon entering the state node.
        List<ActionObject<TContext, TEvent>> OnEntry { get; }

        // The action(s) to be executed upon exiting the state node.
        List<ActionObject<TContext, TEvent>> OnExit { get; }

        // The activities to be started upon entering the state node.
        List<ActivityDefinition<TContext, TEvent>> Activities { get; }

        // Whether the state node is strict.
        bool Strict { get; }

        // The parent state node.
        StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta> Parent { get; }

        // The root machine node.
        StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta> Machine { get; }

        // The meta data associated with this state node.
        object Meta { get; }

        // The data sent with the "done.state._id_" event if this is a final state node.
        object DoneData { get; }

        // The string delimiter for serializing the path to a string.
        string Delimiter { get; }

        // The order this state node appears.
        int Order { get; }

        // The services invoked by this state node.
        List<InvokeDefinition<TContext, TEvent>> Invoke { get; }

        // The machine options associated with this state node.
        MachineOptions<TContext, TEvent> Options { get; }

        // The machine schema associated with this state node.
        MachineSchema<TContext, TEvent> Schema { get; }

        // A flag indicating this is a StateNode.
        bool XStateNode { get; }

        // The description of this state node.
        string Description { get; }
    }

    public class StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta>
        where TContext : class
        where TStateSchema : IStateSchema<TContext>
        where TEvent : Event
        where TTypestate : Typestate<TContext>
        where TServiceMap : ServiceMap
    {
        // Whether the state node is "transient".
        private bool _transient;

        // The relative key of the state node, which represents its location in the overall state value.
        public string Key { get; set; }

        // The unique ID of the state node.
        public string Id { get; set; }

        // The machine"s own version.
        public string Version { get; set; }

        // The type of this state node.
        public string Type { get; set; }

        // The string path from the root machine node to this node.
        public List<string> Path { get; set; }

        // The initial state node key.
        public string Initial { get; set; }

        // The child state nodes.
        public List<StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta>> States { get; set; }

        // The type of history on this state node.
        public string History { get; set; }

        // The action(s) to be executed upon entering the state node.
        public List<ActionObject<TContext, TEvent>> OnEntry { get; set; }

        // The action(s) to be executed upon exiting the state node.
        public List<ActionObject<TContext, TEvent>> OnExit { get; set; }

        // The activities to be started upon entering the state node.
        public List<ActivityDefinition<TContext, TEvent>> Activities { get; set; }

        // Whether the state node is strict.
        public bool Strict { get; set; }

        // The parent state node.
        public StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta> Parent { get; set; }

        // The root machine node.
        public StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TResolvedTypesMeta> Machine { get; set; }

        // The meta data associated with this state node.
        public object Meta { get; set; }

        // The data sent with the "done.state._id_" event if this is a final state node.
        public object DoneData { get; set; }

        // The string delimiter for serializing the path to a string.
        public string Delimiter { get; set; }

        // The order this state node appears.
        public int Order { get; set; } = -1;

        // The services invoked by this state node.
        public List<InvokeDefinition<TContext, TEvent>> Invoke { get; set; }

        // The machine options associated with this state node.
        public MachineOptions<TContext, TEvent> Options { get; set; }

        // The machine schema associated with this state node.
        public MachineSchema<TContext, TEvent> Schema { get; set; }

        // A flag indicating this is a StateNode.
        public bool XStateNode { get; set; } = true;

        // The description of this state node.
        public string Description { get; set; }

        // Private cache for internal state
        private class Cache
        {
            public Array<string> Events { get; set; }
            public Dictionary<StateNode<TContext>, StateValue> RelativeValue { get; set; }
            public StateValue InitialStateValue { get; set; }
            public State<TContext, TEvent> InitialState { get; set; }
            public TransitionDefinitionMap<TContext, TEvent> On { get; set; }
            public Array<TransitionDefinition<TContext, TEvent>> Transitions { get; set; }
            public Dictionary<string, Array<TransitionDefinition<TContext, TEvent>>> Candidates { get; set; }
            public Array<DelayedTransitionDefinition<TContext, TEvent>> DelayedTransitions { get; set; }
        }

        private Cache __cache = new Cache();

        // ID map for state nodes
        private Dictionary<string, StateNode<TContext, object, TEvent, object, object, object>> idMap = new Dictionary<string, StateNode<TContext, object, TEvent, object, object, object>>();

        // Tags associated with the state node
        public List<string> Tags { get; set; } = new List<string>();

        public StateNode(
            StateNodeConfig<TContext, TStateSchema, TEvent> config,
            MachineOptions<TContext, TEvent> options = null,
            Action<TContext>? contextGetter = null,
            StateNode<object, object, object, object, object, object> parent = null,
            string key = null
            )
        {
        }

        public class StateNode<TContext, TEvent, TStateSchema, TTypestate, TResolvedTypesMeta>
        {

            // Define StateNode class
            public List<string> NextEvents { get; }
        }

        public class StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TTypesMeta>
        {
            public StateNode(
                MachineConfig<TContext, TStateSchema, TEvent, BaseActionObject, TServiceMap, TTypesMeta> config,
                object options, // Update with correct type for options
                TContext initialContext
            )
            {
                /* Implement StateNode constructor */
            }
        }
    }
