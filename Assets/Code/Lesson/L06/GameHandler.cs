using UnityEngine;


namespace JevLogin
{
    public abstract class GameHandler : MonoBehaviour, IGameHandler
    {
        #region Fields

        private IGameHandler _nextHandler;

        #endregion


        #region IGameHandler

        public IGameHandler SetNext(IGameHandler gameHandler)
        {
            _nextHandler = gameHandler;
            return gameHandler;
        }

        public virtual IGameHandler Handle()
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle();
            }
            return _nextHandler;
        }

        #endregion
    }
}