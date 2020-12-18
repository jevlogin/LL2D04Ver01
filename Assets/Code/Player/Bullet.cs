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

        #endregion
    }
}