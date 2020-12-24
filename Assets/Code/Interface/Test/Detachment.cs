using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class Detachment : IAttack
    {
        private List<IAttack> _attacks = new List<IAttack>();

        public void AddUnit(IAttack attack)
        {
            _attacks.Add(attack);
        }

        public void RemoveUnit(IAttack attack)
        {
            _attacks.Remove(attack);
        }

        public void Attack()
        {
            foreach (var attack in _attacks)
            {
                attack.Attack();
            }
        }
    }
}