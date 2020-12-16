using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour, IExecute
    {
        public int DamageAttack = 10;
        public float MoveSpeed = 300.0f;

        private float _lifeTime;
        private float _maxLifeTime = 5.0f;

        private void OnEnable()
        {
            _lifeTime = 0.0f;
        }

        public void Execute(float deltaTime)
        {
            transform.Translate(Vector3.up * MoveSpeed * deltaTime);
            _lifeTime += deltaTime;
            if (_lifeTime > _maxLifeTime)
            {
                BulletPool.Instance.ReturnToPool(this);
            }
        }

        //TODO - убрать MonoBehaviour
        public void Update()
        {
            float deltaTime = Time.deltaTime;
            
            GetComponent<Rigidbody2D>().velocity = transform.up * MoveSpeed;

            _lifeTime += deltaTime;
            if (_lifeTime > _maxLifeTime)
            {
                BulletPool.Instance.ReturnToPool(this);
            }
        }
    }
}