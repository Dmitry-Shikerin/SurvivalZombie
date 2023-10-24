using System.Collections.Generic;
using UnityEngine;

namespace Players
{
    public class PlayerWeaponChanger
    {
        //TODO исправить скрипт PlayerWeaponChanger
        private int _health;
        private List<Weapon> _weapons;
        private PlayerAnimationController _playerAnimationController;

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

        public PlayerWeaponChanger()
        {
            _currentWeapon = _weapons[_currentWeaponNumber];
            _currentHealth = _health;
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
    }
}