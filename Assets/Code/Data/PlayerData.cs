using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    public sealed class PlayerData : ScriptableObject
    {
        #region Fields

        [SerializeField] private Material _materialTrailRenderer;
        [SerializeField] private Sprite _sprite;

        [SerializeField] private Color _startColor = Color.red;
        [SerializeField] private Color _endColor = Color.blue;

        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(0, 1)] private float _startWidth;
        [SerializeField, Range(0, 1)] private float _endWidth;
        [SerializeField, Range(0, 1)] private float _time;

        #endregion


        #region Properties

        public Material MaterialTrailRenderer => _materialTrailRenderer;
        public Sprite Sprite => _sprite;
        public Color StartColor => _startColor;
        public Color EndColor => _endColor;
        public float Speed => _speed;
        public float StartWidth => _startWidth;
        public float EndWidth => _endWidth;
        public float Time => _time;

        #endregion
    }
}
