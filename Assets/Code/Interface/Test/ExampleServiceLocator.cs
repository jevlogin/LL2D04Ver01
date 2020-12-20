using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleServiceLocator : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.SetService<IIservice>(new Service());
        }

        private void Start()
        {
            ServiceLocator.Resolve<IIservice>().Test();
        }
    }
}