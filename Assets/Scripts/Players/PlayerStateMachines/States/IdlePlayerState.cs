using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public class IdlePlayerState : PlayerStateBase
    {
        private readonly PlayerAnimationController _playerAnimationController;

        public IdlePlayerState(IEnumerable<IPlayerTransition> transitions, 
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
