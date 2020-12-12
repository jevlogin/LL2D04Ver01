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
                    _rootPool.localPosition = Vector2.zero;
                }
            }
        }

        internal Bullet GetBullet(string name)
        {
            Bullet result;

            switch (name)
            {
                case "Bullet":
                    result = GetAsteroid(GetListEnemies(name));
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(name), name, "Не предусмотрен в программе");
            }
            return result;
        }

        private Bullet GetAsteroid(HashSet<Bullet> bulletsPool)
        {
            var result = bulletsPool.FirstOrDefault(a => !a.gameObject.activeSelf);

            if (result == null)
            {
                var bullet = Resources.Load<Bullet>(ManagerPath.BULLET_PATH);

                for (int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = UnityEngine.Object.Instantiate(bullet);
                    ReturnToPool(instantiate.transform);
                    bulletsPool.Add(instantiate);
                }

                GetAsteroid(bulletsPool);
            }
            result = bulletsPool.FirstOrDefault(a => !a.gameObject.activeSelf);

            return result;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
            transform.localPosition = Vector2.zero;
        }

        private HashSet<Bullet> GetListEnemies(string name)
        {
            return _bulletsPool.ContainsKey(name) ? _bulletsPool[name] : _bulletsPool[name] = new HashSet<Bullet>();
        }
    }
}