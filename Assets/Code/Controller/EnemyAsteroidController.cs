using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyAsteroidController : IExecute
    {
        private EnemyAsteroidInitialization _enemyAsteroidInitialization;
        private Transform _transformPlayer;

        public EnemyAsteroidController(EnemyAsteroidInitialization enemyAsteroidInitialization, Transform transformPlayer)
        {
            _enemyAsteroidInitialization = enemyAsteroidInitialization;
            _transformPlayer = transformPlayer;
        }

        public void Execute(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}