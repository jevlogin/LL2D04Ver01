using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class BulletPool : GenericObjectPool<Bullet>
    {
        public BulletPool(Pool<Bullet> pool) : base(pool)
        {
        }
    }
}