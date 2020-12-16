using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class BulletInitialization : IInitialization
    {
        #region Fields

        private BulletPool _bulletPool;
        private GameObject _bulletObject;

        #endregion


        #region Properties

        public BulletInitialization(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public BulletInitialization()
        {
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {

        }

        #endregion


        #region Methods

        public GameObject GetBullet()
        {
            return _bulletObject;
        }

        public BulletPool GetBulletPool()
        {
            return _bulletPool;
        }

        #endregion
    }
}