using UnityEngine;

namespace JevLogin
{
    internal class PlayerInitialization
    {
        private PlayerFactory _playerFactory;
        private Transform _player;

        public PlayerInitialization(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
        }

    }
}