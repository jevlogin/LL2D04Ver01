using UnityEngine;

namespace JevLogin
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemy();
        EnemyModel CreateEnemyModel();
    }
}