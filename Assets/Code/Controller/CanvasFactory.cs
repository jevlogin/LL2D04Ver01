using UnityEngine.UI;

namespace JevLogin
{
    public class CanvasFactory
    {
        private CanvasData _canvasData;
        private CanvasModel _canvasModel;

        public CanvasFactory(CanvasData canvasData)
        {
            _canvasData = canvasData;
        }

        public CanvasModel CanvasModel()
        {
            if (_canvasModel == null)
            {
                _canvasModel = new CanvasModel(_canvasData.CanvasSettingsData);
            }

            return _canvasModel;
        }
       
    }
}