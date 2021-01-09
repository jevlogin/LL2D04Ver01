using UnityEngine;


namespace JevLogin
{
    public sealed class SaveController : IExecute, ICleanup
    {
        #region Fields

        private SaveDataRepository _saveDataRepository;
        private SaveListObject _saveListObject;

        private IUserInputBool _inputSave;
        private IUserInputBool _inputLoad;

        private bool _isSavedPress;
        private bool _isLoadedPress;

        #endregion


        #region ClassLifeCycles

        public SaveController((IUserInputBool inputSave, IUserInputBool inputLoad) userInputBool, SaveDataRepository saveDataRepository, SaveListObject saveListObject)
        {
            _inputSave = userInputBool.inputSave;
            _inputLoad = userInputBool.inputLoad;
            _saveDataRepository = saveDataRepository;
            _saveListObject = saveListObject;

            _inputSave.UserInputBoolOnChange += PressSaveButton;
            _inputLoad.UserInputBoolOnChange += PressLoadButton;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            if (_isSavedPress)
            {
                Debug.Log("Save Event");
            }
            if (_isLoadedPress)
            {
                Debug.Log("Load Event");
                _saveDataRepository.Load(_saveListObject.ListObject);
            }
        } 

        #endregion

        #region Methods

        private void PressLoadButton(bool valuePress)
        {
            _isLoadedPress = valuePress;
        }

        private void PressSaveButton(bool valuePress)
        {
            _isSavedPress = valuePress;
        } 

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _inputSave.UserInputBoolOnChange -= PressSaveButton;
            _inputLoad.UserInputBoolOnChange -= PressLoadButton;
        }

        

        #endregion
    }
}