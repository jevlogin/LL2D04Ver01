using UnityEngine;

namespace JevLogin
{
    internal sealed class PlayerFactory : IPlayerFactory
    {
        #region Fields

        private readonly PlayerData _playerData;
        public readonly PlayerModel PlayerModel;

        #endregion


        #region Properties

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;

            var playerStruct = _playerData.PlayerStruct;
            var playerSettings = _playerData.PlayerSettingsData;
            var playerComponents = _playerData.PlayerComponents;

            var spawnPlayer = CreatePlayer();

            var bullet = new GameObject("Barrel");
            bullet.transform.SetParent(spawnPlayer.transform);
            bullet.transform.position = new Vector2(-0.13f, 0.4f);

            var dustParticles = new GameObject("Dust Particles");

            dustParticles.AddParticleSystem(_playerData, dustParticles.name);

            dustParticles.transform.SetParent(spawnPlayer.transform);

            playerComponents.Player = spawnPlayer.transform;

            PlayerModel = new PlayerModel(playerStruct, playerComponents, playerSettings);

        }

        #endregion


        #region Methods

        public GameObject CreatePlayer()
        {
            var player = new GameObject("Player")
                .AddSprite(_playerData.PlayerSettingsData.Sprite)
                .AddCircleCollider2D()
                .AddTrailRenderer(_playerData);

            return player;
        }


        #endregion

    }
}