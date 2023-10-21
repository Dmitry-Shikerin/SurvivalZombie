using System;
using System.Collections.Generic;
using Players.PlayerStateMachines.States.Contexts;
using Players.PlayerStateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public abstract class PlayerStateBase
    {
        private readonly IEnumerable<IPlayerTransition> _transitions;

        protected PlayerStateBase(IEnumerable<IPlayerTransition> transitions)
        {
            _transitions = transitions;
        }
        
        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }

        public bool TryGetNextState<T>(T context, out Type state) where T : IContext
        {
            foreach (IPlayerTransition transition in _transitions)
            {
                if (transition is IPlayerTransition<T> concreteTransition)
                {
                    if (concreteTransition.CanTransit(context))
                    {
                        state = concreteTransition.NextState;
                        
                        return true;
                    }
                }
            }

            state = null;
            
            return false;
        }
    }
}
