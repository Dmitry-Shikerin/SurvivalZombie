
    using Players.PlayerStateMachines.States;
    using Players.PlayerStateMachines.States.Contexts;

    namespace Players.PlayerStateMachines.Transitions
    {
        public class TransitionToNoScopePlayerState : PlayerTransitionBase<NoScopePlayerState, ContextChangeWeapon>
        {
            public override bool CanTransit(ContextChangeWeapon context)
            {
                return context.Weapon != null;
            }
        }
    }