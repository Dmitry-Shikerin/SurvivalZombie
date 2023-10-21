using System;
using Players.PlayerStateMachines.States;
using Players.PlayerStateMachines.States.Contexts;

namespace Players.PlayerStateMachines.Transitions
{
    public  class PlayerTransition<TState, TContext> : IPlayerTransition<TContext>
        where TState : PlayerStateBase
        where TContext : IContext
    {
        private readonly Func<TContext, bool> _condition;

        public PlayerTransition(Func<TContext, bool> condition)
        {
            _condition = condition;
        }

        public Type NextState { get; } = typeof(TState);

        public bool CanTransit(TContext context)
        {
            return _condition.Invoke(context);
        }
    }
}
