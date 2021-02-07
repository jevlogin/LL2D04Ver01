using System;

namespace JevLogin
{
    public interface IDie 
    {
        event Action<int> OnDieChange;
        void Die(int value);
    }
}