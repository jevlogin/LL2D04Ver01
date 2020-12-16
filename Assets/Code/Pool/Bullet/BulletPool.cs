using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class BulletPool : GenericObjectPool<Bullet>
    {
        public BulletPool(Pool<Bullet> pool, PlayerInitialization playerInitialization) : base(pool, playerInitialization)
        {
            Pool.Prefab = Resources.Load<Bullet>(ManagerPath.BULLET_PATH);
        }
    }
}