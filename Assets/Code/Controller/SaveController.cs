using System;
using UnityEngine;

namespace JevLogin
{
    internal class SaveController : IExecute, ICleanup
    {
        #region Fields
        
        private IUserInputBool _inputSave;
        private IUserInputBool _inputLoad;

        private bool _isSavedPress;
        private bool _isLoadedPress;

        #endregion


        #region ClassLifeCycles

        public SaveController((IUserInputBool inputSave, IUserInputBool inputLoad) userInputBool)
        {
            _inputSave = userInputBool.inputSave;
            _inputLoad = userInputBool.inputLoad;

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