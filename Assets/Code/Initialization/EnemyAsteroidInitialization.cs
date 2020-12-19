using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyAsteroidInitialization : IInitialization
    {
        #region Fields

        private EnemyAsteroidPool _enemyPool;

        #endregion


        #region Properties

        public EnemyAsteroidInitialization(EnemyAsteroidPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public EnemyAsteroidPool EnemyPool => _enemyPool;

        #endregion


        #region IInitialization

        public void Initialization()
        {
        }

        #endregion
    }
}