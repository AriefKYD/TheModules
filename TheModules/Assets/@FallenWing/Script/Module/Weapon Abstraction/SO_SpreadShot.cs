using UnityEngine;
namespace FallenWing.Module.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Spread Shot Weapon", menuName = "SO/Weapon Type/Spread")]
    public class SO_SpreadShot : SO_BaseWeapon
    {
        public override void Attack()
        {
            if (Input.GetMouseButtonDown(0))
                Debug.Log("Spread Shot");
        }

        public override void Reload()
        {
        }
    }
}