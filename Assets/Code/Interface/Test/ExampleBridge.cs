using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class ExampleBridge : MonoBehaviour
    {
        private void Start()
        {
            IAttack attack = new Unit();
            Detachment attaks = new Detachment();

            attaks.AddUnit(attack);

            attack.Attack();
            attaks.Attack();

            attaks.RemoveUnit(attack);
        }
    }
}