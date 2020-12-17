namespace JevLogin
{
    public interface ILateExecute : IExecute
    {
        void LateExecute(float deltaTime);
    }
}