using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyAsteroidController : ILateExecute
    {
        private EnemyAsteroidInitialization _enemyAsteroidInitialization;
        private Transform _transformPlayer;
        private List<Asteroid> _listAsteroids;
        private Vector3 _offset;

        private float _time = 0.0f;
        private float _endTime = 1.0f;

        public EnemyAsteroidController(EnemyAsteroidInitialization enemyAsteroidInitialization, Transform transformPlayer)
        {
            _enemyAsteroidInitialization = enemyAsteroidInitialization;

            _transformPlayer = transformPlayer;

            _listAsteroids = _enemyAsteroidInitialization.EnemyPool.GetList();

            for (int i = 0; i < _listAsteroids.Count; i++)
            {
                _listAsteroids[i].gameObject.SetActive(true);
                var newVector2 = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20)) * Random.Range(1, 20);

                _listAsteroids[i].transform.position = newVector2;
            }
        }

        public void LateExecute(float deltaTime)
        {
            _time += deltaTime;
            
            for (int i = 0; i < _listAsteroids.Count; i++)
            {
                if (_time >= _endTime)
                {
                    _offset = _transformPlayer.position - _listAsteroids[i].transform.position;
                    _time = 0;
                }
                Vector3 desiredPosition = _listAsteroids[i].transform.position + _offset;
                Vector3 smooth = Vector3.Lerp(_listAsteroids[i].transform.position, desiredPosition, deltaTime);
                _listAsteroids[i].transform.position = smooth;
            }
        }
    }
}