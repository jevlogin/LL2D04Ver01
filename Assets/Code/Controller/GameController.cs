﻿using TMPro;
using UnityEngine;


namespace JevLogin
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Data _data;
        private Controllers _controllers;
        private ListenerDieShowHUD _listenerDieShowHUD;
        private CanvasController _canvasController;

        #endregion


        #region UnityMethods

        private void Start()
        {
            Camera camera = Camera.main;
            _listenerDieShowHUD = new ListenerDieShowHUD();

            var canvasFactory = new CanvasFactory(_data.CanvasData);
            var canvasInitialization = new CanvasInitialization(canvasFactory);

            _canvasController = new CanvasController(_listenerDieShowHUD, canvasInitialization);

            var inputInitialization = new InputInitialization();

            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);

            var poolBullet = new Pool<Bullet>(10, ManagerPath.BULLET_PATH);
            var bulletInitialization = new BulletInitialization(new BulletPool(poolBullet, playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform));
            
            var poolAsteroid = new Pool<Asteroid>(10, ManagerPath.ASTEROID_PATH);
            var enemyAsteroidInitialization = new EnemyAsteroidInitialization(new EnemyAsteroidPool(poolAsteroid, new GameObject(ManagerName.POOL_ASTEROIDS).transform));
            
            _listenerDieShowHUD.AddListObject(enemyAsteroidInitialization.EnemyPool);

            var poolEnemyShip = new Pool<Ship>(20, ManagerPath.ENEMY_PATH_SHIP);
            var enemyShipInitialization = new EnemyShipInitialization(new EnemyShipPool(poolEnemyShip, new GameObject(ManagerName.POOL_ENEMY_SHIP).transform));

            //Регистрирую корабли в Сервис локатор. Чисто для домашки. так не буду делать... мне не нравится такой подход...
            ServiceLocator.SetService(enemyShipInitialization);

            _controllers = new Controllers();
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);
            _controllers.Add(enemyAsteroidInitialization);
            _controllers.Add(enemyShipInitialization);

            _controllers.Add(new InputController(inputInitialization.GetInput(), inputInitialization.GetInputMouse()));
            _controllers.Add(new RotationPlayerController(playerInitialization.GetPlayer(), camera));
            _controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerInitialization.GetPlayerModel().PlayerStruct.Speed));
            _controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
            _controllers.Add(new EnemyAsteroidController(enemyAsteroidInitialization, playerInitialization.GetPlayer(), playerInitialization.GetPlayerCollision));
            _controllers.Add(new PlayerShooterController(inputInitialization.GetInputMouse(), playerInitialization, bulletInitialization));

            _controllers.Initialization();
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
