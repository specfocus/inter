﻿namespace XState.State.Actions
{
    public class Delay<TContext, TEvent>
        where TContext : class
        where TEvent : Event
    {
        public static implicit operator Delay<TContext, TEvent>(int value) => new(value);


        public static implicit operator int?(Delay<TContext, TEvent> delay) => delay.Value;

        public Delay(int value) => Value = value;

        public Delay(DelayExpr<TContext, TEvent> expr) => Expr = expr;

        public int? Value { get; }

        public DelayExpr<TContext, TEvent>? Expr { get; }
    }

    public interface ISendAction<TContext, TEvent, TSentEvent>
        : IAction<TContext, TEvent, TSentEvent>
        where TContext : class
        where TSentEvent : Event
        where TEvent : Event
    {
        object To { get; set; } // You might need to define ActorRef and ExprWithMeta

        TSentEvent Event { get; set; }

        Delay<TContext, TEvent> Delay { get; set; } // You might need to define DelayExpr

        string Id { get; set; }
    }

    public class SendAction<TContext, TEvent, TSentEvent> : Action<TContext, TEvent, TSentEvent>, ISendAction<TContext, TEvent, TSentEvent>
        where TContext : class
        where TSentEvent : Event
        where TEvent : Event
    {
        public override ActionType Type => ActionTypes.Send.Value;
    }
}
