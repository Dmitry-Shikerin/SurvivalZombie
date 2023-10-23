using System;
using Players.PlayerStateMachines.States;
using StateMachines.States.Context;

namespace StateMachines.Transitions
{
    public abstract class TransitionBase<TState, TContext> : ITransition<TContext> 
        where TState : StateBase 
        where TContext : IContext
    {
        public Type NextState { get; } = typeof(TState);

        public abstract bool CanTransit(TContext context);
    }
}
