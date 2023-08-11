using System;
using System.Collections.Generic;

namespace XState.State
{
    public interface EventObject { /* Define EventObject interface */ }
    public interface BaseActionObject { /* Define BaseActionObject interface */ }
    public interface DefaultContext { /* Define DefaultContext interface */ }
    public interface StateSchema { /* Define StateSchema interface */ }
    public interface ServiceMap { /* Define ServiceMap interface */ }
    public interface TypegenConstraint { /* Define TypegenConstraint interface */ }

    public interface Typestate<TContext>
    {
        /* Define Typestate interface */
    }

    public interface MachineConfig<TContext, TStateSchema, TEvent, TServiceMap, TTypesMeta>
    {
        /* Define MachineConfig interface */
    }

    public class IS_PRODUCTION
    {
        /* Define IS_PRODUCTION class */
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

    public class StateMachine<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TTypesMeta>
    {
        /* Define StateMachine class */
    }

    public static class StateMachineExtensions
    {
        public static StateMachine<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TTypesMeta>
            CreateMachine<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TTypesMeta>(
            MachineConfig<TContext, TStateSchema, TEvent, BaseActionObject, TServiceMap, TTypesMeta> config,
            object options // Update with correct type for options
        )
        {
            if (!IS_PRODUCTION && !config.PredictableActionArguments && !Warned)
            {
                Warned = true;
                Console.WriteLine(
                    "It is highly recommended to set 'predictableActionArguments' to 'true' when using 'createMachine'. " +
                    "https://xstate.js.org/docs/guides/actions.html"
                );
            }

            return new StateNode<TContext, TStateSchema, TEvent, TTypestate, TServiceMap, TTypesMeta>(
                config,
                options,
                default // Update with appropriate initial context
            );
        }

        private static bool Warned = false;
    }
}