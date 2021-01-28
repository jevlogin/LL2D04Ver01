using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public sealed class RotateAFewSeconds : GameHandler
    {
        #region Fields

        [SerializeField] private float _rotationSpeed = 10.0f;
        [SerializeField] private float _rotationDuration = 3.0f;

        #endregion


        #region Methods

        private IEnumerator StartRotation()
        {
            var time = 0.0f;
            while (time < _rotationDuration)
            {
                transform.Rotate(Vector3.forward * (_rotationSpeed * Time.deltaTime));
                time += Time.deltaTime;
                yield return null;
            }
            base.Handle();
        }

        public override IGameHandler Handle()
        {
            StartCoroutine(StartRotation());
            return this;
        }

        #endregion
    }
}