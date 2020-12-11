namespace JevLogin
{
    public interface IPlatform
    {
        IInput Input { get; }
        IWindow Window { get; }
    }
}