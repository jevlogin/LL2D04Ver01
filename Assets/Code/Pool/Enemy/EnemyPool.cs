﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    public sealed class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public EnemyPool(int capacityPool, string name)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(name).transform;
            }
        }

        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                case "Ship":
                    result = GetShip(GetListEnemies(type));
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            return result;
        }

        private Enemy GetShip(HashSet<Enemy> hashSets)
        {
            var enemy = hashSets.FirstOrDefault(s => !s.gameObject.activeSelf);
            if (enemy == null)
            {
                var ship = Resources.Load<Ship>(ManagerPath.ENEMY_PATH_SHIP);
                for (int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(ship);
                    ReturnToPool(instantiate.transform);
                    hashSets.Add(instantiate);
                }
                GetAsteroid(hashSets);
            }
            enemy = hashSets.FirstOrDefault(s => !s.gameObject.activeSelf);
            return enemy;
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                var asteroid = Resources.Load<Asteroid>(ManagerPath.ASTEROID_PATH);
                for (int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(asteroid);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }

                GetAsteroid(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector2.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        private HashSet<Enemy> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}