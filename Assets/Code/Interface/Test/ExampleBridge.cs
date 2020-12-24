using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class ExampleBridge : MonoBehaviour
    {
        private void Start()
        {
            var enemy = new EnemyBridge(new MagicalAttack(), new Infanrty());
        }
    }
}