using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyAsteroidInitialization : IInitialization
    {
        #region Fields

        private EnemyAsteroidPool _enemyPool;
        private List<Asteroid> _listAsteroids;


        #endregion


        #region Properties

        public EnemyAsteroidInitialization(EnemyAsteroidPool enemyPool)
        {
            _enemyPool = enemyPool;
            _listAsteroids = new List<Asteroid>();
            _listAsteroids.AddRange(_enemyPool.GetList());
        }

        public Enemy Asteroid { get; private set; }

        public EnemyAsteroidPool EnemyPool => _enemyPool;

        #endregion


        #region IInitialization

        public void Initialization()
        {
            Asteroid = _enemyPool.Get();
            //Asteroid.transform.position = Vector2.one;
            //Asteroid.gameObject.SetActive(true);
        }

        #endregion
    }
}