using System.IO;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _directionLightPath;

        private PlayerData _player;
        private EnemyData _enemy;
        private LightData _directionLight;

        #endregion


        #region Properties

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>(Path.Combine(ManagerPath.DATA, _playerDataPath));
                }
                return _player;
            }
        }

        public EnemyData Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    _enemy = Load<EnemyData>(Path.Combine(ManagerPath.DATA, _enemyDataPath));
                }
                return _enemy;
            }
        }

        public LightData DirectionLight
        {
            get
            {
                if (_directionLight == null)
                {
                    _directionLight = Load<LightData>(Path.Combine(ManagerPath.DATA, _directionLightPath));
                }
                return _directionLight;
            }
        }

        #endregion


        #region Methods

        private T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(Path.ChangeExtension(path, null));
        }

        #endregion
    }
}
