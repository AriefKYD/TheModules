using UnityEngine;
namespace FallenWing.Module.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Single Shot Weapon", menuName = "SO/Weapon Type/Single")]
    public class SO_SingleShot : SO_BaseWeapon
    {
        public override void Attack()
        {
            if (Input.GetMouseButtonDown(0))
                Debug.Log("Single Shot");
        }

        public override void Reload()
        {
        }
    }
}