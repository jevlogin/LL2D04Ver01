using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class EnemySettingsData
    {
        #region Fields

        [SerializeField] private Sprite[] _spritesAsteroids;
        [SerializeField] private int _countEnemy;

        #endregion


        #region Properties

        public Sprite[] SpritesAsteroids { get => _spritesAsteroids; }
        public int CountEnemy { get => _countEnemy; }

        #endregion
    }
}