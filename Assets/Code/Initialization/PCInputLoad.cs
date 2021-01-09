using System;
using UnityEngine;

namespace JevLogin
{
    internal class PCInputLoad : IUserInputBool
    {
        public event Action<bool> UserInputBoolOnChange;

        public void GetButtonDownAndUp()
        {
            UserInputBoolOnChange.Invoke(Input.GetButtonDown(AxisManager.LOAD));
        }
    }
}