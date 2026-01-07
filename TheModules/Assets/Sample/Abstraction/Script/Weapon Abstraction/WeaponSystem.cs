using UnityEngine;
using FallenWing.Core;
using System.Collections.Generic;
using FallenWing.Module.ObjectPooler;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    /// <summary>
    /// Place this to any weapon and swap the weapon with Scriptable Object
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        public SO_BaseWeapon currentWeapon;
        [SerializeField] SO_BaseWeapon[] weaponList;
        [SerializeField] private Transform t_weaponPivot,t_weaponTip;
        [SerializeField] private SpriteRenderer s_weaponSprite;

        public Transform T_weaponPivot { get => t_weaponPivot; }
        public Transform T_weaponTip { get => t_weaponTip;  }

        private void Awake()
        {
            currentWeapon.Controller = this;
        }
        public void Attack()
        {
            if (currentWeapon)
                currentWeapon.Attack();
        }

        public void SwapWeapon(int _val)
        {
            currentWeapon = weaponList[_val];
            currentWeapon.Controller = this;
            s_weaponSprite.sprite = currentWeapon.s_weapon;
        }
    }

}