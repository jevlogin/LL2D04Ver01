namespace JevLogin
{
    internal sealed class InputInitialization : IEmptyInitialization
    {
        #region Fields

        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputMouse _inputMouse;

        #endregion


        #region Properties

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _inputMouse = new PCInputMouse();
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

        public IUserInputMouse GetInputMouse()
        {
            return _inputMouse;
        }

        #endregion
    }
}