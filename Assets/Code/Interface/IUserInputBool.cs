using System;


namespace JevLogin
{
    public interface IUserInputBool 
    {
        event Action<bool> UserInputBoolOnChange;
        void GetButtonDownAndUp();
    }
}