using UnityEngine;

namespace JevLogin
{
    public class EnemyModel : MonoBehaviour, IMove
    {
        #region Fields

        public EnemyStruct EnemyStruct;
        public EnemyComponents EnemyComponents;
        public EnemySettingsData EnemySettingsData;

        #endregion


        #region Properties

        public EnemyModel(EnemyStruct enemyStruct, EnemyComponents enemyComponents, EnemySettingsData enemySettings)
        {
            EnemyStruct = enemyStruct;
            EnemyComponents = enemyComponents;
            EnemySettingsData = enemySettings;
        }

        public void Move(Vector3 point)
        {
            if ((EnemyComponents.EnemyTransform.localPosition - point).sqrMagnitude >= EnemySettingsData.StoppingDistance * EnemySettingsData.StoppingDistance)
            {

            }
        }

        #endregion
    }
}