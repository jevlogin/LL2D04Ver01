namespace JevLogin.ChainOfResponsibility
{
    public class EnemyModifier
    {
        #region Fields

        protected Enemy _enemy;
        protected EnemyModifier _nextModifier;

        #endregion


        #region ClassLifeCycles

        public EnemyModifier(Enemy enemy)
        {
            _enemy = enemy;
        }

        #endregion


        #region Methods

        public void Add(EnemyModifier enemyModifier)
        {
            if (_nextModifier != null)
            {
                _nextModifier.Add(enemyModifier);
            }
            else
            {
                _nextModifier = enemyModifier;
            }
        }

        public virtual void Handle() => _nextModifier?.Handle();

        #endregion
    }
}