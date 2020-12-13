using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class CameraController : ILateExecute
    {
        private Transform _playerTransform;
        private Transform _cameraTransform;
        private readonly Vector3 _offset;

        public CameraController(Transform player, Transform camera)
        {
            _playerTransform = player;
            _cameraTransform = camera;
            _offset = _cameraTransform.position - _playerTransform.position;
        }

        public void LateExecute(float deltaTime)
        {
            Vector3 desiredPosition = _playerTransform.position + _offset; 
            Vector3 smooth = Vector3.Lerp(_cameraTransform.position, desiredPosition, deltaTime);
            _cameraTransform.position = smooth;
        }
    }
}