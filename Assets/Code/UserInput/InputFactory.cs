using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class InputFactory
    {
        public IInput CreateInput(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    return new PCInput();

                case RuntimePlatform.XboxOne:
                case RuntimePlatform.PS4:
                    return new ConsoleInput();

                default:
                    throw new System.ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }
    }
}