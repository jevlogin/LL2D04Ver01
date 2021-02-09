using UnityEngine;
using UnityEngine.UI;

namespace JevLogin
{
    public class CanvasInitialization
    {
        private readonly CanvasFactory _canvasFactory;
        private readonly CanvasModel _canvasModel;
        private Text _textScore;
        private Text _textInfoKill;

        public CanvasInitialization(CanvasFactory canvasFactory)
        {
            _canvasFactory = canvasFactory;
            _canvasModel = _canvasFactory.CanvasModel();
        }

        public Text TextScore()
        {
            if (_textScore == null)
            {
                var textScore = _canvasModel._canvasSettingsData.ScoreHUDPrefab.transform.GetComponentInChildren<Text>();
                textScore.text = $"{ManagerName.SCORE} 0";
               _textScore = Object.Instantiate(textScore, GameObject.Find(ManagerName.CANVAS).transform);
            }
            return _textScore;
        }

        public Text TextInfoKill()
        {
            if (_textInfoKill == null)
            {
                var textInfoKill = _canvasModel._canvasSettingsData.ScoreHUDPrefabInfoKilled.transform.GetComponentInChildren<Text>();
                textInfoKill.text = string.Empty;
                _textInfoKill = Object.Instantiate(textInfoKill, GameObject.Find(ManagerName.CANVAS).transform);
            }
            return _textInfoKill;
        }

        public CanvasModel GetCanvasModel()
        {
            return _canvasModel;
        }
    }
}