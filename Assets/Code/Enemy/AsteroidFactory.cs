using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(HealthPoint healthPoint)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.DependencyInjectHealth(healthPoint);

            return enemy;
        }
    }
}