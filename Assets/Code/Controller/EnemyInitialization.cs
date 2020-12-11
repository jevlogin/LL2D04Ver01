using UnityEngine;

namespace JevLogin
{
    internal class EnemyInitialization : IInitialization
    {
        private EnemyFactory _enemyFactory;
        private CompositeMove _enemy;

        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _enemy = new CompositeMove();
            _enemy.AddUnit(_enemyFactory.CreateEnemyModel());
        }

        public IMove GetEnemy()
        {
            return _enemy;
        }

        public void Initialization()
        {

        }
    }
}