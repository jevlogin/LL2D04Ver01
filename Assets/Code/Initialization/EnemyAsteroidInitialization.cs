using UnityEngine;


namespace JevLogin
{
    internal sealed class EnemyAsteroidInitialization : IInitialization
    {
        #region Fields

        private EnemyAsteroidPool _enemyPool;
        private Enemy _enemyAsteroid;

        #endregion


        #region Properties

        public EnemyAsteroidInitialization(EnemyAsteroidPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public Enemy Asteroid => _enemyAsteroid;

        public EnemyAsteroidPool EnemyPool => _enemyPool;

        #endregion


        #region IInitialization

        public void Initialization()
        {
            _enemyAsteroid = _enemyPool.Get();
            _enemyAsteroid.transform.position = Vector2.one;
            _enemyAsteroid.gameObject.SetActive(true);
        }

        #endregion
    }
}