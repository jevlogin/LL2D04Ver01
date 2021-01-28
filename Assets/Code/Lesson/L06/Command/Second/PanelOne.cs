using UnityEngine;
using UnityEngine.UI;


namespace JevLogin.Command.Second
{
    public sealed class PanelOne : BaseUI
    {
        #region Fields

        [SerializeField] private Text _text;

        #endregion


        #region Methods

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        public override void Execute()
        {
            _text.text = nameof(PanelOne);
            gameObject.SetActive(true);
        }

        #endregion
    }
}