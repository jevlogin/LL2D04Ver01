using System;


namespace JevLogin
{
    public interface IUserInputMouse 
    {
        event Action<bool> MouseOnChange;
        void GetMouseDownAndUp();
    }
}