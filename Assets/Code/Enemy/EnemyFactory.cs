using UnityEngine;

namespace JevLogin
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyData _enemyData;
        private EnemyModel _enemyModel;
        

        public EnemyFactory(EnemyData enemy)
        {
            _enemyData = enemy;
        }

        public GameObject CreateEnemy()
        {
            var spriteAsteroid = _enemyData.EnemySettingsData.SpritesAsteroids;

            var enemy = new GameObject($"Asteroid-{Random.Range(0, byte.MaxValue)}")
                .AddRigidbody2D()
                .AddSprite(spriteAsteroid[(int)Random.Range(0.0f, spriteAsteroid.Length)]);

            return enemy;
        }


        public EnemyModel CreateEnemyModel()
        {
            if (_enemyModel == null)
            {
                var enemyStruct = _enemyData.EnemyStruct;
                var enemySettings = _enemyData.EnemySettingsData;
                var enemyComponents = _enemyData.EnemyComponents;

                var spawnEnemy = CreateEnemy();
                enemyComponents.EnemyTransform = spawnEnemy.transform;
                _enemyModel = new EnemyModel(enemyStruct, enemyComponents, enemySettings);
            }

            return _enemyModel;
        }
    }
}