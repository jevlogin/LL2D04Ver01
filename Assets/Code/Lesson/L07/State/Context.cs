using UnityEngine;


namespace JevLogin.Lesson07.State
{
    public sealed class Context
    {
        #region Fields

        private State _state;
        public float HealthPoint;

        #endregion


        #region ClassLifeCycles

        public Context(State state)
        {
            _state = state;
        }

        #endregion


        #region Methods

        public State State
        {
            set
            {
                _state = value;
                Debug.Log($"State: {_state.GetType().Name}");
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }

        #endregion
    }
}