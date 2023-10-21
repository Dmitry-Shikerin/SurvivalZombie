using System;
using System.Collections.Generic;
using Players.PlayerStateMachines.States;
using Players.PlayerStateMachines.States.Contexts;

namespace Players.PlayerStateMachines
{
    public class PlayerStateMachine
    {
        private Dictionary<Type, PlayerStateBase> _states;

        private PlayerStateBase _current;

        public PlayerStateMachine(Dictionary<Type, PlayerStateBase> states)
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

        public void Start<T>() where T : PlayerStateBase
        {
            MoveNextState(typeof(T));
        }
    }
}
