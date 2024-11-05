using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Weapons
{
    public enum WeaponType
    {
        MELEE = 4,
        BOW = 6,
        SWORD = 2,
        KNIFE
    }

    public class WeaponManager
    {

        Player player;
        int bullets;
        string weaponType;

        Weapon[] equipedWeapons = new Weapon[3];
        int actualWeaponIndex;

        Dictionary<WeaponType, Weapon> _possibleWeapons = new Dictionary<WeaponType, Weapon>();

        Weapon _fistWeapon;

        public WeaponManager(Player myPlayer, Weapon fistWeapon)
        {
            _fistWeapon = fistWeapon;

            _possibleWeapons.Add(WeaponType.MELEE, new Weapon());
            _possibleWeapons.Add(WeaponType.BOW, new Weapon());
            _possibleWeapons.Add(WeaponType.SWORD, new Weapon());
            _possibleWeapons.Add(WeaponType.KNIFE, new Weapon());
        }

        public void Shoot()
        {
            _fistWeapon.Attack();
        }

        public void AddWeapon(WeaponType weaponType, Weapon newWeapon)
        {
            if (_possibleWeapons.ContainsKey(weaponType))
            {
                _possibleWeapons[weaponType] = newWeapon;
            }
            else 
            {
                _possibleWeapons.Add(weaponType, newWeapon);
            }
        }

        public void ChangeWeapon(WeaponType weaponType)
        {
            var number = (int)weaponType;
            var weaponType2 = (WeaponType)number;

            _fistWeapon = _possibleWeapons[weaponType];
        }
    }
}


