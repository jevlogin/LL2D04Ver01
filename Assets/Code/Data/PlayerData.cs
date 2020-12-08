using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    public sealed class PlayerData : ScriptableObject
    {
        #region Fields

        public PlayerStruct PlayerStruct;
        public PlayerComponents PlayerComponents;
        public PlayerSettingsData PlayerSettingsData;

        #endregion

    }
}
