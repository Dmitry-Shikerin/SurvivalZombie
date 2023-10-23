using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;
using StateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public class IdleState : StateBase
    {
        private readonly PlayerAnimationController _playerAnimationController;

        public IdleState(IEnumerable<ITransition> transitions, 
            PlayerAnimationController playerAnimationController) : base(transitions)
        {
            _playerAnimationController = playerAnimationController;
        }
        
        public override void Enter()
        {
            _playerAnimationController.PlayIdle();
        }

        public override void Exit()
        {
            
        }
    }
}
