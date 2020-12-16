using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class BulletPool
    {
        private readonly Dictionary<string, Queue<GameObject>> _bulletsPool;

        private Transform _rootPool;

        [SerializeField] private Pool _pool;

        public Pool Pool { get => _pool; private set => _pool = value; }

        public PlayerInitialization PlayerInitialization { get; }

        public Dictionary<string, Queue<GameObject>> BulletsPool => _bulletsPool;


        public BulletPool(PlayerInitialization playerInitialization, Pool pool)
        {
            PlayerInitialization = playerInitialization;

            Transform playerTransform = playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            Pool = pool;

            Pool.Prefab = Resources.Load<Bullet>(ManagerPath.BULLET_PATH).gameObject;

            _bulletsPool = new Dictionary<string, Queue<GameObject>>();

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

        internal GameObject GetBulletByName(string name)
        {
            GameObject result;

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

        private GameObject GetBullet(Queue<GameObject> bulletsPool)
        {
            var result = bulletsPool.FirstOrDefault(a => !a.gameObject.activeSelf);

            if (result == null)
            {

                for (int i = 0; i < Pool.Size; i++)
                {
                    var instantiate = UnityEngine.Object.Instantiate(Pool.Prefab);
                    ReturnToPool(instantiate.transform);
                    bulletsPool.Enqueue(instantiate);
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

        private Queue<GameObject> GetHashSetFromDictionary(string name)
        {
            return BulletsPool.ContainsKey(name) ? BulletsPool[name] : BulletsPool[name] = new Queue<GameObject>();
        }
    }
}