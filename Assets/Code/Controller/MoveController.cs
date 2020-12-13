using System;
using UnityEngine;

namespace JevLogin
{
    public sealed class MoveController : IExecute, ICleanup
    {
        #region Fields

        private Transform _transformPlayer;

        private Vector3 _move;

        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        private float _speed;
        private float _vertical;
        private float _horizontal;

        #endregion


        #region Properties

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, Transform transform, float speed)
        {
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _transformPlayer = transform;
            _speed = speed;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _speed;
            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _transformPlayer.localPosition += _move;
        }

        #endregion


        #region Methods

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        #endregion
    }
}