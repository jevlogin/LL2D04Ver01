using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class Service : IIservice
    {
        public void Test()
        {
            Debug.Log(nameof(Service));
        }
    }
}