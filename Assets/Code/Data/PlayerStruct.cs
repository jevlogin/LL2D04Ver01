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

        public float Speed => _speed;
        public float Acceleration => _acceleration;

        #endregion
    }
}