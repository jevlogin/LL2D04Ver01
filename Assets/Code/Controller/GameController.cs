using System.Collections;
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

        private void Start()
        {
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);

            BulletPool bulletPool = new BulletPool(playerInitialization.GetPlayerModel().PlayerStruct.GetBulletPool().CapacityPool,
               playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform);
            playerInitialization.GetPlayerModel().PlayerStruct.SetBulletPool(bulletPool);
            var bullet = bulletPool.GetBullet("Bullet");
            bullet.gameObject.SetActive(true);

            EnemyPool enemyPool = new EnemyPool(10, ManagerName.POOL_ASTEROIDS);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector2.one;
            enemy.gameObject.SetActive(true);

            EnemyPool enemyShipPool = new EnemyPool(20, ManagerName.POOL_ENEMY_SHIP);
            var enemyShip = enemyShipPool.GetEnemy("Ship");
            enemyShip.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            enemyShip.gameObject.SetActive(true);

            _controllers = new Controllers();
            _controllers.Add(playerInitialization);

            Enemy.CreateShipEnemy(new HealthPoint(100.0f, 50.0f));
        }
    }
}
