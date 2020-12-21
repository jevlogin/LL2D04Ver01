using UnityEngine;

namespace JevLogin
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        #region Fields

        private readonly PlayerData _playerData;
        private PlayerModel _playerModel;
        private ICollisionDetect _playerCollision;

        #endregion


        #region Properties

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

       

        #endregion


        #region Methods

        public Rigidbody2D CreateBulletRigidBody()
        {
            var bullet = _playerData.PlayerSettingsData.BulletPrefab;

            return bullet.GetComponent<Rigidbody2D>();
        }

        public PlayerView CreatePlayer()
        {
            var player = new GameObject("Player")
                .AddSprite(_playerData.PlayerSettingsData.SpritePlayer)
                .AddCircleCollider2D()
                .AddTrailRenderer(_playerData)
                .AddComponent<PlayerView>();

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

                GetPlayerCollision = spawnPlayer;

                var barrel = new GameObject("Barrel");
                playerComponents.BarrelTransform = barrel.transform;
                barrel.transform.SetParent(spawnPlayer.transform);
                barrel.transform.position = new Vector2(_playerData.PlayerSettingsData.OffsetVector.x, _playerData.PlayerSettingsData.OffsetVector.y);

                var childrenObjectParticleSystem = Object.Instantiate(_playerData.PlayerSettingsData.ParticleSystem, spawnPlayer.transform);
                childrenObjectParticleSystem.name = "Dust Particles";

                playerComponents.Player = spawnPlayer.transform;

                _playerModel = new PlayerModel(playerStruct, playerComponents, playerSettings);
            }

            return _playerModel;
        }


        public ICollisionDetect GetPlayerCollision
        {
            get
            {
                return _playerCollision;
            }
            private set
            {
                _playerCollision = value;
            }
        }
        #endregion

    }
}