using System;
using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerShooterController : IExecute, ICleanup
    {
        #region Fields

        private readonly PlayerInitialization _playerInitialization;
        private readonly Transform _barrel;
        private BulletInitialization _bulletInitialization;

        private IUserInputMouse _userInputMouse;

        private bool _valueChange;
        private float _refireTimer = 0.3f;
        private float _fireTimer;

        #endregion


        #region Properties

        public PlayerShooterController(IUserInputMouse userInputMouse, PlayerInitialization playerInitialization, BulletInitialization bulletInitialization)
        {
            _userInputMouse = userInputMouse;

            _playerInitialization = playerInitialization;
            _bulletInitialization = bulletInitialization;

            _barrel = _playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            _fireTimer = _refireTimer;
            _userInputMouse.MouseOnChange += BoolOnAxisMouseOnChange;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            _fireTimer += deltaTime;
            if (_fireTimer >= _refireTimer)
            {
                if (_valueChange)
                {
                    _fireTimer = 0;
                    var bullet = GetBullet();
                    ShootBullet(bullet, deltaTime);
                }
            }
        }

        #endregion


        #region Methods

        private Bullet GetBullet()
        {
            var bullet = BulletPool.Instance.Get();
            bullet.transform.rotation = _barrel.rotation;
            bullet.transform.position = _barrel.position;
            bullet.gameObject.SetActive(true);

            return bullet;
        }

        private void ShootBullet(Bullet bullet, float deltaTime)
        {
            bullet.transform.Translate(Vector3.up * bullet.MoveSpeed * deltaTime);
            bullet.LifeTime += deltaTime;
            if (bullet.LifeTime > bullet.MaxLifeTime)
            {
                BulletPool.Instance.ReturnToPool(bullet);
            }
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _userInputMouse.MouseOnChange -= BoolOnAxisMouseOnChange;
        }

        #endregion


        #region Methods

        private void BoolOnAxisMouseOnChange(bool value)
        {
            _valueChange = value;
        }

        #endregion
    }
}