using FallenWing.Core;
using UnityEngine;
using UnityEngine.UI;
using FallenWing.Example.Global;
using FallenWing.Example.Abstraction.WeaponSystemSO;
using System;
namespace FallenWing.Example.ObserverPattern
{
    public class EventManager : BaseSingleton<EventManager>
    {
        public delegate void OnSwapWeapon(SO_BaseWeapon weapon);
        public static event OnSwapWeapon onSwapWeapon;

        public static void OnDoSwapWeapon(SO_BaseWeapon weapon)
        {
            onSwapWeapon?.Invoke(weapon);
        }
    }


    /// <summary>
    /// Makes GUI weapon to change the grayscale according to chosen weapon
    /// </summary>
    public class GUI_Weapon : MonoBehaviour 
    {
        [SerializeField] private Image i_weapons;

        private void OnEnable()
        {
            EventManager.onSwapWeapon += EventManager_onSwapWeapon;
        }
        private void OnDisable()
        {
            EventManager.onSwapWeapon -= EventManager_onSwapWeapon;
        }
        private void EventManager_onSwapWeapon(SO_BaseWeapon weapon)
        {
            i_weapons.sprite = weapon.weaponStat.s_weapon;
        }
    }
}