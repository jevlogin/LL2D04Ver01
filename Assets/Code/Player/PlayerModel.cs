namespace JevLogin
{
    public sealed class PlayerModel
    {
        public readonly PlayerStruct PlayerStruct;
        public readonly PlayerComponents PlayerComponents;
        public readonly PlayerSettingsData PlayerSettingsData;

        public PlayerModel(PlayerStruct playerStruct, PlayerComponents playerComponents, PlayerSettingsData playerSettingsData)
        {
            PlayerStruct = playerStruct;
            PlayerComponents = playerComponents;
            PlayerSettingsData = playerSettingsData;
        }
    }
}