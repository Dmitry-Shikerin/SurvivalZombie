using System;
using StateMachines.States.Context;

namespace StateMachines.Transitions
{
    public interface ITransition
    {
    }

    public interface ITransition<in T> : ITransition where T : IContext
    {
        public Type NextState { get; }

        public bool CanTransit(T context);
    }
}