using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class RotationPlayerController : IRotation, ILateExecute
    {
        private Transform _playerTransform;
        private Camera _camera;
        private Vector3 _mousePosition;
        private float _offset = 90.0f;

        public RotationPlayerController(Transform transform, Camera camera)
        {
            _playerTransform = transform;
            _camera = camera;
        }

        public void LateExecute(float deltaTime)
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            var direction = _mousePosition - _playerTransform.position;
            direction.Normalize();
            
            Rotation(direction);
        }

        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - _offset;
            _playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}