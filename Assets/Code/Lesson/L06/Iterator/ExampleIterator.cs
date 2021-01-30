using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin.Iterator
{
    public sealed class ExampleIterator : MonoBehaviour
    {
        private void Start()
        {
            var ability = new List<IAbility>
            {
                new Ability(DamageType.Magical, Target.None, "Inner Fire", 100),
                new Ability(DamageType.Magical, Target.Unit | Target.Autocast, "Burning Spear", 200),
                new Ability(DamageType.Magical, Target.Passive, "Berserker's Blood", 300),
                new Ability(DamageType.Magical, Target.Unit, "Life Break", 400)
            };

            IEnemy enemy = new Enemy(ability);

            Debug.Log(enemy[0]);
            Debug.Log(new string('+', 30));
            Debug.Log(enemy[Target.Unit | Target.Autocast]);
            Debug.Log(new string('+', 30));
            Debug.Log(enemy[Target.Unit | Target.Passive]);
            Debug.Log(new string('+', 30));
            Debug.Log(enemy.MaxDamage);
            Debug.Log(new string('+', 30));
            foreach (var item in enemy)
            {
                Debug.Log(item);
            }
            Debug.Log(new string('+', 30));

            foreach (var item in enemy.GetAbility(DamageType.Magical))
            {
                Debug.Log(item);
            }

            Debug.Log(new string('+', 30));
            foreach (var item in enemy.GetAbility().Take(2))
            {
                Debug.Log(item);
            }
        }
    }
}