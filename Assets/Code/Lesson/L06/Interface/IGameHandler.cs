namespace JevLogin
{
    public interface IGameHandler
    {
        IGameHandler Handle();
        IGameHandler SetNext(IGameHandler gameHandler);
    }
}