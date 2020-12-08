using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    public sealed class PlayerData : ScriptableObject
    {
        public Sprite Sprite;
        [SerializeField, Range(0, 100)] private float _speed;

        public float Speed => _speed;
    }
}
