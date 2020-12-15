﻿using System.Collections;
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

        #endregion


        #region IInitialization

        public void Initialization()
        {
            _bulletObject = _bulletPool.GetBulletByName(ManagerName.BULLET);
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