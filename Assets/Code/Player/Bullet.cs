using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
    {
        #region Fields

        //TODO - переделать на ScriptableOb
        public int DamageAttack;
        private float _lifeTime;

        public float LifeTime { get => _lifeTime; set => _lifeTime = value; }

        #endregion

        #region UnityMethods

        private void OnEnable()
        {
            LifeTime = 0.0f;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Asteroid>())
            {
                Debug.Log("Collision detect Asteroid");
                BulletPool.Instance.ReturnToPool(this);
                //TODO не совсем правильно, потому что не верно происходит обработка пуль
            }
        }
        #endregion
    }
}