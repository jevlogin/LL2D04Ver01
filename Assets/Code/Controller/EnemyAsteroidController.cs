using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyAsteroidController : IExecute, ICleanup
    {
        private EnemyAsteroidInitialization _enemyAsteroidInitialization;
        private Transform _transformPlayer;
        private List<Asteroid> _listAsteroids;
        private ICollisionDetect _collisionPlayer;

        private float _endTimer = 5.0f;
        private int _numberOfElementsInTheWave;
        private float _lifeTimeAsteroid = 2.0f;

        public EnemyAsteroidController(EnemyAsteroidInitialization enemyAsteroidInitialization, Transform transformPlayer, ICollisionDetect collisionPlayer)
        {
            _enemyAsteroidInitialization = enemyAsteroidInitialization;

            _transformPlayer = transformPlayer;

            _listAsteroids = new List<Asteroid>();

            //_numberOfElementsInTheWave = _enemyAsteroidInitialization.EnemyPool.Pool.Size;
            _numberOfElementsInTheWave = 2;
            _listAsteroids = _enemyAsteroidInitialization.EnemyPool.GetList();
            _collisionPlayer = collisionPlayer;
            _collisionPlayer.CollisionDetectChange += ThereWasACollisionWithThePlayer;
        }

        private void ThereWasACollisionWithThePlayer(Collider2D colliderPlayer)
        {
            if (colliderPlayer.GetComponent<Asteroid>())
            {
                Debug.Log("обработка события в классе EnemyAsteroidController");
            }
        }

        private void SpawnWave()
        {
            for (int i = 0; i < _numberOfElementsInTheWave; i++)
            {
                var asteroid = _enemyAsteroidInitialization.EnemyPool.Get();
                asteroid.MoveToPlayerDirection = _transformPlayer.position - asteroid.transform.position;

                var vectorSpawnPosition = GetNewVector3(asteroid, _transformPlayer);

                asteroid.transform.position = vectorSpawnPosition;

                _listAsteroids.Add(asteroid);

                asteroid.gameObject.SetActive(true);
            }
        }

        private Vector2 GetNewVector3(Asteroid asteroid, Transform transformPlayer)
        {
            var res = Random.insideUnitSphere * 20;
            res.z = 0.0f;
            res += transformPlayer.position;

            return res;
        }

        public void Execute(float deltaTime)
        {
            if (_lifeTimeAsteroid > 0)
            {
                _lifeTimeAsteroid -= deltaTime;
            }
            if (_lifeTimeAsteroid <= 0)
            {
                SpawnWave();
                _lifeTimeAsteroid = 5.0f;
            }

            for (int i = 0; i < _listAsteroids.Count; i++)
            {
                _listAsteroids[i].TimeDoNewCoordinate += deltaTime;
                if (_listAsteroids[i].TimeDoNewCoordinate >= _endTimer)
                {
                    _endTimer = Random.Range(5.0f, 15.0f);
                    _listAsteroids[i].MoveToPlayerDirection = _transformPlayer.position - _listAsteroids[i].transform.position;
                    _listAsteroids[i].TimeDoNewCoordinate = 0;
                }

                Vector3 desiredPosition = _listAsteroids[i].transform.position + _listAsteroids[i].MoveToPlayerDirection;
                Vector3 smooth = Vector3.Lerp(_listAsteroids[i].transform.position, desiredPosition, deltaTime * 0.05f);
                //_listAsteroids[i].transform.position = smooth;
                _listAsteroids[i].gameObject.GetComponent<Rigidbody2D>().velocity = smooth * 0.01f;
            }
        }

        public void Cleanup()
        {
            _collisionPlayer.CollisionDetectChange -= ThereWasACollisionWithThePlayer;
        }
    }
}