using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public struct PlayerStruct
    {
        #region Fields

        [SerializeField] private BulletPool bulletPool;

        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(0, 100)] private float _acceleration;
        [SerializeField, Range(0, 100)] private int _healthPoint;
        [SerializeField, Range(0, 1000)] private int _force;

        #endregion


        #region Properties

        public float Speed { get => _speed; set => _speed = value; }
        public float Acceleration { get => _acceleration; set => _acceleration = value; }
        public int HealthPoint { get => _healthPoint; set => _healthPoint = value; }
        public int Force { get => _force; set => _force = value; }

        public BulletPool GetBulletPool()
        {
            return bulletPool;
        }

        public void SetBulletPool(BulletPool value)
        {
            bulletPool = value;
        }

        #endregion
    }
}