using System;
using UnityEngine;


namespace JevLogin
{
    public class PCInputSave : IUserInputBool
    {
        public event Action<bool> UserInputBoolOnChange = delegate (bool value) { };

        public void GetButtonDownAndUp()
        {
            UserInputBoolOnChange.Invoke(Input.GetButtonDown(AxisManager.SAVE));
        }
    }
}