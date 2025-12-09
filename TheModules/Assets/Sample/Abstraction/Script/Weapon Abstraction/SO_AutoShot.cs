using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    [CreateAssetMenu(fileName = "SO_Auto Shot Weapon", menuName = "SO/Weapon Type/Auto")]
    public class SO_AutoShot : SO_BaseWeapon
    {
        public bool canReload = true;
        public override void Attack()
        {
            if (Input.GetMouseButton(0))
                Debug.Log("Auto Shot");
            if (Input.GetKeyDown(KeyCode.R))
                Reload();
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