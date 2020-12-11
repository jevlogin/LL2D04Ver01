using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public HealthPoint HealthPoint { get; private set; }

        public static Asteroid CreateAsteroidEnemy(HealthPoint healthPoint)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.HealthPoint = healthPoint;

            return enemy;
        }
    }
}