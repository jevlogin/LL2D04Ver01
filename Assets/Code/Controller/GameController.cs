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
            var playerModel = new PlayerModel(playerFactory);
            var playerInitialization = new PlayerInitialization(playerFactory);

        }
    }
}
