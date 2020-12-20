using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyAsteroidController : IExecute
    {
        private EnemyAsteroidInitialization _enemyAsteroidInitialization;
        private Transform _transformPlayer;
        private List<Asteroid> _listAsteroids;
        private Vector3 _offset;
        private float _endTimer = 5.0f;
        private int _numberOfElementsInTheWave;

        public EnemyAsteroidController(EnemyAsteroidInitialization enemyAsteroidInitialization, Transform transformPlayer)
        {
            _enemyAsteroidInitialization = enemyAsteroidInitialization;

            _transformPlayer = transformPlayer;

            _listAsteroids = new List<Asteroid>();

            _numberOfElementsInTheWave = _enemyAsteroidInitialization.EnemyPool.Pool.Size;
            SpawnWave();
        }

        private void SpawnWave()
        {
            for (int i = 0; i < _numberOfElementsInTheWave; i++)
            {
                var asteroid = _enemyAsteroidInitialization.EnemyPool.Get();
                asteroid.MoveToPlayerDirection = _transformPlayer.localPosition - asteroid.transform.localPosition;

                var vectorSpawnPosition = GetNewVector3(asteroid, _transformPlayer);

                Debug.Log($"Уникальный вектор относительно игрока {asteroid.transform.position}");

                asteroid.transform.position = vectorSpawnPosition;

                _listAsteroids.Add(asteroid);

                asteroid.gameObject.SetActive(true);
            }
        }

        private Vector2 GetNewVector3(Asteroid asteroid, Transform transformPlayer)
        {
            var res = Random.insideUnitSphere * 20;
            res.z = 0.0f;
            var vector = res - transformPlayer.position;

            return res;
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _listAsteroids.Count; i++)
            {
                _listAsteroids[i].TimeDoNewCoordinate += deltaTime;
                if (_listAsteroids[i].TimeDoNewCoordinate >= _endTimer)
                {
                    _listAsteroids[i].TimeDoNewCoordinate = 0;
                    _endTimer = Random.Range(3.0f, 10.0f);
                    _listAsteroids[i].MoveToPlayerDirection = _transformPlayer.position - _listAsteroids[i].transform.position;
                }

                Vector3 desiredPosition = _listAsteroids[i].transform.position + _listAsteroids[i].MoveToPlayerDirection;
                Vector3 smooth = Vector3.Lerp(_listAsteroids[i].transform.position, desiredPosition, deltaTime * 0.05f);
                _listAsteroids[i].transform.position = smooth;
            }
        }
    }
}