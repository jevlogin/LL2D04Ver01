namespace JevLogin
{
    public class EnemyModel
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

        #endregion
    }
}