using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class BulletPool
    {
        private readonly Dictionary<string, HashSet<Bullet>> _bulletsPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public BulletPool(int capacityPool, Transform playerTransform)
        {
            _bulletsPool = new Dictionary<string, HashSet<Bullet>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                if (playerTransform == null)
                {
                    _rootPool = new GameObject(ManagerName.POOL_BULLETS).transform;
                }
                else
                {
                    _rootPool = new GameObject(ManagerName.POOL_BULLETS).transform;
                    _rootPool.SetParent(playerTransform);
                }
            }
        }

        internal Bullet GetBullet(string name)
        {
            Bullet result;

            result = new Bullet();
            return result;
        }
    }
}