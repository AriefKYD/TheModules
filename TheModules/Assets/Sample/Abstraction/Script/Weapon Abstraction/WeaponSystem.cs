using UnityEngine;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    /// <summary>
    /// Place this to any weapon and swap the weapon with Scriptable Object
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        public SO_BaseWeapon currentWeapon;
        [SerializeField] private SpriteRenderer s_weaponSprite;
        private void Awake()
        {
            currentWeapon.Controller = this;
        }
        public void Attack()
        {

            if (currentWeapon)
                currentWeapon.Attack();
        }

        public void SwapWeapon(SO_BaseWeapon _weapon)
        {
            currentWeapon = _weapon;
            s_weaponSprite.sprite = currentWeapon.s_weapon;
        }
    }
}