﻿using UnityEngine;

namespace JevLogin
{
    internal class EnemyInitialization : IInitialization
    {
        private EnemyFactory _enemyFactory;
        private CompositeMove _enemy;

        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _enemy = new CompositeMove();
        }

        public GameObject GetEnemy()
        {
            return _enemyFactory.CreateEnemy();
        }

        public void Initialization()
        {

        }
    }
}