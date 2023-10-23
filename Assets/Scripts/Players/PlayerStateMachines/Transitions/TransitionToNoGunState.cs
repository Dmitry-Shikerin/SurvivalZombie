using Players.PlayerStateMachines.States;
using Players.PlayerStateMachines.States.Contexts;
using StateMachines.Transitions;

namespace Players.PlayerStateMachines.Transitions
{
    public class
        TransitionToNoGunState : TransitionBase<NoGunState, ContextChangeWeapon>
    {
        public override bool CanTransit(ContextChangeWeapon context)
        {
            return context.Weapon == null;
        }
    }
}
