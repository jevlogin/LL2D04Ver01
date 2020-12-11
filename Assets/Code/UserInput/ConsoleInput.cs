using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ConsoleInput : IInput
    {
        public string Name => nameof(ConsoleInput);
    }
}