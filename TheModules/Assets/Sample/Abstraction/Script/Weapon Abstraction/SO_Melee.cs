using UnityEngine;
using FallenWing.Example.Global;
namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Melee Weapon", menuName = "SO/Weapon Type/Melee")]
    public class SO_Melee : SO_BaseWeapon
    {
        float _currentDelay;
        Bullet _cachedBullet;
        public override void Attack()
        {

            if (Input.GetMouseButtonDown(0))
            {
                _currentDelay = weaponStat.fireRate;
                Debug.Log($"Melee {name} With {weaponStat.damage}");
                _cachedBullet = BulletManager.Instance.GetBullet(weaponStat.prefabsBullet);
                if (_cachedBullet != null)
                {
                    _cachedBullet.transform.position = Controller.T_weaponTip.position;
                    _cachedBullet.transform.localRotation = Controller.T_weaponPivot.localRotation;
                    _cachedBullet.Shot(weaponStat);
                }

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