using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class Asteroid : Enemy, IDie
    {
        public event Action<int> OnDieChange = delegate (int value) { };
        public Vector3 MoveToPlayerDirection { get; set; }
        public float TimeDoNewCoordinate { get; set; }
        private int _score = 5;

        private void OnEnable()
        {
            TimeDoNewCoordinate = 0.0f;
        }

        public void DependencyInjectHealth(HealthPoint healthPoint)
        {
            HealthPoint = healthPoint;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Bullet>())
            {
                EnemyAsteroidPool.Instance.ReturnToPool(this);
                Debug.Log("Астероид был уничтожен");
                Die(_score);
                //TODO не совсем правильно, потому что не верно происходит обработка астероидов
            }
        }

        public void Die(int value)
        {
            OnDieChange.Invoke(value);
        }
    }
}