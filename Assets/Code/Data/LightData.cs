using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "LightData", menuName = "Data/LightData", order = 51)]
    public sealed class LightData : ScriptableObject
    {
        [SerializeField] private GameObject _directionLight;
    }
}
