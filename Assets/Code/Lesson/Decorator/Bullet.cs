using UnityEngine;


namespace JevLogin.Decorator
{
    public sealed class Bullet : IAmmunition
    {
        public Rigidbody BulletInstance { get; }
        public float TimeDestroy { get; }

        public Bullet(Rigidbody bulletInstance, float timeDestroy)
        {
            BulletInstance = bulletInstance;
            TimeDestroy = timeDestroy;
        }
    }
}