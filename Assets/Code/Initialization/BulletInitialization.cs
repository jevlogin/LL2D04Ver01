namespace JevLogin
{
    public sealed class BulletInitialization
    {
        #region Fields

        private BulletPool _bulletPool;

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


        #region Methods

        public BulletPool GetBulletPool()
        {
            return _bulletPool;
        }

        #endregion
    }
}