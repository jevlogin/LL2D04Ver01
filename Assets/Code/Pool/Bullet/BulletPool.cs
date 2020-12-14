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
        [SerializeField] private int _capacityPool;
        private Transform _rootPool;

        public int CapacityPool => _capacityPool;

        public PlayerInitialization PlayerInitialization { get; }

        public BulletPool(PlayerInitialization playerInitialization)
        {
            PlayerInitialization = playerInitialization;
            Transform playerTransform = playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            _capacityPool = playerInitialization.GetPlayerModel().PlayerStruct.GetBulletPool().CapacityPool;

            _bulletsPool = new Dictionary<string, HashSet<Bullet>>();
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
                    _rootPool.localPosition = new Vector2(0, 0.5f);
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
                    throw new ArgumentOutOfRangeException(nameof(name), name, "Не предусмотрен в программе");
            }
            return result;
        }

        private Bullet GetAsteroid(HashSet<Bullet> bulletsPool)
        {
            var result = bulletsPool.FirstOrDefault(a => !a.gameObject.activeSelf);

            if (result == null)
            {
                var bullet = Resources.Load<Bullet>(ManagerPath.BULLET_PATH);

                for (int i = 0; i < CapacityPool; i++)
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