using UnityEngine;

namespace JevLogin
{
    internal sealed class PlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public Transform CreatePlayer()
        {
            return new GameObject("Player").AddSprite(_playerData.Sprite);
        }

    }
}