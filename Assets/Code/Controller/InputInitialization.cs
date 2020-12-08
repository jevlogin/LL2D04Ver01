namespace JevLogin
{
    internal class InputInitialization : IInitialization
    {
        #region Fields

        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;

        #endregion


        #region Properties
        
        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
        } 

        #endregion

        public void Initialization()
        {
            throw new System.NotImplementedException();
        }
    }
}