using UnityEngine;
using FallenWing.Example.Abstraction.WeaponSystemSO;
namespace FallenWing.Example.Abstraction
{
    public class DummyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float hP;
        [SerializeField] private float MaxHP;

        private float HP
        {
            get
            {
                return hP;
            }

            set
            {
                hP = value;
            }
        }
        public void Damaged(float _amount)
        {
            HP -= _amount;
        }
    }
    
}
