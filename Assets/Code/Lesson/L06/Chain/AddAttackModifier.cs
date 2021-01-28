namespace JevLogin.ChainOfResponsibility
{
    public sealed class AddAttackModifier : EnemyModifier
    {
        #region Fields

        private readonly int _attack;

        #endregion


        #region ClassLifeCycles

        public AddAttackModifier(Enemy enemy, int attack) : base(enemy)
        {
            _attack = attack;
        }

        #endregion


        #region Methods

        public override void Handle()
        {
            _enemy.Attack += _attack;
            base.Handle();
        }

        #endregion
    }
}