namespace JevLogin
{
    public interface ILateUpdate : IController
    {
        void LateExecute(float deltaTime);
    }
}