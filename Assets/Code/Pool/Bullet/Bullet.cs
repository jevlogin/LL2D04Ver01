using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
    {
        //TODO - переделать на ScriptableOb
        public int DamageAttack = 10;
        public float MoveSpeed = 2.0f;

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

            //GetComponent<Rigidbody2D>().velocity = transform.up * MoveSpeed * deltaTime;

            transform.Translate(Vector2.up * MoveSpeed );

            _lifeTime += deltaTime;
            if (_lifeTime > _maxLifeTime)
            {
                BulletPool.Instance.ReturnToPool(this);
            }
        }
    }
}