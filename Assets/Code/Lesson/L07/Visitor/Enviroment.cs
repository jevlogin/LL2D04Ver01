namespace JevLogin.Lesson07.Visitor
{
    public sealed class Enviroment : Hit
    {
        public override void Activate(IDealingDamage<Hit> value, float damage)
        {
            value.Visit(this, new InfoCollision(damage));
        }
    }
}