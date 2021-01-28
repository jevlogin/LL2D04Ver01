using UnityEngine;


namespace JevLogin.Command
{
    public sealed class MoveForward : ICommand
    {
        #region Fields

        private readonly float _moveDistance;

        #endregion


        #region Properties

        public bool Succeeded { get; private set; }

        #endregion


        #region ClassLifeCycles

        public MoveForward(float moveDistance)
        {
            _moveDistance = moveDistance;
        }

        #endregion


        #region ICommand

        public bool Execute(Transform box)
        {
            box.Translate(box.forward * _moveDistance);
            Succeeded = true;
            return Succeeded;
        }

        public void Undo(Transform box)
        {
            box.Translate(-box.forward * _moveDistance);
        }

        #endregion
    }
}