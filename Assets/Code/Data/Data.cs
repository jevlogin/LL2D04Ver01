using System.IO;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _enemyDataPath;

        private PlayerData _player;
        private EnemyData _enemy;

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>($"Data/{_playerDataPath}");
                }
                return _player;
            }
        }

        private T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(Path.ChangeExtension(path, null));
        }
    }
}
