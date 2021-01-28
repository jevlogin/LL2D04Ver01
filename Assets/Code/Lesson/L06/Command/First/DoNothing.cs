using UnityEngine;


namespace JevLogin.Command
{
    /// <summary>
    /// Pattern Null object
    /// </summary>
    public sealed class DoNothing : ICommand
    {
        #region Properties

        public bool Succeeded { get; private set; }

        #endregion


        #region ICommand

        public bool Execute(Transform box)
        {
            Succeeded = true;
            return Succeeded;
        }

        public void Undo(Transform box)
        {
        }

        #endregion
    }
}