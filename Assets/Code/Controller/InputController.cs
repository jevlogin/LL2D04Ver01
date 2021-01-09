using System;

namespace JevLogin
{
    public sealed class InputController : IExecute
    {
        #region Fields

        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputBool _inputMouse;

        #endregion


        #region Properties

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, IUserInputBool userInputMouse)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _inputMouse = userInputMouse;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _inputMouse.GetButtonDownAndUp();
        }

        #endregion
    }
}