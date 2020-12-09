using UnityEngine;

namespace JevLogin
{
    internal sealed class PlayerFactory : IPlayerFactory
    {
        #region Fields

        private readonly PlayerData _playerData;
        private PlayerModel _playerModel;

        #endregion


        #region Properties

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
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

        public PlayerModel CreatePlayerModel()
        {
            if (_playerModel == null)
            {
                var playerStruct = _playerData.PlayerStruct;
                var playerSettings = _playerData.PlayerSettingsData;
                var playerComponents = _playerData.PlayerComponents;

                var spawnPlayer = CreatePlayer();

                var bullet = new GameObject("Barrel");
                bullet.transform.SetParent(spawnPlayer.transform);
                bullet.transform.position = new Vector2(_playerData.PlayerSettingsData.OffsetVector.x, _playerData.PlayerSettingsData.OffsetVector.y);

                var dustParticles = new GameObject("Dust Particles");

                dustParticles.AddParticleSystem(_playerData, dustParticles.name);

                dustParticles.transform.SetParent(spawnPlayer.transform);

                playerComponents.Player = spawnPlayer.transform;

                _playerModel = new PlayerModel(playerStruct, playerComponents, playerSettings);
            }

            return _playerModel;
        }

        #endregion

    }
}