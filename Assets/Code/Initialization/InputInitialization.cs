using System;

namespace JevLogin
{
    internal sealed class InputInitialization : IEmptyInitialization
    {
        #region Fields

        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputBool _inputMouse;
        private IUserInputBool _inputSave;
        private IUserInputBool _inputLoad;

        #endregion


        #region Properties

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _inputMouse = new PCInputMouse();
            _inputSave = new PCInputSave();
            _inputLoad = new PCInputLoad();
        }

        #endregion


        #region IInitialization

        //public void Initialization()
        //{
        //    //TODO Здесть явно что-то будет... но я пока не знаю что...
        //}

        #endregion


        #region Methods

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        public IUserInputBool GetInputMouse()
        {
            return _inputMouse;
        }

        public (IUserInputBool inputSave, IUserInputBool inputLoad) GetInputSaveOrLoadButtonDown()
        {
            (IUserInputBool inputSave, IUserInputBool inputLoad) result = (_inputSave, _inputLoad);
            return result;
        }

        #endregion
    }
}