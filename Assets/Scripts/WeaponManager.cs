using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class WeaponManager
    {
        //Player player;
        int bullets;
        string weaponType;

        Weapon[] equipedWeapons = new Weapon[3];
        int actualWeaponIndex;

        Weapon _fistWeapon;

        public WeaponManager(Player myPlayer, Weapon fistWeapon)
        {
            _fistWeapon = fistWeapon;
        }

        public void Shoot()
        {
            _fistWeapon.Attack();
        }

        public void AddWeapon(Weapon newWeapon)
        {

        }
    }
}

