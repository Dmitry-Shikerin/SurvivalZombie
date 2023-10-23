using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;
using StateMachines.Transitions;
using UnityEngine;

namespace Players.PlayerStateMachines.States
{
    public class NoGunState : StateBase
    {
        public NoGunState(List<ITransition> transitions) : base(transitions)
        {
            
        }

        public override void Enter()
        {
            Debug.Log("NoGanState Activity");
        }

        public override void Exit()
        {
            
        }
    }
}
