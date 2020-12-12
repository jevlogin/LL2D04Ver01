using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
    {
        #region Fields

        [SerializeField] private int _damageAttack;

        #endregion


        #region Properties

        public int DamageAttack
        {
            get
            {
                if (_damageAttack <= 0)
                {
                    _damageAttack = 10;
                }
                return _damageAttack;
            }
        }

        #endregion
    }
}