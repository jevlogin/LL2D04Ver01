using UnityEngine;


namespace JevLogin
{
    public sealed class WindowFactory
    {
        public IWindow CreateWindow(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    return new PCWindow();
                case RuntimePlatform.XboxOne:
                case RuntimePlatform.PS4:
                    return new ConsoleWindow();
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }
    }
}