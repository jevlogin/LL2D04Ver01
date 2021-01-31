using System;


namespace JevLogin.Lesson07.Observer
{
    public interface IHit 
    {
        event Action<float> OnHitChange;
        void Hit(float damage);
    }
}