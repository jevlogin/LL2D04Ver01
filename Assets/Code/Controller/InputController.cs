using System;

namespace JevLogin
{
    public sealed class InputController : IExecute
    {
        #region Fields

        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputBool _inputMouse;
        private readonly IUserInputBool _inputSave;
        private readonly IUserInputBool _inputLoad;

        #endregion


        #region Properties

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, IUserInputBool userInputMouse, (IUserInputBool inputSave, IUserInputBool inputLoad) inputSaveOrLoadButtonDown)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _inputMouse = userInputMouse;
            _inputSave = inputSaveOrLoadButtonDown.inputSave;
            _inputLoad = inputSaveOrLoadButtonDown.inputLoad;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _inputMouse.GetButtonDownAndUp();
            _inputSave.GetButtonDownAndUp();
            _inputLoad.GetButtonDownAndUp();
        }

        #endregion
    }
}