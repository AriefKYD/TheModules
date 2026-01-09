using UnityEngine;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Charge Shot Weapon", menuName = "SO/Weapon Type/Charge")]
    public class SO_ChargeShot : SO_BaseWeapon
    {
        private float _currentDelay;
        bool _charged;
        public override void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Charge Bow");
                _charged = true;
            }
            if (_charged && Input.GetMouseButtonUp(0))
            {
                Debug.Log("Shot Bow");

                _charged = false;
            }

        }
        public override bool CanAttack()
        {
            if (_currentDelay <= 0)
            {
                return true;
            }
            _currentDelay -= Time.deltaTime;
            return false;
        }

        public override void Reload()
        {
        }
    }
}