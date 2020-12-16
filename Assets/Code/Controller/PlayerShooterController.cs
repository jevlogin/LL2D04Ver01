﻿using System;
using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerShooterController : IExecute, ICleanup
    {
        //TODO - BlasterWithGeneric

        #region Fields

        private readonly PlayerInitialization _playerInitialization;
        private readonly Transform _barrel;
        private BulletInitialization _bulletInitialization;

        private IUserInputMouse _userInputMouse;

        private readonly float _force;
        private bool _valueChange;

        /*******************/

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
            _force = _playerInitialization.GetPlayerModel().PlayerStruct.Force;
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
                    Fire();
                }
            }
        }

        #endregion


        #region Methods
        private void Fire()
        {
            //Здесь надо вытащить пулю из пулла
            var bullet = BulletPool.Instance.Get();
            bullet.transform.rotation = _barrel.rotation;
            bullet.transform.position = _barrel.position;

            bullet.transform.SetParent(null);

            bullet.gameObject.SetActive(true);
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