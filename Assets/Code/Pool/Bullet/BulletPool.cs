using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class BulletPool
    {
        private readonly Dictionary<string, HashSet<Bullet>> _bulletsPool;

        private Transform _rootPool;

        [SerializeField] private Pool _pool;

        public Pool Pool { get => _pool; private set => _pool = value; }

        public PlayerInitialization PlayerInitialization { get; }

        private List<Bullet> _poolsBullet;

        public BulletPool(PlayerInitialization playerInitialization, Pool pool)
        {
            PlayerInitialization = playerInitialization;

            Transform playerTransform = playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            _pool = pool;

            _bulletsPool = new Dictionary<string, HashSet<Bullet>>();
            _poolsBullet = new List<Bullet>();

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

        internal Bullet GetBulletByName(string name)
        {
            Bullet result;

            switch (name)
            {
                case ManagerName.BULLET:
                    result = GetBullet(GetHashSetFromDictionary(name));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, "Не предусмотрен в программе");
            }
            return result;
        }

        private Bullet GetBullet(HashSet<Bullet> bulletsPool)
        {
            var result = bulletsPool.FirstOrDefault(a => !a.gameObject.activeSelf);

            if (result == null)
            {
                _pool.Prefab = Resources.Load<Bullet>(ManagerPath.BULLET_PATH).gameObject;

                var bullet = _pool.Prefab.GetComponent<Bullet>();

                for (int i = 0; i < _pool.Size; i++)
                {
                    var instantiate = UnityEngine.Object.Instantiate(bullet);
                    ReturnToPool(instantiate.transform);
                    bulletsPool.Add(instantiate);
                }

                GetBullet(bulletsPool);
            }
            result = bulletsPool.FirstOrDefault(a => !a.gameObject.activeSelf);

            return result;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.gameObject.SetActive(false);
            transform.localRotation = Quaternion.identity;
            transform.SetParent(_rootPool);
            transform.localPosition = Vector2.zero;
        }

        private HashSet<Bullet> GetHashSetFromDictionary(string name)
        {
            return _bulletsPool.ContainsKey(name) ? _bulletsPool[name] : _bulletsPool[name] = new HashSet<Bullet>();
        }
    }
}