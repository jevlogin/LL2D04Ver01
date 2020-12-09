using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class PlayerSettingsData
    {
        #region Fields

        [SerializeField, Header("Спрайт для корабля"), Space(5)] private Sprite _sprite;
        [SerializeField, Header("Система частиц для корабля"), Space(20)] private GameObject _particleSystem;
        [SerializeField, Space(10), Header("Настройки для TrailRenderer"), Space(20)] private Material _materialTrailRenderer;

        [SerializeField, ] private Color _startColor = Color.red;
        [SerializeField] private Color _endColor = Color.blue;

        [SerializeField, Range(0, 1)] private float _startWidth;
        [SerializeField, Range(0, 1)] private float _endWidth;
        [SerializeField, Range(0, 1)] private float _time;

        [SerializeField, Space(10), Header("Вектор смещения для свтола пушки"), Space(20)] private Vector2 _offsetVector;

        #endregion


        #region Properties

        public Material MaterialTrailRenderer => _materialTrailRenderer;
        public Sprite Sprite => _sprite;
        public GameObject ParticleSystem => _particleSystem;
        public Color StartColor => _startColor;
        public Color EndColor => _endColor;
        public Vector2 OffsetVector => _offsetVector;
        public float StartWidth => _startWidth;
        public float EndWidth => _endWidth;
        public float Time => _time;

        #endregion

    }
}