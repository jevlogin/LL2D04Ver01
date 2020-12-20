using UnityEngine;


namespace JevLogin
{
    public sealed class Asteroid : Enemy
    {
        public Vector3 MoveToPlayerDirection { get; set; }
        public float TimeDoNewCoordinate { get; set; }

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
            }
        }
    }
}