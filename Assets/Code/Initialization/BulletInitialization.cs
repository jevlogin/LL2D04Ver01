using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class BulletInitialization : IInitialization
    {
        #region Fields

        private BulletPool _bulletPool;
        private Bullet _bullet;

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
            _bulletPool.PlayerInitialization.GetPlayerModel().PlayerStruct.SetBulletPool(_bulletPool);
            _bullet = _bulletPool.GetBullet(ManagerName.BULLET);
            //_bullet.gameObject.SetActive(true);
        }

        #endregion


        #region Methods

        public Bullet GetBullet()
        {
            return _bullet;
        }

        public BulletPool GetBulletPool()
        {
            return _bulletPool;
        }

        #endregion
    }
}