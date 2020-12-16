using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerShooterController : IExecute, ICleanup
    {
        #region Fields

        private readonly PlayerInitialization _playerInitialization;
        private Rigidbody2D _bulletRigidbody;
        private readonly Transform _barrel;
        private BulletInitialization _bulletInitialization;

        private IUserInputMouse _userInputMouse;

        private readonly float _force;
        private bool _valueChange;

        #endregion


        #region Properties

        public PlayerShooterController(IUserInputMouse userInputMouse, PlayerInitialization playerInitialization, BulletInitialization bulletInitialization)
        {
            _userInputMouse = userInputMouse;

            _playerInitialization = playerInitialization;
            _bulletInitialization = bulletInitialization;

            _barrel = _playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            _force = _playerInitialization.GetPlayerModel().PlayerStruct.Force;

            _userInputMouse.MouseOnChange += BoolOnAxisMouseOnChange;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            if (_valueChange)
            {
                var bulletPool = _bulletInitialization.GetBulletPool();

                var bullet = bulletPool.BulletsPool[ManagerName.BULLET].Dequeue();

                bullet.transform.SetParent(null);
                if (bullet.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
                {
                    rigidbody.gameObject.SetActive(true);
                    rigidbody.velocity = rigidbody.transform.up * _force;
                }

                //bullet.SetActive(false);
                //bulletPool.BulletsPool[ManagerName.BULLET].Enqueue(bullet);
            }
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _userInputMouse.MouseOnChange -= BoolOnAxisMouseOnChange;
        }

        #endregion


        #region Methods

        private void BoolOnAxisMouseOnChange(bool value)
        {
            _valueChange = value;
        }

        #endregion
    }
}