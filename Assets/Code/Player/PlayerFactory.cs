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

        public Transform CreatePlayer()
        {
            return new GameObject("Player").AddSprite(_playerData.PlayerSettingsData.Sprite).AddCircleCollider2D().AddTrailRenderer(_playerData).transform;
        }

        #endregion

    }
}