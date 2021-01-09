using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class PCInputMouse : IUserInputBool
    {
        #region Fields

        public event Action<bool> MouseOnChange = delegate (bool value) { };

        #endregion


        #region IUserInputMouse

        public void GetButtonDownAndUp()
        {
            MouseOnChange.Invoke(Input.GetButtonDown(AxisManager.FIRE1));
        }

        #endregion
    }
}