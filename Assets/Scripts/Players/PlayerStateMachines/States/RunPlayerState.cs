using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public class RunPlayerState : PlayerStateBase
    {
        private readonly PlayerAnimationController _playerAnimationController;

        public RunPlayerState(IEnumerable<IPlayerTransition> transitions,
            PlayerAnimationController playerAnimationController) : base(transitions)
        {
            _playerAnimationController = playerAnimationController;
        }

        public override void Enter()
        {
            _playerAnimationController.PlayRun();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
