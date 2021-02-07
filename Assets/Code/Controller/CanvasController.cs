using UnityEngine;
using UnityEngine.UI;


namespace JevLogin
{
    public sealed class CanvasController
    {
        private ListenerDieShowHUD _listenerDieShowHUD;
        private readonly CanvasInitialization _canvasInitialization;
        private int _totalScore = 0;
        [SerializeField] private Text _textScore;
        [SerializeField] private Text _textInfoKill;

        public CanvasController(ListenerDieShowHUD listenerDieShowHUD, CanvasInitialization canvasInitialization)
        {
            _canvasInitialization = canvasInitialization;
            _listenerDieShowHUD = listenerDieShowHUD;
            _textScore = _canvasInitialization.TextScore();
            _textInfoKill = _canvasInitialization.TextInfoKill();

            _listenerDieShowHUD.ShowTheScoreAfterTheObjectsDeath += _listenerDieShowHUD_ShowTheScoreAfterTheObjectsDeath;
        }

        private void _listenerDieShowHUD_ShowTheScoreAfterTheObjectsDeath(int score)
        {
            _totalScore += score;
            _textScore.text = $"Score: {_totalScore}";
        }
    }
}