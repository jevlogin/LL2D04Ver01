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
                    EnemyAsteroidPool.Instance.ReturnToPool(this as Asteroid);
                }
                return _healthPoint;
            }

            protected set => _healthPoint = value;
        }

       
    }
}