using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyTest : IFire
    {
        private readonly IAttack _attack = new AttackBullet();

        public void Fire(Vector3 position)
        {
            _attack.Attack(position);
        }
    }
}