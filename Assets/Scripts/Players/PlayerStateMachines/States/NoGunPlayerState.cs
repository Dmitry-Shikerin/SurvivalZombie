using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;
using UnityEngine;

namespace Players.PlayerStateMachines.States
{
    public class NoGunPlayerState : PlayerStateBase
    {
        public NoGunPlayerState(List<IPlayerTransition> transitions) : base(transitions)
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
