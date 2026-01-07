using FallenWing.Core;
using System.Collections.Generic;
using FallenWing.Module.ObjectPooler;

namespace FallenWing.Example.Abstraction.WeaponSystemSO
{
    public class BulletManager : BaseSingleton<BulletManager> 
    {
        private List<Bullet> aliveBullets = new List<Bullet>();
        private const string BulletKey = "Bullet";
        private Bullet _cachedBullet;
        public Bullet GetBullet(Bullet _prefabBullet)
        {
            _cachedBullet = ObjectPooler.Instance.GetPoolableObject<Bullet>(BulletKey, _prefabBullet);
            if (_cachedBullet != null)
            {
                aliveBullets.Add(_cachedBullet);
            }
            return _cachedBullet;
        }

        public void ReturnBullet(Bullet _ctx)
        {
            aliveBullets.Remove(_ctx);
            ObjectPooler.Instance.ReturnObj(BulletKey, _ctx);
        }

        private void Update()
        {
            for (int i = 0; i < aliveBullets.Count; i++) 
            {
                aliveBullets[i].SimulateMovement();
            }

        }
    }

}