using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Command.Second
{
    public abstract class BaseUI : MonoBehaviour
    {
        public abstract void Execute();
        public abstract void Cancel();
    }
}