using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        private Transform _rootPool;
        private HealthPoint _healthPoint;

        public HealthPoint HealthPoint
        {
            get
            {
                if (_healthPoint.Current <= 0.0f)
                {
                    //ReturnToPool();
                    EnemyAsteroidPool.Instance.ReturnToPool(this as Asteroid);
                }
                return _healthPoint;
            }

            protected set => _healthPoint = value;
        }

        private void ReturnToPool()
        {
            transform.localPosition = Vector2.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }


        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(ManagerName.POOL_ASTEROIDS);
                    _rootPool = find == null ? null : find.transform;
                }
                return _rootPool;
            }
        }

        public static Asteroid CreateAsteroidEnemy(HealthPoint healthPoint)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>(ManagerPath.ASTEROID_PATH));

            enemy.HealthPoint = healthPoint;

            return enemy;
        }

        public static Ship CreateShipEnemy(HealthPoint healthPoint)
        {
            var ship = Instantiate(Resources.Load<Ship>(ManagerPath.ENEMY_PATH_SHIP));

            ship.HealthPoint = healthPoint;

            return ship;
        }
    }
}