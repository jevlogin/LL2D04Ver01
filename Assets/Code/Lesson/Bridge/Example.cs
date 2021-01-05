using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class Example : MonoBehaviour
    {
        private List<Enemy> enemies = new List<Enemy>();

        private void Start()
        {
            var enemyMagic = new Enemy(new MagicalAttack(), new Infantry());
            enemies.Add(enemyMagic);

            var enemyCavalry = new Enemy(new MiddleAttack(), new Cavalry());
            enemies.Add(enemyCavalry);

            var enemyMiddleAttack = new Enemy(new MiddleAttack(), new Infantry());
            enemies.Add(enemyMiddleAttack);


            foreach (var enemy in enemies)
            {
                enemy.Attack();
                enemy.Move();
            }
        }
    }
}