namespace JevLogin.ChainOfResponsibility
{
    public sealed class Enemy
    {
        #region Fields

        public string Name;
        public int Attack;
        public int Defense;

        #endregion


        #region ClassLifeCycles

        public Enemy(string name, int attack, int defense)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }

        #endregion
    }
}