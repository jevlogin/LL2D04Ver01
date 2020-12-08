using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    public sealed class PlayerData : ScriptableObject
    {
        public Sprite Sprite;

        [SerializeField] private Material _materialTrailRenderer;

        [SerializeField] private Color _startColor = Color.red;
        [SerializeField] private Color _endColor = Color.blue;

        [SerializeField, Range(0, 100)] private float _speed;

        [SerializeField, Range(0, 1)] private float _startWidth = 0.1f;
        [SerializeField, Range(0, 1)] private float _endWidth = 0.01f;
        [SerializeField, Range(0, 1)] private float _time = 0.1f;

        public float Speed => _speed;
        public float StartWidth => _startWidth;
        public float EndWidth => _endWidth;
        public float Time => _time;
        public Material MaterialTrailRenderer => _materialTrailRenderer;
        public Color StartColor => _startColor;
        public Color EndColor => _endColor;
    }
}
