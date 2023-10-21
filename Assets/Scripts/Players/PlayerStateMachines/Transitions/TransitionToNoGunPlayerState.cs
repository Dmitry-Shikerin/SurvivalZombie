
using Players.PlayerStateMachines.States;
using Players.PlayerStateMachines.States.Contexts;

namespace Players.PlayerStateMachines.Transitions
{
    public class
        TransitionToNoGunPlayerState : PlayerTransitionBase<NoGunPlayerState, ContextChangeWeapon>
    {
        public override bool CanTransit(ContextChangeWeapon context)
        {
            return context.Weapon == null;
        }
    }
}
