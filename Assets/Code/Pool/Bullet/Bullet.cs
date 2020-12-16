using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour, IExecute
    {
        public int DamageAttack = 10;
        public float MoveSpeed = 30.0f;

        private float _lifeTime;
        private float _maxLifeTime = 5.0f;

        private void OnEnable()
        {
            _lifeTime = 0.0f;
        }

        public void Execute(float deltaTime)
        {
            transform.Translate(Vector3.forward * MoveSpeed * deltaTime);
            _lifeTime += deltaTime;
            if (_lifeTime > _maxLifeTime)
            {
                BulletPool.Instance.ReturnToPool(this);
            }
        }
    }
}