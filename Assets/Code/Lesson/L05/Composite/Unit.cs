using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Composite
{
    public sealed class Unit : IAttack
    {
        public void Attack()
        {
            Debug.Log("Composite Unit Attak");
        }
    }
}