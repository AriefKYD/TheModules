using UnityEngine;

namespace FallenWing.Module.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Charge Shot Weapon", menuName = "SO/Weapon Type/Charge")]
    public class SO_ChargeShot : SO_BaseWeapon
    {

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

        public override void Reload()
        {
        }
    }
}