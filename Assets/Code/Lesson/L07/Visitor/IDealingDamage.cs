namespace JevLogin.Lesson07.Visitor
{
    public interface IDealingDamage<T>
    {
        void Visit(T hit, InfoCollision info);
    }
}