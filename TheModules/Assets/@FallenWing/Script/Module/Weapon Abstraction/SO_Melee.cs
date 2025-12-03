using UnityEngine;
namespace FallenWing.Module.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Melee Weapon", menuName = "SO/Weapon Type/Melee")]
    public class SO_Melee : SO_BaseWeapon
    {
        float _currentDelay;
        public override void Attack()
        {

            if (_currentDelay <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _currentDelay = weaponStat.fireRate;
                    Debug.Log($"Melee {name} With {weaponStat.damage}");
                }
            }
            _currentDelay -= Time.deltaTime;

        }

        public override void Reload()
        {
        }
    }
}