using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        private void Start()
        {
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);
            var enemyFactory = new EnemyFactory(_data.Enemy);
            var enemyInitialization = new EnemyInitialization(enemyFactory);


            _controllers = new Controllers();
            _controllers.Add(playerInitialization);
            _controllers.Add(enemyInitialization);
            
        }
    }
}
