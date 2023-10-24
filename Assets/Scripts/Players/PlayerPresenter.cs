using System;
using System.Collections.Generic;
using Players.PlayerStateMachines;
using Players.PlayerStateMachines.States;
using Players.PlayerStateMachines.States.Contexts;
using Players.PlayerStateMachines.Transitions;
using StateMachines;
using StateMachines.Transitions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Players
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationController _playerAnimationController;

        private Weapon _currentWeapon;
        
        private void Start()
        {
            PlayerWeaponChanger weaponChanger = new PlayerWeaponChanger();

            _currentWeapon = weaponChanger.CurrentWeapon;
            
            #region StateMachine

            List<ITransition> noGunTransitions = new List<ITransition>()
            {
                new TransitionToNoScopeState(),
                new Transition<NoScopeState, ContextChangeWeapon>
                    (Condition),
                // new PlayerTransitionToJumpState
            };

            List<ITransition> noScopeTransitions = new List<ITransition>()
            {
                new TransitionToNoGunState(),
            };

            Dictionary<Type, StateBase> states = new Dictionary<Type, StateBase>()
            {
                //     [typeof(NoGunPlayerState)] = new NoGunPlayerState(noGunTransitions),
                //     [typeof(NoScopePlayerState)] = new NoScopePlayerState(noScopeTransitions, _animationControllerSecond),
                [typeof(IdleState)] = new IdleState
                (
                    new ITransition[]
                    {
                        new Transition<JumpState, ContextInput>
                        (
                            input => input.Key == KeyCode.Space
                        ),
                        // new PlayerTransition<RunPlayerState, InputContext>
                        // (
                        //     input => input.Key == 
                        //     ),
                    },
                    _playerAnimationController
                ),
            };

            StateMachine stateMachine = new StateMachine(states);

            stateMachine.Start<NoGunState>();
            //нужно передать оружие
            stateMachine.Update(new ContextChangeWeapon(_currentWeapon));
            stateMachine.Update(new ContextChangeWeapon(null));

            #endregion
        }

        private void Update()
        {
        }

        private bool Condition(ContextChangeWeapon context)
        {
            return context.Weapon != null;
        }
    }
}
