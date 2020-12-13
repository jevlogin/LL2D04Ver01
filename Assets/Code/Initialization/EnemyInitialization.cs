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
            _enemyAsteroid = _enemyPool.GetEnemy(ManagerName.ASTEROID);
            _enemyAsteroid.transform.position = Vector2.one;
            _enemyAsteroid.gameObject.SetActive(true);

            _enemyShip = _enemyPool.GetEnemy("Ship");
            _enemyShip.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            _enemyShip.gameObject.SetActive(true);
        }

        #endregion
    }
}