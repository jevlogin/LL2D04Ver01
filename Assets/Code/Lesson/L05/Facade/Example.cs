using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Facade
{
    public sealed class Example : MonoBehaviour
    {
        [SerializeField] private int _mapSize;
        [SerializeField] private string _userName;

        private void Start()
        {
            var gameService = new GameService();
            gameService.Start(_mapSize, _userName);
        }
    }
}