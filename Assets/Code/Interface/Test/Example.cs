using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class Example : MonoBehaviour
    {
        private Camera _camera;
        private IFire _fire;

        private void Awake()
        {
            _camera = Camera.main;
            _fire = new EnemyTest();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                mousePos.z = 20.0f;
                var objectPos = _camera.ScreenToWorldPoint(mousePos);

                _fire.Fire(objectPos);
            }
        }
    }
}