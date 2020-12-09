using UnityEngine;

namespace JevLogin
{
    internal class PlayerInitialization
    {
        private PlayerFactory _playerFactory;
        private Transform _player;
        private PlayerModel _playerModel;

        public PlayerInitialization(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _playerModel = _playerFactory.CreatePlayerModel();
            _player = _playerModel.PlayerComponents.Player;
        }

    }
}