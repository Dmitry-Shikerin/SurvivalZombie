using System.Collections.Generic;
using Players.PlayerStateMachines.Transitions;
using StateMachines.Transitions;

namespace Players.PlayerStateMachines.States
{
    public class NoScopeState : StateBase
    {
        private readonly PlayerAnimationController _playerAnimationController;

        public NoScopeState(List<ITransition> transitions, 
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
