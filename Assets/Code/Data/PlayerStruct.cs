using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public struct PlayerStruct
    {
        #region Fields
        
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(0, 100)] private float _acceleration;

        #endregion


        #region Properties

        public float Speed { get => _speed; set => _speed = value; }
        public float Acceleration { get => _acceleration; set => _acceleration = value; }

        #endregion
    }
}