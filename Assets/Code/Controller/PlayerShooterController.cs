using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JevLogin
{
    public sealed class PlayerShooterController : IExecute, ICleanup
    {
        private readonly PlayerInitialization _playerInitialization;
        private readonly Rigidbody2D _bullet;
        private readonly Transform _barrel;
        
        private IUserInputMouse _userInputMouse;

        private readonly float _force;
        private bool _valueChange;

        public PlayerShooterController(IUserInputMouse userInputMouse, PlayerInitialization playerInitialization)
        {
            _userInputMouse = userInputMouse;

            _playerInitialization = playerInitialization;

            _bullet = _playerInitialization.GetPlayerModel().PlayerComponents.BulletRigidbody;
            _barrel = _playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            _force = _playerInitialization.GetPlayerModel().PlayerStruct.Force;

            _userInputMouse.MouseOnChange += BoolOnAxisMouseOnChange;
        }

        private void BoolOnAxisMouseOnChange(bool value)
        {
            _valueChange = value;
        }

        public void Execute(float deltaTime)
        {
            if (_valueChange)
            {
                var bullet = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
                bullet.AddForce(_barrel.up * _force);
            }
        }

        public void Cleanup()
        {
            _userInputMouse.MouseOnChange -= BoolOnAxisMouseOnChange;
        }

    }
}