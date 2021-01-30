using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Command.Second
{
    public sealed class UserInterface : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PanelOne _panelOne;
        [SerializeField] private PanelTwo _panelTwo;

        private BaseUI _currentWindow;
        private readonly Stack<StateUI> _stateUIs = new Stack<StateUI>();

        #endregion


        #region UnityMethods

        private void Start()
        {
            _panelOne.Cancel();
            _panelTwo.Cancel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Execute(StateUI.PanelOne);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Execute(StateUI.PanelTwo);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_stateUIs.Count > 0)
                {
                    Execute(_stateUIs.Pop(), false);
                }
            }
        }

        #endregion


        #region Methods

        private void Execute(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }

            switch (stateUI)
            {
                case StateUI.None:
                    Debug.Log("Panel None");
                    break;
                case StateUI.PanelOne:
                    _currentWindow = _panelOne;
                    break;
                case StateUI.PanelTwo:
                    _currentWindow = _panelTwo;
                    break;
                default:
                    throw new System.ArgumentNullException("None Panel");
            }

            _currentWindow.Execute();

            if (isSave)
            {
                _stateUIs.Push(stateUI);
            }
        }

        #endregion
    }
}