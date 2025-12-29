using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{

    /// <summary>
    /// This Base class is abstract so we can define each functionality for individual weapon next
    /// Such Single shot, spread, auto and Etc..
    /// </summary>
    public abstract class SO_BaseWeapon : ScriptableObject
    {
        public Sprite s_weapon;
        public WeaponSystem Controller { get; set; }

        public WeaponStat weaponStat;
        public abstract void Attack();
        public abstract void Reload();
    }

    [System.Serializable]
    public struct WeaponStat
    {
        public float damage;
        public float fireRate;
        public int magazine;
        public int maxAmmo;
    }
}