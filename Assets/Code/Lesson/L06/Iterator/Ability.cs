namespace JevLogin.Iterator
{
    public sealed class Ability : IAbility
    {
        #region Properties

        public DamageType DamageType { get; }
        public Target Target { get; }
        public string Name { get; }
        public int Damage { get; }

        #endregion


        #region ClassLifeCycles

        public Ability(DamageType damageType, Target target, string name, int damage)
        {
            DamageType = damageType;
            Target = target;
            Name = name;
            Damage = damage;
        }

        #endregion


        #region UnityMethods

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}