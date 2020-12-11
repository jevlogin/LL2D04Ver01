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


            _controllers = new Controllers();
            _controllers.Add(playerInitialization);

            Enemy.CreateAsteroidEnemy(new HealthPoint(100, Random.Range(0, 100)));


            var platform = new PlatformFactory().Create(Application.platform);
        }
    }
}
