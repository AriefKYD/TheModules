using UnityEngine;
namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Single Shot Weapon", menuName = "SO/Weapon Type/Single")]
    public class SO_SingleShot : SO_BaseWeapon
    {
        Bullet _cachedBullet;
        private float _currentDelay;

        public override void Attack()
        {
            if (_currentDelay <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _currentDelay = weaponStat.fireRate;
                    Debug.Log("Single Shot");
                    _cachedBullet = BulletManager.Instance.GetBullet(weaponStat.prefabsBullet);
                    if (_cachedBullet != null)
                    {
                        _cachedBullet.transform.position = Controller.T_weaponTip.position;
                        _cachedBullet.transform.localRotation = Controller.T_weaponPivot.localRotation;
                        _cachedBullet.Shot(weaponStat);
                    }
                }
            }
            _currentDelay -= Time.deltaTime;
        }

        public override void Reload()
        {
        }
    }
}