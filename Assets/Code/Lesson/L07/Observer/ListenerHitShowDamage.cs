using UnityEngine;


namespace JevLogin.Lesson07.Observer
{
    public sealed class ListenerHitShowDamage
    {
        #region Methods

        public void Add(IHit value)
        {
            value.OnHitChange += ValueOnHitChange;
        }

        public void Remove(IHit value)
        {
            value.OnHitChange -= ValueOnHitChange;
        }

        private void ValueOnHitChange(float damage)
        {
            Debug.Log(damage);
        }

        #endregion
    }
}