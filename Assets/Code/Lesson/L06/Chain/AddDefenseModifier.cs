namespace JevLogin.ChainOfResponsibility
{
    public sealed class AddDefenseModifier : EnemyModifier
    {
        #region Fields

        private readonly int _maxDefense;

        #endregion


        #region ClassLifeCycles

        public AddDefenseModifier(Enemy enemy, int maxDefense) : base(enemy)
        {
            _maxDefense = maxDefense;
        }

        #endregion


        #region Methods

        public override void Handle()
        {
            if (_enemy.Defense <= _maxDefense)
            {
                _enemy.Defense++;
            }
            base.Handle();
        }

        #endregion
    }
}