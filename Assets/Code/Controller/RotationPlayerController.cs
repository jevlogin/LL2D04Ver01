using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class RotationPlayerController : IRotation, ILateExecute
    {
        private Transform _playerTransform;
        private Camera _camera;

        public RotationPlayerController(Transform transform, Camera camera)
        {
            _playerTransform = transform;
            _camera = camera;
        }

        public void LateExecute(float deltaTime)
        {
            var direction = _camera.WorldToScreenPoint(_playerTransform.position) - Input.mousePosition;
            Rotation(direction);
        }

        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}