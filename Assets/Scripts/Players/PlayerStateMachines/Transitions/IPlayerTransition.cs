using System;
using Players.PlayerStateMachines.States.Contexts;

namespace Players.PlayerStateMachines.Transitions
{
    public interface IPlayerTransition
    {
    }

    public interface IPlayerTransition<in T> : IPlayerTransition where T : IContext
    {
        public Type NextState { get; }

        public bool CanTransit(T context);
    }
}