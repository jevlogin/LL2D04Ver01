using UnityEngine;

namespace JevLogin
{
    internal sealed class PlayerFactory : IPlayerFactory
    {
        #region Fields

        private readonly PlayerData _playerData;

        #endregion


        #region Properties

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        #endregion


        #region Methods

        public PlayerModel GetPlayerModel()
        {

        }
        public Transform CreatePlayer()
        {
            var player = new GameObject("Player")
                .AddSprite(_playerData.PlayerSettingsData.Sprite)
                .AddCircleCollider2D()
                .AddChildrenTransform("Bullet")
                .AddTrailRenderer(_playerData).transform;

            return player;
        }

        #endregion

    }
}