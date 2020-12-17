using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyAsteroidController : IExecute
    {
        private EnemyAsteroidInitialization _enemyAsteroidInitialization;
        private Transform _transformPlayer;
        private List<Asteroid> _listAsteroids;
        private float _speed = 10;

        public EnemyAsteroidController(EnemyAsteroidInitialization enemyAsteroidInitialization, Transform transformPlayer)
        {
            _enemyAsteroidInitialization = enemyAsteroidInitialization;
            
            _transformPlayer = transformPlayer;
            
            _listAsteroids = _enemyAsteroidInitialization.EnemyPool.GetList();

            for (int i = 0; i < _listAsteroids.Count; i++)
            {
                _listAsteroids[i].gameObject.SetActive(true);
                var newVector2 = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10)) * 2;

                _listAsteroids[i].transform.position = newVector2;
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _listAsteroids.Count; i++)
            {
                var direction = _transformPlayer.position - _listAsteroids[i].transform.position;
                _listAsteroids[i].GetComponent<Rigidbody2D>().velocity = direction * deltaTime * _speed;
            }
        }
    }
}