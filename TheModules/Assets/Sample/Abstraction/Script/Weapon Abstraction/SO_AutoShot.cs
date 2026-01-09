using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FallenWing.Example.Global;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Auto Shot Weapon", menuName = "SO/Weapon Type/Auto")]
    public class SO_AutoShot : SO_BaseWeapon
    {
        public bool canReload = true;
        float _currentDelay;
        Bullet _cachedBullet;
        public override void Attack()
        {
            if (Input.GetMouseButton(0))
            {
                _currentDelay = weaponStat.fireRate;
                Debug.Log("Auto Shot");
                _cachedBullet = BulletManager.Instance.GetBullet(weaponStat.prefabsBullet);
                if (_cachedBullet != null)
                {
                    _cachedBullet.transform.position = Controller.T_weaponTip.position;
                    _cachedBullet.transform.localRotation = Controller.T_weaponPivot.localRotation;
                    _cachedBullet.Shot(weaponStat);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
                Reload();

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
            if (canReload)
            {
                Debug.Log("Reload");
                Controller.StartCoroutine(DelayToReload());
                canReload = false;
            }
            else
            {
                Debug.Log("Cant Reload");
            }
        }

        IEnumerator DelayToReload()
        {
            Debug.Log("Wait Reload");
            yield return new WaitForSeconds(2f);
            canReload = true;
        }
    }
}