using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Data _data;

        private void Start()
        {
            Debug.Log(_data.Player);
        }
    }
}
