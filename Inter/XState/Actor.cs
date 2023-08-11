using System;
using System.Collections.Generic;

namespace YourNamespace
{
    public interface Actor<TContext, TEvent> : IObservable<TContext>
    {
        string Id { get; }
        void Send(TEvent @event);
        void Stop();
        object ToJSON();
        InvokeDefinition<TContext, TEvent> Meta { get; }
        object State { get; set; }
        bool Deferred { get; }
    }

    public class ActorRef<TContext, TEvent> : IObserver<TContext>
    {
        public string Id { get; }
        public Action<TEvent> Send { get; set; }
        public Action Stop { get; set; }
        public Func<object> GetSnapshot { get; set; }
        public Func<object> ToJSON { get; set; }
    }

    public interface InvokeDefinition<TContext, TEvent>
    {
        // Define InvokeDefinition properties here
    }

    public interface StateMachine<TContext, TState, TEvent, TEmitted>
    {
        // Define StateMachine properties here
    }

    public class SCXML
    {
        public class Event<TEvent>
        {
            // Define SCXML Event properties here
        }
    }

    public class ServiceScope
    {
        public static T Provide<T>(T defaultValue, Func<T> callback)
        {
            // Implement ServiceScope.Provide method
            return default;
        }
    }

    public static class ActorExtensions
    {
        public static bool IsActor(object item)
        {
            try
            {
                return item is ActorRef<object, object> actorRef && actorRef.Send != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsSpawnedActor(object item)
        {
            return IsActor(item) && item is ActorRef<object, object> actorRef && actorRef.Id != null;
        }
    }

    public class Program
    {
        public static ActorRef<object, object> CreateNullActor(string id)
        {
            return new ActorRef<object, object>
            {
                Id = id,
                Send = @event => { },
                GetSnapshot = () => null,
                ToJSON = () => new { Id = id }
            };
        }

        public static ActorRef<object, object> CreateInvocableActor<TC, TE>(
            InvokeDefinition<TC, TE> invokeDefinition,
            StateMachine<TC, object, TE, object> machine,
            TC context,
            SCXML.Event<TE> _event
        )
        {
            var invokeSrc = ToInvokeSource(invokeDefinition.Src);
            var serviceCreator = machine?.Options?.Services?.GetValueOrDefault(invokeSrc.Type);
            var resolvedData = invokeDefinition.Data != null
                ? MapContext(invokeDefinition.Data, context, _event)
                : null;
            var tempActor = serviceCreator != null
                ? CreateDeferredActor((Spawnable)serviceCreator, invokeDefinition.Id, resolvedData)
                : CreateNullActor(invokeDefinition.Id);

            tempActor.Meta = invokeDefinition;

            return tempActor;
        }

        public static ActorRef<object, object> CreateDeferredActor(Spawnable entity, string id, object data = null)
        {
            var tempActor = CreateNullActor(id);
            tempActor.Deferred = true;

            if (entity is Machine<object, object, object, object> machine)
            {
                var initialState = (tempActor.State = ServiceScope.Provide<object>(null,
                    () => (data != null ? machine.WithContext(data) : machine).InitialState));
                tempActor.GetSnapshot = () => initialState;
            }

            return tempActor;
        }

        public static InvokeSource ToInvokeSource(object src)
        {
            // Implement ToInvokeSource method
            return null;
        }

        public static object MapContext(object data, object context, object _event)
        {
            // Implement MapContext method
            return null;
        }

        public static void Main(string[] args)
        {
            // Your code here
        }
    }
}