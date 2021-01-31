using UnityEngine;


namespace JevLogin.Lesson07.Strategy
{
    public abstract class BaseBehaviour : ScriptableObject
    {
        #region Fields

        [SerializeField] protected float _speed;

        #endregion


        #region Methods

        public abstract void Behaviour(Transform value);

        #endregion
    }
}