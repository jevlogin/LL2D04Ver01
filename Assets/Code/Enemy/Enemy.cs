using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        private HealthPoint healthPoint;

        public HealthPoint HealthPoint { get => healthPoint; protected set => healthPoint = value; }

        public static Asteroid CreateAsteroidEnemy(HealthPoint healthPoint)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.HealthPoint = healthPoint;

            return enemy;
        }
    }
}