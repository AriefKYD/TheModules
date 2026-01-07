using UnityEngine;
using FallenWing.Module.ObjectPooler;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    public class Bullet : MonoBehaviour,IPoolableObject
    {
        [SerializeField] private SpriteRenderer s_bulletSprite;
        private float lifeTime =1f;
        private float speed;
        private float damage;
        private const string bulletKey = "Bullet";
        public string KeyPool => bulletKey;

        public GameObject GameObjectPool => gameObject;

        public Transform TransformObj => transform;

        public void Shot(WeaponStat _wpStat)
        {
            damage= _wpStat.damage;
            speed = _wpStat.bulletSpeed;
            s_bulletSprite.sprite = _wpStat.s_bullet;
        }

        public void SimulateMovement()
        {
            transform.position += transform.right * speed *Time.deltaTime;
            lifeTime-=Time.deltaTime;
            if (lifeTime < 0)
            {
                BulletManager.Instance.ReturnBullet(this);
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable _damagable = collision.GetComponent<IDamageable>();
            if (_damagable != null)
            {
                _damagable.Damaged(damage);
            }
        }

        public void ResetValue()
        {
            lifeTime = 0.5f;
            gameObject.SetActive(true);
        }

        public void ReturningToPool()
        {
            gameObject.SetActive(false);
        }
    }

}