using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenWing.Example.Global;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{

    /// <summary>
    /// This Base class is abstract so we can define each functionality for individual weapon next
    /// Such Single shot, spread, auto and Etc..
    /// </summary>
    public abstract class SO_BaseWeapon : ScriptableObject
    {
        public WeaponSystem Controller { get; set; }

        public WeaponStat weaponStat;

        public abstract bool CanAttack();
        public abstract void Attack();
        public abstract void Reload();
    }

    [System.Serializable]
    public struct WeaponStat
    {
        public Sprite s_weapon;
        public float damage;
        public float fireRate;
        public float bulletSpeed;
        public int magazine;
        public int maxAmmo;
        public Sprite s_bullet;
        public Bullet prefabsBullet;
    }


    public interface IDamageable
    {
        public void Damaged(float _amount);
    }
}