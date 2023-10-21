using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public class NoScopePlayerState : PlayerStateBase
    {
        private readonly PlayerAnimationController _playerAnimationController;

        public NoScopePlayerState(List<IPlayerTransition> transitions, 
            PlayerAnimationController playerAnimationController) : base(transitions)
        {
            _playerAnimationController = playerAnimationController;
        }
        
        public override void Enter()
        {
            _playerAnimationController.PlayNoScope();
        }

        public override void Exit()
        {
            
        }
    }
}
