namespace JevLogin.Lesson07.Visitor
{
    public interface IDealingDamage<T>
    {
        void Visit(T hit, InfoCollision info);

        //void Visit(Enemy hit, InfoCollision info);
        //void Visit(Enviroment hit, InfoCollision info);
        //void Visit(Knight hit, InfoCollision info);
    }
}