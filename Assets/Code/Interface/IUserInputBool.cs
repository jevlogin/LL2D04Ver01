using System;


namespace JevLogin
{
    public interface IUserInputBool 
    {
        event Action<bool> MouseOnChange;
        void GetButtonDownAndUp();
    }
}