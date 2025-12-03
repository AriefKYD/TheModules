using UnityEngine;

namespace FallenWing.Module.WeaponSystemSO
{
    /// <summary>
    /// Place this to any weapon and swap the weapon with Scriptable Object
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        public SO_BaseWeapon currentWeapon;
        private void Awake()
        {
            currentWeapon.Controller = this;
        }
        private void Update()
        {
            if (currentWeapon)
                currentWeapon.Attack();
        }
    }
}