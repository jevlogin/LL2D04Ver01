using UnityEngine;


namespace JevLogin
{
    internal sealed class EnemyInitialization : IInitialization
    {
        #region Fields

        private EnemyPool _enemyPool;
        private Enemy _enemyAsteroid;
        private Enemy _enemyShip;

        #endregion


        #region Properties

        public EnemyInitialization(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public Enemy Asteroid => _enemyAsteroid;

        public Enemy EnemyShip => _enemyShip;

        public EnemyPool EnemyPool => _enemyPool;

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