using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public class JumpPlayerState : PlayerStateBase
    {
        private readonly PlayerAnimationController _playerAnimationController;

        public JumpPlayerState(IEnumerable<IPlayerTransition> transitions, 
            PlayerAnimationController playerAnimationController) : base(transitions)
        {
            _playerAnimationController = playerAnimationController;
        }

        public override void Enter()
        {
            _playerAnimationController.PlayJump();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
