using UnityEngine;

namespace JevLogin
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemy();
        IEnemy CreateIEnemy();
        EnemyModel CreateEnemyModel();
    }
}