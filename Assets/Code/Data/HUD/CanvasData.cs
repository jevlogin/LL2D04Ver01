using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "CanvasData", menuName = "Data/CanvasData", order = 51)]
    public class CanvasData : ScriptableObject
    {
        [Header("Содержит всевозможные настройки для Canvas."), Space(20)] public CanvasSettingsData CanvasSettingsData;
    }
}