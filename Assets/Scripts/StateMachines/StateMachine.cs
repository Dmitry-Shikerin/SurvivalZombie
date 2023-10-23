using System;
using System.Collections.Generic;
using Players.PlayerStateMachines.States;
using StateMachines.States.Context;

namespace StateMachines
{
    public class StateMachine
    {
        private Dictionary<Type, StateBase> _states;

        private StateBase _current;

        public StateMachine(Dictionary<Type, StateBase> states)
        {
            _states = states;
        }
    
        public void Update<T>(T context) where T : IContext
        {
            if (_current.TryGetNextState(context, out Type state) == false)
            {
                return;
            }
        
            MoveNextState(state);
        }

        private void MoveNextState(Type nextState)
        {
            if (_states.ContainsKey(nextState) == false)
                throw new KeyNotFoundException("Состояние не найдено в Dictionary : " + nextState.Name);
        
            _current?.Exit();
            _current = _states[nextState];
            _current.Enter();
        }

        public void Start<T>() where T : StateBase
        {
            MoveNextState(typeof(T));
        }
    }
}
