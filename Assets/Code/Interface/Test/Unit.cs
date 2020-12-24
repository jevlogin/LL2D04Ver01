using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class Unit : IAttack
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }
    }
}