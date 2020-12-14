﻿using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerShooterController : IExecute, ICleanup
    {
        #region Fields

        private readonly PlayerInitialization _playerInitialization;
        private readonly Rigidbody2D _bulletRigidbody;
        private readonly Transform _barrel;
        private Bullet _bullet;

        private IUserInputMouse _userInputMouse;

        private readonly float _force;
        private bool _valueChange;

        #endregion


        #region Properties

        public PlayerShooterController(IUserInputMouse userInputMouse, PlayerInitialization playerInitialization, Bullet bullet)
        {
            _userInputMouse = userInputMouse;

            _playerInitialization = playerInitialization;
            _bullet = bullet;

            //_bulletRigidbody = _playerInitialization.GetPlayerModel().PlayerComponents.BulletRigidbody;
            _bulletRigidbody = _bullet.GetComponent<Rigidbody2D>();

            if (_bulletRigidbody == null) _bulletRigidbody.gameObject.AddRigidbody2D();

            _barrel = _playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            _force = _playerInitialization.GetPlayerModel().PlayerStruct.Force;

            _userInputMouse.MouseOnChange += BoolOnAxisMouseOnChange;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            if (_valueChange)
            {
                //var bullet = Object.Instantiate(_bulletRigidbody, _barrel.position, _barrel.rotation);
                var bullet = Object.Instantiate(_bulletRigidbody);
                bullet.AddForce(_barrel.up * _force);
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