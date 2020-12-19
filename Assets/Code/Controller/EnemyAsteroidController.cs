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

        public EnemyAsteroidController(EnemyAsteroidInitialization enemyAsteroidInitialization, Transform transformPlayer)
        {
            _enemyAsteroidInitialization = enemyAsteroidInitialization;

            _transformPlayer = transformPlayer;

            _listAsteroids = _enemyAsteroidInitialization.EnemyPool.GetList();

            for (int i = 0; i < _listAsteroids.Count; i++)
            {
                _listAsteroids[i].MoveToPlayerDirection = _transformPlayer.position - _listAsteroids[i].transform.position;
                var vectorSpawnPosition = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0.0f) * Random.Range(1, 10);
                _listAsteroids[i].transform.localPosition = vectorSpawnPosition;
                _listAsteroids[i].gameObject.SetActive(true);
            }
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
                /*****************************/
                //_offset = _transformPlayer.position - _listAsteroids[i].transform.position;

                Vector3 desiredPosition = _listAsteroids[i].transform.position + _listAsteroids[i].MoveToPlayerDirection;
                Vector3 smooth = Vector3.Lerp(_listAsteroids[i].transform.position, desiredPosition, deltaTime * 0.05f);
                _listAsteroids[i].transform.position = smooth;
            }
        }
    }
}