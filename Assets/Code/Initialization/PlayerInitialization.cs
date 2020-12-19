using UnityEngine;

namespace JevLogin
{
    public class PlayerInitialization : IInitialization
    {
        #region Fields

        private PlayerFactory _playerFactory;
        private Transform _player;
        private PlayerModel _playerModel;

        #endregion


        #region Properties

        public PlayerInitialization(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _playerModel = _playerFactory.CreatePlayerModel();
            _player = _playerModel.PlayerComponents.Player;
            _playerModel.PlayerComponents.BulletRigidbody = _playerFactory.CreateBulletRigidBody();
        }

        #endregion


        #region IInitialization
        public void Initialization()
        {

        }

        #endregion


        #region Methods

        public Transform GetPlayer()
        {
            return _player;
        }

        public PlayerModel GetPlayerModel()
        {
            return _playerModel;
        }

        #endregion
    }
}