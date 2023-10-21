using System;
using Players.PlayerStateMachines.States;
using Players.PlayerStateMachines.States.Contexts;

namespace Players.PlayerStateMachines.Transitions
{
    public abstract class PlayerTransitionBase<TState, TContext> : IPlayerTransition<TContext> 
        where TState : PlayerStateBase 
        where TContext : IContext
    {
        public Type NextState { get; } = typeof(TState);

        public abstract bool CanTransit(TContext context);
    }
}
