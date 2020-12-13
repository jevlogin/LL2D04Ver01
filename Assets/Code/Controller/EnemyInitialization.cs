using System;
using UnityEngine;


namespace JevLogin
{
    internal sealed class EnemyInitialization
    {
        private EnemyPool _enemyPool;
        private Enemy _enemy;

        public EnemyInitialization(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;

            _enemy = enemyPool.GetEnemy("Asteroid");
            _enemy.transform.position = Vector2.one;
            _enemy.gameObject.SetActive(true);
        }

        public Enemy GetEnemy()
        {
            return _enemy;
        }

        internal void AddPoolEnemy(EnemyPool enemyPool)
        {

        }
    }
}