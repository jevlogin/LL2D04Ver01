using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class PCInputMouse : IUserInputBool
    {
        #region Fields

        public event Action<bool> UserInputBoolOnChange = delegate (bool value) { };

        #endregion


        #region IUserInputMouse

        public void GetButtonDownAndUp()
        {
            UserInputBoolOnChange.Invoke(Input.GetButtonDown(AxisManager.FIRE1));
        }

        #endregion
    }
}