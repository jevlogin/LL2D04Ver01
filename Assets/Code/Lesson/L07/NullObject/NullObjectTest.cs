using System;
using UnityEngine;


namespace JevLogin.Lesson07.NullObject
{
    public sealed class NullObjectTest : MonoBehaviour
    {
        public event Action Doing = () => { };

        private void Start()
        {
            Doing.Invoke();
        }
    }
}