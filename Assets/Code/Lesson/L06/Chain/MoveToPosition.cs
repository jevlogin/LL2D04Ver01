using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public sealed class MoveToPosition : GameHandler
    {
        #region Fields

        [SerializeField] private Vector3 _positionToMove;
        [SerializeField] private float _speed;
        private bool _moveToPosition;   //TODO - зачем тут bool? 

        #endregion


        #region Methods

        private IEnumerator StartMoving()
        {
            while ((transform.position - _positionToMove).sqrMagnitude > 0.0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _positionToMove, _speed * Time.deltaTime);
                yield return null;
            }
            base.Handle();
        }

        public override IGameHandler Handle()
        {
            StartCoroutine(StartMoving());
            return this;
        }

        #endregion
    }
}