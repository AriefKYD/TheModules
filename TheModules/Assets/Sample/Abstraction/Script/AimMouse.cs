using FallenWing.Example.Abstraction.WeaponSystemSO;
using UnityEngine;
namespace FallenWing.Example.Abstraction
{
    public class AimMouse : MonoBehaviour
    {
        [SerializeField] private Transform t_weaponPivot;
        [SerializeField] private Camera camRef;
        [SerializeField] private SpriteRenderer s_weapon;
        private Vector3 direction;

        public void FlipWeapon(bool _flag)
        {
            s_weapon.flipY = _flag;
        }
        public void Aim()
        {
            direction = UnityEngine.Input.mousePosition - camRef.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            t_weaponPivot.transform.localRotation = Quaternion.AngleAxis(angle/* - 90*/, Vector3.forward);
            FlipWeapon(Mathf.Abs(angle) > 90f);
        }
    }
}
