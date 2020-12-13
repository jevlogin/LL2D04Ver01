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


        #region UnityMethods

        private void Start()
        {
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);

            var bulletInitialization = new BulletInitialization(new BulletPool(playerInitialization));

            var enemyInitialization = new EnemyInitialization(new EnemyPool(10, ManagerName.POOL_ENEMY));

            _controllers = new Controllers();
            _controllers.Add(playerInitialization);
            _controllers.Add(bulletInitialization);
            _controllers.Add(enemyInitialization);


            _controllers.Initialization();
            //TODO только лишь чтобы показать что сделал статичный метод
            //Enemy.CreateShipEnemy(new HealthPoint(100.0f, 50.0f));
        }

        #endregion
    }
}
