using System;

namespace JevLogin
{
    internal class PCInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChange;

        public void GetAxis()
        {
            throw new NotImplementedException();
        }
    }
}