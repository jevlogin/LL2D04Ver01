using UnityEngine;


namespace JevLogin
{
    public sealed class AttackBullet : IAttack
    {
        public void Attack(Vector3 position)
        {
            var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.name = ManagerName.BULLET;
            bullet.transform.position = position;
        }
    }
}