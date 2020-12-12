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

        private IEnumerator Start()
        {
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);


            _controllers = new Controllers();
            _controllers.Add(playerInitialization);

            EnemyPool enemyPool = new EnemyPool(10);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector2.one;
            enemy.gameObject.SetActive(true);

            yield return new WaitForSeconds(3);

            BulletPool bulletPool = new BulletPool(5, playerInitialization.GetPlayer());
        }
    }
}
