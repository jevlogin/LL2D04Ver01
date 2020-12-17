using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
    {
        //TODO - переделать на ScriptableOb
        public int DamageAttack;
        public float MoveSpeed;

        private float _lifeTime;
        private float _maxLifeTime = 5.0f;

        private void OnEnable()
        {
            _lifeTime = 0.0f;
        }

        //TODO - убрать MonoBehaviour
        public void Update()
        {
            float deltaTime = Time.deltaTime;

            if (TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.velocity = transform.up * MoveSpeed;
            }
            else
            {
                transform.Translate(Vector2.up * MoveSpeed * deltaTime);
            }

            _lifeTime += deltaTime;
            if (_lifeTime > _maxLifeTime)
            {
                BulletPool.Instance.ReturnToPool(this);
            }
        }
    }
}