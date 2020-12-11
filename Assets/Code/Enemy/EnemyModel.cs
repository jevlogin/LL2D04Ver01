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
                var direction = (point - EnemyComponents.EnemyTransform.localPosition).normalized;
                EnemyComponents.Rigidbody2D.velocity = direction * EnemyStruct.Speed;
            }
            else
            {
                EnemyComponents.Rigidbody2D.velocity = Vector2.zero;
            }
        }

        #endregion
    }
}