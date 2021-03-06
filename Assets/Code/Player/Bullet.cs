﻿using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
    {
        #region Fields

        public int DamageAttack;

        public float LifeTime;

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