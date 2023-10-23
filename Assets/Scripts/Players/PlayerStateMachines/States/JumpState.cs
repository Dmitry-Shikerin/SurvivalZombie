using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;
using StateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public class JumpState : StateBase
    {
        private readonly PlayerAnimationController _playerAnimationController;

        public JumpState(IEnumerable<ITransition> transitions, 
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
