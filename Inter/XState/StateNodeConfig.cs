﻿using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using XState.Actions;

namespace XState
{
    /// <summary>
    /// Configuration for a state node.
    /// </summary>
    public interface StateNodeConfig<TContext, TStateSchema, TEvent, TAction>
        where TContext : class
        where TStateSchema : IStateSchema<TContext>
        where TEvent : Event
        where TAction : BaseActionObject
    {
        // The relative key of the state node
        string Key { get; set; }

        // The initial state node key
        string Initial { get; set; }

        // Deprecated parallel flag
        bool Parallel { get; set; }

        // The type of this state node
        string Type { get; set; }

        // Type of history for history state nodes
        string History { get; set; }

        // Mapping of state node keys to configurations
        StatesConfig<TContext, TStateSchema, TEvent, TAction> States { get; set; }

        // Services to invoke upon entering/exiting
        SingleOrArray<InvokeConfig<TContext, TEvent> | AnyStateMachine> Invoke { get; set; }

        // Mapping of event types to transitions
        TransitionsConfig<TContext, TEvent, TEvent> On { get; set; }

        // Actions to execute on entering the state node
        Actions<TContext, TEvent> OnEntry { get; set; }

        // Actions to execute on entering the state node
        BaseActions<TContext, TEvent, TEvent, TAction> Entry { get; set; }

        // Actions to execute on exiting the state node
        Actions<TContext, TEvent> OnExit { get; set; }

        // Actions to execute on exiting the state node
        BaseActions<TContext, TEvent, TEvent, TAction> Exit { get; set; }

        // Transitions to take on reaching final child state
        string OnDone { get; set; }

        // Delays and their transitions
        DelayedTransitions<TContext, TEvent> After { get; set; }

        // Transition to always take
        TransitionConfigOrTarget<TContext, TEvent> Always { get; set; }

        // Activities to start/stop
        SingleOrArray<Activity<TContext, TEvent>> Activities { get; set; }

        // Parent state node
        StateNode<TContext, IStateSchema<TContext>, TEvent> Parent { get; set; }

        // Strict mode flag
        bool Strict { get; set; }

        // Meta data associated with the state node
        object Meta { get; set; }

        // Data sent with "done.state._id_" event
        Mapper<TContext, TEvent, any> Data { get; set; }

        // Unique ID of the state node
        string Id { get; set; }

        // String delimiter for serializing path
        string Delimiter { get; set; }

        // Order of appearance in document
        int Order { get; set; }

        // Tags associated with the state node
        SingleOrArray<string> Tags { get; set; }

        // Whether to preserve action order
        bool PreserveActionOrder { get; set; }

        // Whether to use event directly in actions
        bool PredictableActionArguments { get; set; }

        // Text description of the state node
        string Description { get; set; }
    }
}
