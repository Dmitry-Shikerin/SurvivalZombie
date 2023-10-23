using StateMachines.States.Context;

namespace Players.PlayerStateMachines.States.Contexts
{
    public class ContextChangeWeapon : IContext
    {
        public ContextChangeWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public Weapon Weapon { get; }
    }
}