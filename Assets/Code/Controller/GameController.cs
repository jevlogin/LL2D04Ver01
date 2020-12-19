using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Data _data;
        private Controllers _controllers;

        #endregion


        #region UnityMethods

        private void Start()
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);

            var poolBullet = new Pool<Bullet>(20, ManagerPath.BULLET_PATH);
            var bulletInitialization = new BulletInitialization(new BulletPool(poolBullet, playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform));

            var poolAsteroid = new Pool<Asteroid>(10, ManagerPath.ASTEROID_PATH);
            var enemyAsteroidInitialization = new EnemyAsteroidInitialization(new EnemyAsteroidPool(poolAsteroid, new GameObject(ManagerName.POOL_ASTEROIDS).transform));

            var poolEnemyShip = new Pool<Ship>(20, ManagerPath.ENEMY_PATH_SHIP);
            var enemyShipInitialization = new EnemyShipInitialization(new EnemyShipPool(poolEnemyShip, new GameObject(ManagerName.POOL_ENEMY_SHIP).transform));


            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);
            _controllers.Add(enemyAsteroidInitialization);
            _controllers.Add(enemyShipInitialization);
            _controllers.Add(new InputController(inputInitialization.GetInput(), inputInitialization.GetInputMouse()));
            _controllers.Add(new RotationPlayerController(playerInitialization.GetPlayer(), camera));
            _controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerInitialization.GetPlayerModel().PlayerStruct.Speed));
            _controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
            _controllers.Add(new PlayerShooterController(inputInitialization.GetInputMouse(), playerInitialization, bulletInitialization));
            _controllers.Add(new EnemyAsteroidController(enemyAsteroidInitialization, playerInitialization.GetPlayer()));
            

            _controllers.Initialization();

            //TODO только лишь чтобы показать что сделал статичный метод
            //Enemy.CreateShipEnemy(new HealthPoint(100.0f, 50.0f));
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }

        #endregion
    }
}
