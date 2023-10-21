using System;
using System.Collections.Generic;
using Players.PlayerStateMachines;
using Players.PlayerStateMachines.States;
using Players.PlayerStateMachines.States.Contexts;
using Players.PlayerStateMachines.Transitions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Players
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private PlayerAnimationController _playerAnimationController;

        //for guns
        private readonly string _mouseScrollWheel = "Mouse ScrollWheel";

        //for guns
        private Weapon _currentWeapon;
        private int _currentWeaponNumber = 0;
        private int _currentHealth;
        private float _changeWeapon;
        private float _currentValueChangeWeapon;

        //for guns
        public Weapon CurrentWeapon => _currentWeapon;

        private void Start()
        {
            _currentWeapon = _weapons[_currentWeaponNumber];
            _currentHealth = _health;

            #region StateMachine

            List<IPlayerTransition> noGunTransitions = new List<IPlayerTransition>()
            {
                new TransitionToNoScopePlayerState(),
                new PlayerTransition<NoScopePlayerState, ContextChangeWeapon>
                    (Condition),
                // new PlayerTransitionToJumpState
            };

            List<IPlayerTransition> noScopeTransitions = new List<IPlayerTransition>()
            {
                new TransitionToNoGunPlayerState(),
            };

            Dictionary<Type, PlayerStateBase> states = new Dictionary<Type, PlayerStateBase>()
            {
                //     [typeof(NoGunPlayerState)] = new NoGunPlayerState(noGunTransitions),
                //     [typeof(NoScopePlayerState)] = new NoScopePlayerState(noScopeTransitions, _animationControllerSecond),
                [typeof(IdlePlayerState)] = new IdlePlayerState
                (
                    new IPlayerTransition[]
                    {
                        new PlayerTransition<JumpPlayerState, ContextInput>
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

            PlayerStateMachine stateMachine = new PlayerStateMachine(states);

            stateMachine.Start<NoGunPlayerState>();
            //нужно передать оружие
            stateMachine.Update(new ContextChangeWeapon(_currentWeapon));
            stateMachine.Update(new ContextChangeWeapon(null));

            #endregion
        }

        private void Update()
        {
            ChangeWeapon();
        }

        private bool Condition(ContextChangeWeapon context)
        {
            return context.Weapon != null;
        }

        #region GunLogic

        public void NextWeapon()
        {
            _currentWeapon.gameObject.SetActive(false);

            if (_currentWeaponNumber == _weapons.Count - 1)
            {
                _currentWeaponNumber = 0;
            }
            else
            {
                _currentWeaponNumber++;
            }

            _currentWeapon = _weapons[_currentWeaponNumber];

            _currentWeapon.gameObject.SetActive(true);
        }

        public void PreviousWeapon()
        {
            _currentWeapon.gameObject.SetActive(false);

            if (_currentWeaponNumber == 0)
            {
                _currentWeaponNumber = _weapons.Count - 1;
            }
            else
            {
                _currentWeaponNumber--;
            }

            _currentWeapon = _weapons[_currentWeaponNumber];

            _currentWeapon.gameObject.SetActive(true);
        }

        private void ChangeWeapon()
        {
            //отслеживать переключение оружия
            _changeWeapon = Input.GetAxis(_mouseScrollWheel);

            //Листаем оружие в верх
            if (_changeWeapon > _currentValueChangeWeapon)
            {
                NextWeapon();
            }

            //листаем оружие вниз
            if (_changeWeapon < _currentValueChangeWeapon)
            {
                PreviousWeapon();
            }
        }

        #endregion

        public void OnEnemyDied(int revard)
        {
        }
    }
}
