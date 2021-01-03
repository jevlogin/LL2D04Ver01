using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class Example : MonoBehaviour
    {
        private void Start()
        {
            var enemy = new Enemy(new MagicalAttack(), new Infantry());

            enemy.Attack();
            enemy.Move();
        }
    }
}