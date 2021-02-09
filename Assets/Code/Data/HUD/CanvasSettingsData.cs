using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class CanvasSettingsData
    {
        [SerializeField, Header("HUDScore"), Space(5)] private GameObject _scoreHUDPrefabScore;
        [SerializeField, Header("HUDInfoKilled"), Space(5)] private GameObject _scoreHUDPrefabInfoKilled;

        public GameObject ScoreHUDPrefab => _scoreHUDPrefabScore;
        public GameObject ScoreHUDPrefabInfoKilled => _scoreHUDPrefabInfoKilled;
    }
}