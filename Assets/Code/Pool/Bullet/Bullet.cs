using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
    {
        public int DamageAttack = 10;
        public float MoveSpeed = 200.0f;

        private float _lifeTime;
        private float _maxLifeTime = 5.0f;

        public float LifeTime { get => _lifeTime; private set => _lifeTime = value; }
        public float MaxLifeTime { get => _maxLifeTime; }

        private void OnEnable()
        {
            LifeTime = 0.0f;
        }
    }
}