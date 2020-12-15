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
                //var bullet = Object.Instantiate(_bulletRigidbody, _barrel.position, _barrel.rotation);
                
                //bullet.AddForce(_barrel.up * _force);

                SpawnFromPool(deltaTime);

            }
        }

        private void SpawnFromPool(float deltaTime)
        {
            var bulletPool = _bulletInitialization.GetBulletPool();

            if (_bulletRigidbody == null)
            {
                _bulletRigidbody = bulletPool.GetBulletByName(ManagerName.BULLET).GetComponent<Rigidbody2D>();
            }
            _bulletRigidbody.gameObject.SetActive(true);

            var bullet = Object.Instantiate(_bulletRigidbody);
            bullet.AddForce(_barrel.up *_force, ForceMode2D.Force);
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