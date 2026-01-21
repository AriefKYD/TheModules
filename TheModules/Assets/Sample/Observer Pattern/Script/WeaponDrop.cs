using UnityEngine;
using FallenWing.Example.Abstraction.WeaponSystemSO;
namespace FallenWing.Example.ObserverPattern
{
    public class  WeaponDrop : MonoBehaviour
    {
        [SerializeField] private SO_BaseWeapon weapon;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                EventManager.OnDoSwapWeapon(weapon);
                gameObject.SetActive(false);
            }
        }
    }
}