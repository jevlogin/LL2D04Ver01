namespace JevLogin
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyData enemyData;

        public EnemyFactory(EnemyData enemy)
        {
            this.enemyData = enemy;
        }
    }
}