using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerShooterController : IExecute, ICleanup
    {
        #region Fields

        private readonly PlayerInitialization _playerInitialization;
        private readonly Transform _barrel;
        private BulletInitialization _bulletInitialization;
        private List<Bullet> _listBullets;

        private IUserInputMouse _userInputMouse;

        private bool _valueChange;
        private float _refireTimer = 0.3f;
        private float _fireTimer;

        /***************/
        public float MoveSpeed = 5.0f;
        private readonly float _maxLifeTime = 5.0f;

        #endregion


        #region Properties

        public PlayerShooterController(IUserInputMouse userInputMouse, PlayerInitialization playerInitialization, BulletInitialization bulletInitialization)
        {
            _userInputMouse = userInputMouse;

            _playerInitialization = playerInitialization;
            _bulletInitialization = bulletInitialization;

            _barrel = _playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;

            _fireTimer = _refireTimer;
            _listBullets = new List<Bullet>();

            _userInputMouse.MouseOnChange += BoolOnAxisMouseOnChange;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            _fireTimer += deltaTime;
            BulletShot();
            BulletControl(deltaTime);
        }

        #endregion


        #region Methods

        private Bullet GetBullet()
        {
            var bullet = BulletPool.Instance.Get();
            bullet.transform.SetParent(null);
            bullet.transform.rotation = _barrel.rotation;
            bullet.transform.position = _barrel.position;

            bullet.gameObject.SetActive(true);
            return bullet;
        }

        private void BulletControl(float deltaTime)
        {
            for (int i = 0; i < _listBullets.Count; i++)
            {
                if (_listBullets[i].isActiveAndEnabled)
                {
                    MoveConcreteBulletByList(deltaTime, i);

                    _listBullets[i].LifeTime += deltaTime;

                    if (_listBullets[i].LifeTime > _maxLifeTime)
                    {
                        _listBullets[i].LifeTime = 0.0f;
                        BulletPool.Instance.ReturnToPool(_listBullets[i]);
                        _listBullets.RemoveAt(i);
                    }
                }
            }
        }

        private void BulletShot()
        {
            if (_fireTimer >= _refireTimer)
            {
                if (_valueChange)
                {
                    _fireTimer = 0;
                    _listBullets.Add(GetBullet());

                    // в момент выстрела будет появляться новый кораблик из пулла вражеских кораблей, используя сервислокатор.
                    // буду спавнить новый кораблик после выстрела используя сервис локатор
                    var ship = ServiceLocator.Resolve<EnemyShipInitialization>().EnemyShipPool.Get();
                    
                    ship.transform.position = new Vector3(Random.Range(_barrel.position.x, _barrel.position.y), Random.Range(_barrel.position.x, _barrel.position.y), 0.0f);
                    ship.gameObject.SetActive(true);
                    
                    Debug.Log($"Создали новый корабль");
                }
            }
        }

        private void MoveConcreteBulletByList(float deltaTime, int i)
        {
            if (_listBullets[i].TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.velocity = rigidbody2D.transform.up * MoveSpeed;
            }
            else
            {
                _listBullets[i].transform.Translate(Vector2.up * MoveSpeed * deltaTime);
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